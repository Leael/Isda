using IsdaBest.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsdaBest.Forms
{
    public partial class Processor : Form
    {
        private readonly string file = "";

        private int CurrentParrot { set { labelCParrot.Text = "Parrot: " + value.ToString(); } }
        private int CurrentRabbit { set { labelCRabbit.Text = "Rabbit: " + value.ToString(); } }
        private int CurrentSergeant { set { labelCSergeant.Text = "Sergeant: " + value.ToString(); } }

        public Processor(string filename)
        {
            file = filename;
            InitializeComponent();
            StartCamera();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            ML.Stop();
            base.OnClosing(e);
        }

        private void StartCamera()
        {
            ML.OnFrameResult += result =>
            {
                if (Disposing || !Visible) return;
                Invoke(new MethodInvoker(delegate
                {
                    CurrentParrot = result.ParrotCount;
                    CurrentRabbit = result.RabbitCount;
                    CurrentSergeant = result.SergeantCount;
                }));
            };
            ML.StartFile(imageBoxFrameGrabber1, imageBoxFrameGrabber2, file);
        }

        private void ButtonCap_Click(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(delegate
            {
                ML.FrameHalted = true;
                foreach (ML.ImageToClassify imageToClassify in ML.GetFrameImagesToClassify())
                {
                    if (Disposing || !Visible) return;
                    Trainer trainer = new Trainer(imageToClassify);
                    trainer.ShowDialog();
                    if (!trainer.HasChosenOption) break;
                }
                ML.FrameHalted = false;
            }));
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
