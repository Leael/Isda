namespace IsdaBest.Forms
{
    partial class Trainer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonFish2 = new System.Windows.Forms.Button();
            this.buttonFish3 = new System.Windows.Forms.Button();
            this.buttonFish1 = new System.Windows.Forms.Button();
            this.buttonExclude = new System.Windows.Forms.Button();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFish2
            // 
            this.buttonFish2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonFish2.Location = new System.Drawing.Point(218, 62);
            this.buttonFish2.Name = "buttonFish2";
            this.buttonFish2.Size = new System.Drawing.Size(129, 33);
            this.buttonFish2.TabIndex = 1;
            this.buttonFish2.Text = "Rabbit fish (Kitong)";
            this.buttonFish2.UseVisualStyleBackColor = true;
            this.buttonFish2.Click += new System.EventHandler(this.ButtonFish2_Click);
            // 
            // buttonFish3
            // 
            this.buttonFish3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonFish3.Location = new System.Drawing.Point(218, 101);
            this.buttonFish3.Name = "buttonFish3";
            this.buttonFish3.Size = new System.Drawing.Size(129, 33);
            this.buttonFish3.TabIndex = 2;
            this.buttonFish3.Text = "Seargent fish (kapal)";
            this.buttonFish3.UseVisualStyleBackColor = true;
            this.buttonFish3.Click += new System.EventHandler(this.ButtonFish3_Click);
            // 
            // buttonFish1
            // 
            this.buttonFish1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonFish1.Location = new System.Drawing.Point(218, 23);
            this.buttonFish1.Name = "buttonFish1";
            this.buttonFish1.Size = new System.Drawing.Size(129, 33);
            this.buttonFish1.TabIndex = 3;
            this.buttonFish1.Text = "Parrot Fish (molmol)";
            this.buttonFish1.UseVisualStyleBackColor = true;
            this.buttonFish1.Click += new System.EventHandler(this.ButtonFish1_Click);
            // 
            // buttonExclude
            // 
            this.buttonExclude.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonExclude.Location = new System.Drawing.Point(218, 160);
            this.buttonExclude.Name = "buttonExclude";
            this.buttonExclude.Size = new System.Drawing.Size(129, 33);
            this.buttonExclude.TabIndex = 5;
            this.buttonExclude.Text = "Excluded";
            this.buttonExclude.UseVisualStyleBackColor = true;
            this.buttonExclude.Click += new System.EventHandler(this.ButtonExclude_Click);
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(12, 12);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(200, 200);
            this.imageBoxFrameGrabber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBoxFrameGrabber.TabIndex = 13;
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // Trainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 224);
            this.Controls.Add(this.imageBoxFrameGrabber);
            this.Controls.Add(this.buttonExclude);
            this.Controls.Add(this.buttonFish1);
            this.Controls.Add(this.buttonFish3);
            this.Controls.Add(this.buttonFish2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Trainer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trainer";
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonFish2;
        private System.Windows.Forms.Button buttonFish3;
        private System.Windows.Forms.Button buttonFish1;
        private System.Windows.Forms.Button buttonExclude;
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
    }
}