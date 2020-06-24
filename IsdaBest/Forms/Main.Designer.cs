namespace IsdaBest.Forms
{
    partial class Main
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonClassify = new System.Windows.Forms.Button();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.buttonGenModel = new System.Windows.Forms.Button();
            this.textBoxlog = new System.Windows.Forms.TextBox();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonClassify
            // 
            this.buttonClassify.AutoSize = true;
            this.buttonClassify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonClassify.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClassify.Location = new System.Drawing.Point(480, 315);
            this.buttonClassify.Name = "buttonClassify";
            this.buttonClassify.Size = new System.Drawing.Size(84, 25);
            this.buttonClassify.TabIndex = 8;
            this.buttonClassify.Text = "Start Classify";
            this.buttonClassify.UseVisualStyleBackColor = true;
            this.buttonClassify.Click += new System.EventHandler(this.ButtonClassify_Click);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.AutoSize = true;
            this.buttonOpenFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOpenFile.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenFile.Location = new System.Drawing.Point(398, 315);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(76, 25);
            this.buttonOpenFile.TabIndex = 7;
            this.buttonOpenFile.Text = "Browse File";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.ButtonOpenFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(170, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(336, 37);
            this.label2.TabIndex = 5;
            this.label2.Text = "Classifying and Counting";
            // 
            // textBoxFile
            // 
            this.textBoxFile.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFile.Location = new System.Drawing.Point(16, 316);
            this.textBoxFile.Multiline = true;
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(376, 23);
            this.textBoxFile.TabIndex = 9;
            // 
            // buttonGenModel
            // 
            this.buttonGenModel.AutoSize = true;
            this.buttonGenModel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonGenModel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenModel.Location = new System.Drawing.Point(570, 315);
            this.buttonGenModel.Name = "buttonGenModel";
            this.buttonGenModel.Size = new System.Drawing.Size(101, 25);
            this.buttonGenModel.TabIndex = 10;
            this.buttonGenModel.Text = "Generate Model";
            this.buttonGenModel.UseVisualStyleBackColor = true;
            this.buttonGenModel.Click += new System.EventHandler(this.ButtonGenModel_Click);
            // 
            // textBoxlog
            // 
            this.textBoxlog.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxlog.Location = new System.Drawing.Point(16, 49);
            this.textBoxlog.Multiline = true;
            this.textBoxlog.Name = "textBoxlog";
            this.textBoxlog.ReadOnly = true;
            this.textBoxlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxlog.Size = new System.Drawing.Size(655, 260);
            this.textBoxlog.TabIndex = 11;
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearLog.Location = new System.Drawing.Point(593, 16);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(78, 33);
            this.buttonClearLog.TabIndex = 12;
            this.buttonClearLog.Text = "Clear Log";
            this.buttonClearLog.UseVisualStyleBackColor = true;
            this.buttonClearLog.Click += new System.EventHandler(this.ButtonClearLog_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 351);
            this.Controls.Add(this.buttonClearLog);
            this.Controls.Add(this.textBoxlog);
            this.Controls.Add(this.buttonGenModel);
            this.Controls.Add(this.buttonClassify);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFile);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Isda Best";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonClassify;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.Button buttonGenModel;
        private System.Windows.Forms.TextBox textBoxlog;
        private System.Windows.Forms.Button buttonClearLog;
    }
}