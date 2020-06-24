using IsdaBest.Services;
using IsdaBest.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsdaBest.Forms
{
    public partial class Trainer : Form
    {
        private readonly ML.ImageToClassify imageToClassify;
        public bool HasChosenOption = false;

        public Trainer(ML.ImageToClassify toClassify)
        {
            InitializeComponent();
            imageToClassify = toClassify;
            imageBoxFrameGrabber.Image = imageToClassify.Image;
            Text = string.IsNullOrEmpty(toClassify.RecognizedLabel) ? "Unknown image" : "Classified as \"" + toClassify.RecognizedLabel + "\"";
        }

        private void ButtonFish1_Click(object sender, EventArgs e)
        {
            HasChosenOption = true;
            imageToClassify.Train("PARROT");
            Close();
        }

        private void ButtonFish2_Click(object sender, EventArgs e)
        {
            HasChosenOption = true;
            imageToClassify.Train("RABBIT");
            Close();
        }

        private void ButtonFish3_Click(object sender, EventArgs e)
        {
            HasChosenOption = true;
            imageToClassify.Train("SERGEANT");
            Close();
        }

        private void ButtonExclude_Click(object sender, EventArgs e)
        {
            HasChosenOption = true;
            //imageToClassify.Train("EXCLUDED");
            Close();
        }
    }
}
