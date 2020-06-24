using IsdaBest.Forms;
using IsdaBest.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsdaBest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoadDependencies();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        static void LoadDependencies()
        {
            if (!Directory.Exists(Extension.AssetsDir)) Directory.CreateDirectory(Extension.AssetsDir);
            if (!Directory.Exists(Extension.ImagesDir)) Directory.CreateDirectory(Extension.ImagesDir);
            if (!Directory.Exists(Extension.Depencencies)) Directory.CreateDirectory(Extension.Depencencies);
            if (!File.Exists(Extension.Concrt140)) File.WriteAllBytes(Extension.Concrt140, Properties.Resources.concrt140);
            if (!File.Exists(Extension.Cvextern)) File.WriteAllBytes(Extension.Cvextern, Properties.Resources.cvextern);
            if (!File.Exists(Extension.Msvcp140)) File.WriteAllBytes(Extension.Msvcp140, Properties.Resources.msvcp140);
            if (!File.Exists(Extension.Msvcp140_1)) File.WriteAllBytes(Extension.Msvcp140_1, Properties.Resources.msvcp140_1);
            if (!File.Exists(Extension.Msvcp140_2)) File.WriteAllBytes(Extension.Msvcp140_2, Properties.Resources.msvcp140_2);
            if (!File.Exists(Extension.Msvcp140_codecvt_ids)) File.WriteAllBytes(Extension.Msvcp140_codecvt_ids, Properties.Resources.msvcp140_codecvt_ids);
            if (!File.Exists(Extension.OpenCV_videoio_ffmpeg420_64)) File.WriteAllBytes(Extension.OpenCV_videoio_ffmpeg420_64, Properties.Resources.opencv_videoio_ffmpeg420_64);
            if (!File.Exists(Extension.VCruntime140)) File.WriteAllBytes(Extension.VCruntime140, Properties.Resources.vcruntime140);
            if (!File.Exists(Extension.VCruntime140_1)) File.WriteAllBytes(Extension.VCruntime140_1, Properties.Resources.vcruntime140_1);
        }
    }
}
