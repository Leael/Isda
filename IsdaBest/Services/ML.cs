using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;
using IsdaBest.ViewModel;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.ML.Transforms.ValueToKeyMappingEstimator;

namespace IsdaBest.Services
{
    public static partial class ML
    {
        #region Helper Classes

        public class Contour
        {
            public readonly VectorOfVectorOfPoint Origin;
            public readonly VectorOfPoint VectorOfPoint;
            public readonly Rectangle BoundingRectangle;
            public Contour(VectorOfVectorOfPoint origin, VectorOfPoint vectorOfPoint)
            {
                Origin = origin;
                VectorOfPoint = vectorOfPoint;
                BoundingRectangle = CvInvoke.BoundingRectangle(vectorOfPoint);
            }
        }
        public class FrameResult
        {
            public readonly int ParrotCount;
            public readonly int RabbitCount;
            public readonly int SergeantCount;
            public FrameResult(int parrotCount, int rabbitCount, int sergeantCount)
            {
                ParrotCount = parrotCount;
                RabbitCount = rabbitCount;
                SergeantCount = sergeantCount;
            }
        }

        public class ImageToClassify
        {
            public readonly Mat Image;
            public readonly string RecognizedLabel;
            public ImageToClassify(Mat image, string recognizedLabel = "")
            {
                Image = image;
                RecognizedLabel = recognizedLabel;
            }
            public void Train(string label)
            {
                string dir = Path.Combine(Extension.ImagesDir, label);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                int index = 1;
                string filename;
                while (File.Exists(Path.Combine(dir, index.ToString("0000") + ".jpg")))
                {
                    index++;
                }
                filename = index.ToString("0000") + ".jpg";
                Image.Save(Path.Combine(dir, filename));
            }
        }


        #endregion

        #region Properties

        private static Mat currentFrame = new Mat();
        private static readonly Mat resize = new Mat();
        private static readonly Mat gray = new Mat();

        private static VideoCapture grabber;

        private static MLContext mlContext;

        private static ImageBox imageBoxFrameGrabber1;
        private static ImageBox imageBoxFrameGrabber2;

        public static Action<string> Logger;
        public static bool Started { get; private set; } = false;

        #endregion

        #region Initializers

        public static void Init()
        {
            Task.Run(delegate
            {
                try
                {
                    Logger?.Invoke("ML: Initializing . . .");

                    Logger?.Invoke("ML: " + (File.Exists(Extension.TransferModel) ? "Transfer model ready" : "Transfer model does not exist"));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            });
        }

        private static void MlContext_Log(object sender, LoggingEventArgs e)
        {
            if (e.Message.StartsWith("[Source=ImageClassificationTrainer;"))
            {
                Logger?.Invoke(e.Message);
            }
        }

        public static void GenerateModel()
        {
            Task.Run(delegate
            {
                try
                {
                    Logger?.Invoke("ML: Generating Model . . .");

                    // 1. Load the image set
                    var imagesPath = Directory
                        .GetFiles(Extension.ImagesDir, "*", searchOption: SearchOption.AllDirectories)
                        .Where(x => Path.GetExtension(x) == ".jpg" || Path.GetExtension(x) == ".png");

                    if (imagesPath.Count() <= 0)
                    {
                        Logger?.Invoke("ML: No datasets found");
                        Logger?.Invoke("ML: Model generation aborted");
                        return;
                    }

                    IEnumerable<(string path, string name)> imagePathNames = imagesPath.Select(imagePath => (imagePath, Directory.GetParent(imagePath).Name));
                    List<ImageData> images = imagePathNames.Select(x => new ImageData(x.path, x.name)).ToList();

                    foreach ((string path, string name) in imagePathNames)
                    {
                        Logger?.Invoke("ML: Loading \"" + name + "\" dataset from \"" + path + "\"");
                    }

                    mlContext = new MLContext(seed: 1);
                    mlContext.Log += MlContext_Log;

                    // 2. Load the initial full image-set into an IDataView and shuffle so it'll be better balanced
                    IDataView fullImagesDataset = mlContext.Data.LoadFromEnumerable(images);
                    IDataView shuffledFullImageFilePathsDataset = mlContext.Data.ShuffleRows(fullImagesDataset);

                    Logger?.Invoke("ML: Loading datasets finished");

                    // 3. Load Images with in-memory type within the IDataView and Transform Labels to Keys (Categorical)
                    IDataView shuffledFullImagesDataset = mlContext.Transforms.Conversion.
                            MapValueToKey(outputColumnName: "LabelAsKey", inputColumnName: "Label", keyOrdinality: KeyOrdinality.ByValue)
                        .Append(mlContext.Transforms.LoadRawImageBytes(
                                                        outputColumnName: "Image",
                                                        imageFolder: Extension.ImagesDir,
                                                        inputColumnName: "ImagePath"))
                        .Fit(shuffledFullImageFilePathsDataset)
                        .Transform(shuffledFullImageFilePathsDataset);

                    // 4. Split the data 80:20 into train and test sets, train and evaluate.
                    var trainTestData = mlContext.Data.TrainTestSplit(shuffledFullImagesDataset, testFraction: 0.2);
                    IDataView trainDataView = trainTestData.TrainSet;
                    IDataView testDataView = trainTestData.TestSet;

                    // 5. Define the model's training pipeline using CNN default values
                    var pipeline = mlContext.MulticlassClassification.Trainers
                            .ImageClassification(featureColumnName: "Image",
                                                 labelColumnName: "LabelAsKey",
                                                 validationSet: testDataView)
                        .Append(mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName: "PredictedLabel",
                                                                              inputColumnName: "PredictedLabel"));

                    Logger?.Invoke("ML: Pipeline ready");

                    Logger?.Invoke("*** Training the image classification model with CNN Transfer Learning on top of the selected pre-trained model/architecture ***");

                    // Measuring training time
                    var watch1 = Stopwatch.StartNew();

                    //Train
                    ITransformer trainedModel = pipeline.Fit(trainDataView);

                    watch1.Stop();
                    var elapsed1Ms = watch1.ElapsedMilliseconds;
                    Logger?.Invoke($"ML: Training with transfer learning took: { elapsed1Ms / 1000} seconds");

                    // 7. Get the quality metrics (accuracy, etc.)
                    Logger?.Invoke("Making predictions in bulk for evaluating model's quality...");

                    // Measuring time
                    var watch2 = Stopwatch.StartNew();

                    var predictionsDataView = trainedModel.Transform(testDataView);

                    var metrics = mlContext.MulticlassClassification.Evaluate(predictionsDataView, labelColumnName: "LabelAsKey", predictedLabelColumnName: "PredictedLabel");

                    Logger?.Invoke($"************************************************************");
                    Logger?.Invoke($"*    Metrics for TensorFlow CNN Transfer Learning multi-class classification model   ");
                    Logger?.Invoke($"*-----------------------------------------------------------");
                    Logger?.Invoke($"    AccuracyMacro = {metrics.MacroAccuracy:0.####}, a value between 0 and 1, the closer to 1, the better");
                    Logger?.Invoke($"    AccuracyMicro = {metrics.MicroAccuracy:0.####}, a value between 0 and 1, the closer to 1, the better");
                    Logger?.Invoke($"    LogLoss = {metrics.LogLoss:0.####}, the closer to 0, the better");

                    int i = 0;
                    foreach (var classLogLoss in metrics.PerClassLogLoss)
                    {
                        i++;
                        Logger?.Invoke($"    LogLoss for class {i} = {classLogLoss:0.####}, the closer to 0, the better");
                    }
                    Logger?.Invoke($"************************************************************");

                    watch2.Stop();
                    var elapsed2Ms = watch2.ElapsedMilliseconds;
                    Logger?.Invoke($"Predicting and Evaluation took: {elapsed2Ms / 1000} seconds");

                    // 8. Save the model to assets/outputs (You get ML.NET .zip model file and TensorFlow .pb model file)
                    Logger?.Invoke("ML: Saving generated model");
                    mlContext.Model.Save(trainedModel, trainDataView.Schema, Extension.TransferModel);
                    Logger?.Invoke($"Model saved to: {Extension.TransferModel}");

                    Logger?.Invoke("ML: Generating model complete");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            });
        }

        #endregion

        #region FrameCapture

        private static bool modelReady = false;
        private static PredictionEngine<InMemoryImageData, ImagePrediction> predictionEngine;
        private static string filenameLogInstance = "";
        private static int frameIndex = 0;

        public static void StartFile(ImageBox frameGrabber1, ImageBox frameGrabber2, string filename)
        {
            Task.Run(delegate
            {
                try
                {
                    // Initialize per file variable
                    Started = true;
                    modelReady = File.Exists(Extension.TransferModel);

                    // Attach UI ends
                    imageBoxFrameGrabber1 = frameGrabber1;
                    imageBoxFrameGrabber2 = frameGrabber2;

                    totalParrot = 0;
                    totalRabbit = 0;
                    totalSergeant = 0;

                    var mlContext = new MLContext(seed: 1);

                    if (modelReady)
                    {
                        Logger?.Invoke("ML: Loading Transfer model");

                        // Load the model
                        var loadedModel = mlContext.Model.Load(Extension.TransferModel, out var modelInputSchema);

                        // Create prediction engine to try a single prediction (input = ImageData, output = ImagePrediction)
                        predictionEngine = mlContext.Model.CreatePredictionEngine<InMemoryImageData, ImagePrediction>(loadedModel);

                        // Create the log filename instance
                        filenameLogInstance = filename + Extension.Helpers.EncodeDateTime(DateTime.Now) + ".log";
                        File.WriteAllLines(filenameLogInstance, new string[]
                        {
                            "Logs for \"" + filename + "\"",
                            "Time: " + DateTime.Now
                        });

                        Logger?.Invoke("ML: Starting with transfer model");
                    }
                    else
                    {
                        Logger?.Invoke("ML: Starting without transfer model");
                    }

                    grabber = new VideoCapture(filename);

                    Stopwatch stopwatch = new Stopwatch();

                    frameIndex = 0;
                    while (true)
                    {
                        try
                        {
                            if (!Started) break;

                            stopwatch.Restart();

                            currentFrame = grabber.QueryFrame();
                            frameIndex++;

                            if (currentFrame == null)
                            {
                                Logger?.Invoke("End of video");
                                Stop();
                                return;
                            }

                            CvInvoke.Resize(currentFrame, resize, new Size(420, 340), interpolation: Inter.Cubic);
                            CvInvoke.CvtColor(resize, gray, ColorConversion.Bgr2Gray);

                            FishParser();
                            FishTypeParser();

                            stopwatch.Stop();

                            Logger?.Invoke("Frame process duration: " + stopwatch.ElapsedMilliseconds + " Milliseconds");
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                catch (Exception ex)
                {

                }
                File.AppendAllText(filenameLogInstance, "Total " + ":\tParrot fish: " + totalParrot + "\tRabbit fish: " + totalRabbit + "\tSergeant fish: " + totalSergeant + "\n");
            });
            if (grabber != null)
            {
                grabber.Dispose();
                grabber = null;
            }
        }

        public static void Stop()
        {
            Started = false;
        }

        #endregion

        #region FishParser

        private static readonly Mat fpBlur1 = new Mat();
        private static readonly Mat fpBlur2 = new Mat();
        private static readonly Mat fpBlur3 = new Mat();
        private static readonly Mat fpBlur4 = new Mat();
        private static readonly Mat fpThres = new Mat();
        private static readonly Mat fpErode = new Mat();
        private static readonly Mat fpDilate = new Mat();
        private static readonly List<Contour> fpContours = new List<Contour>();
        private static int totalParrot = 0;
        private static int totalRabbit = 0;
        private static int totalSergeant = 0;

        private static void FishParser()
        {
            CvInvoke.PyrDown(gray, fpBlur1, BorderType.Default);
            CvInvoke.PyrDown(fpBlur1, fpBlur2, BorderType.Default);
            CvInvoke.PyrUp(fpBlur2, fpBlur3, BorderType.Default);
            CvInvoke.PyrUp(fpBlur3, fpBlur4, BorderType.Default);

            CvInvoke.AdaptiveThreshold(fpBlur4, fpThres, 255, AdaptiveThresholdType.MeanC, ThresholdType.Binary, 151, -5);

            Mat element = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
            CvInvoke.Erode(fpThres, fpErode, element, new Point(-1, -1), 1, BorderType.Constant, new MCvScalar(0, 0, 0));
            CvInvoke.Dilate(fpErode, fpDilate, element, new Point(-1, -1), 3, BorderType.Constant, new MCvScalar(0, 0, 0));

            fpContours.Clear();
            Mat hierarchy = new Mat();
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(fpDilate, contours, hierarchy, RetrType.Tree, ChainApproxMethod.ChainApproxSimple);
            for (int i = 0; i < contours.Size; i++)
            {
                double a = CvInvoke.ContourArea(contours[i], false);
                if (a >= 200 && a <= 20000) fpContours.Add(new Contour(contours, contours[i]));
            }

            imageBoxFrameGrabber1.Image = fpDilate;
        }

        #endregion

        #region FishTypeParser

        public static event Action<FrameResult> OnFrameResult;
        public static bool FrameHalted = false;
        private static readonly Mat ftResult = new Mat();
        private static readonly List<ImageToClassify> imagesToClassify = new List<ImageToClassify>();

        private static void FishTypeParser()
        {
            while (FrameHalted) { }
            imagesToClassify.Clear();

            resize.CopyTo(ftResult);

            int parrot = 0;
            int rabbit = 0;
            int sergeant = 0;

            foreach (Contour contour in fpContours)
            {
                Mat image = new Mat(resize, contour.BoundingRectangle);
                MCvScalar color = new MCvScalar(0, 0, 255);
                ImageToClassify imageToClassify = null;

                if (modelReady)
                {
                    VectorOfByte vector = new VectorOfByte();
                    CvInvoke.Imencode(".jpg", image, vector);
                    InMemoryImageData imgToPredict = new InMemoryImageData(vector.ToArray());
                    ImagePrediction prediction = predictionEngine.Predict(imgToPredict);
                    string label = "Unknown";

                    if (prediction.Score.Max() > 0.7)
                    {
                        imageToClassify = new ImageToClassify(image, prediction.PredictedLabel);

                        switch (prediction.PredictedLabel)
                        {
                            case "PARROT":
                                parrot++;
                                label = prediction.PredictedLabel;
                                color = new MCvScalar(255, 0, 0);
                                break;
                            case "RABBIT":
                                rabbit++;
                                label = prediction.PredictedLabel;
                                color = new MCvScalar(0, 255, 0);
                                break;
                            case "SERGEANT":
                                sergeant++;
                                label = prediction.PredictedLabel;
                                color = new MCvScalar(255, 0, 255);
                                break;
                        }
                    }
                    CvInvoke.PutText(
                        ftResult,
                        label,
                        new Point(contour.BoundingRectangle.X - 2, contour.BoundingRectangle.Y - 2),
                        FontFace.HersheyTriplex,
                        0.5d,
                        color);
                }
                imagesToClassify.Add(imageToClassify ?? new ImageToClassify(image));
                CvInvoke.Rectangle(ftResult, contour.BoundingRectangle, color, thickness: 2);
            }
            imageBoxFrameGrabber2.Image = ftResult;

            if (modelReady)
            {
                File.AppendAllText(filenameLogInstance, "Frame " + frameIndex + ":\tParrot fish: " + parrot + "\tRabbit fish: " + rabbit + "\tSergeant fish: " + sergeant + "\n");
            }

            totalParrot += parrot;
            totalRabbit += rabbit;
            totalSergeant += sergeant;

            OnFrameResult?.Invoke(new FrameResult(parrot, rabbit, sergeant));
        }

        public static IEnumerable<ImageToClassify> GetFrameImagesToClassify() => imagesToClassify;

        #endregion
    }
}
