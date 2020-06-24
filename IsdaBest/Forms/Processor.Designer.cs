namespace IsdaBest.Forms
{
    partial class Processor
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
            this.imageBoxFrameGrabber1 = new Emgu.CV.UI.ImageBox();
            this.imageBoxFrameGrabber2 = new Emgu.CV.UI.ImageBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelCParrot = new System.Windows.Forms.Label();
            this.labelCRabbit = new System.Windows.Forms.Label();
            this.labelCSergeant = new System.Windows.Forms.Label();
            this.buttonCap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageBoxFrameGrabber1
            // 
            this.imageBoxFrameGrabber1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBoxFrameGrabber1.Location = new System.Drawing.Point(12, 12);
            this.imageBoxFrameGrabber1.Name = "imageBoxFrameGrabber1";
            this.imageBoxFrameGrabber1.Size = new System.Drawing.Size(350, 270);
            this.imageBoxFrameGrabber1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxFrameGrabber1.TabIndex = 12;
            this.imageBoxFrameGrabber1.TabStop = false;
            // 
            // imageBoxFrameGrabber2
            // 
            this.imageBoxFrameGrabber2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber2.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBoxFrameGrabber2.Location = new System.Drawing.Point(368, 12);
            this.imageBoxFrameGrabber2.Name = "imageBoxFrameGrabber2";
            this.imageBoxFrameGrabber2.Size = new System.Drawing.Size(350, 270);
            this.imageBoxFrameGrabber2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxFrameGrabber2.TabIndex = 15;
            this.imageBoxFrameGrabber2.TabStop = false;
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(509, 369);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(88, 33);
            this.buttonExit.TabIndex = 17;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // labelCParrot
            // 
            this.labelCParrot.AutoSize = true;
            this.labelCParrot.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCParrot.Location = new System.Drawing.Point(13, 9);
            this.labelCParrot.Name = "labelCParrot";
            this.labelCParrot.Size = new System.Drawing.Size(59, 21);
            this.labelCParrot.TabIndex = 18;
            this.labelCParrot.Text = "Parrot:";
            // 
            // labelCRabbit
            // 
            this.labelCRabbit.AutoSize = true;
            this.labelCRabbit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCRabbit.Location = new System.Drawing.Point(13, 30);
            this.labelCRabbit.Name = "labelCRabbit";
            this.labelCRabbit.Size = new System.Drawing.Size(62, 21);
            this.labelCRabbit.TabIndex = 19;
            this.labelCRabbit.Text = "Rabbit:";
            // 
            // labelCSergeant
            // 
            this.labelCSergeant.AutoSize = true;
            this.labelCSergeant.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCSergeant.Location = new System.Drawing.Point(13, 51);
            this.labelCSergeant.Name = "labelCSergeant";
            this.labelCSergeant.Size = new System.Drawing.Size(80, 21);
            this.labelCSergeant.TabIndex = 20;
            this.labelCSergeant.Text = "Sergeant:";
            // 
            // buttonCap
            // 
            this.buttonCap.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCap.Location = new System.Drawing.Point(493, 321);
            this.buttonCap.Name = "buttonCap";
            this.buttonCap.Size = new System.Drawing.Size(116, 33);
            this.buttonCap.TabIndex = 24;
            this.buttonCap.Text = "Train Frame";
            this.buttonCap.UseVisualStyleBackColor = true;
            this.buttonCap.Click += new System.EventHandler(this.ButtonCap_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelCParrot);
            this.panel1.Controls.Add(this.labelCSergeant);
            this.panel1.Controls.Add(this.labelCRabbit);
            this.panel1.Location = new System.Drawing.Point(85, 323);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 84);
            this.panel1.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(81, 299);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 21);
            this.label7.TabIndex = 21;
            this.label7.Text = "Frame Classification Count";
            // 
            // Processor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(731, 434);
            this.Controls.Add(this.buttonCap);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.imageBoxFrameGrabber2);
            this.Controls.Add(this.imageBoxFrameGrabber1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Processor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Isda Best";
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber1;
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelCParrot;
        private System.Windows.Forms.Label labelCRabbit;
        private System.Windows.Forms.Label labelCSergeant;
        private System.Windows.Forms.Button buttonCap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
    }
}