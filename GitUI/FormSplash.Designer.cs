﻿namespace GitUI
{
    partial class FormSplash
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this._version = new System.Windows.Forms.Label();
            this._programTitle = new System.Windows.Forms.Label();
            this._actionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GitUI.Properties.Resources.Cow;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this._version);
            this.panel1.Controls.Add(this._programTitle);
            this.panel1.Controls.Add(this._actionLabel);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 128);
            this.panel1.TabIndex = 1;
            // 
            // _version
            // 
            this._version.AutoSize = true;
            this._version.Location = new System.Drawing.Point(134, 30);
            this._version.Name = "_version";
            this._version.Size = new System.Drawing.Size(59, 13);
            this._version.TabIndex = 3;
            this._version.Text = "Version {0}";
            // 
            // _programTitle
            // 
            this._programTitle.AutoSize = true;
            this._programTitle.Location = new System.Drawing.Point(134, 8);
            this._programTitle.Name = "_programTitle";
            this._programTitle.Size = new System.Drawing.Size(99, 15);
            this._programTitle.TabIndex = 2;
            this._programTitle.Text = "Git Extensions";
            // 
            // _actionLabel
            // 
            this._actionLabel.AutoSize = true;
            this._actionLabel.Location = new System.Drawing.Point(134, 104);
            this._actionLabel.Name = "_actionLabel";
            this._actionLabel.Size = new System.Drawing.Size(54, 13);
            this._actionLabel.TabIndex = 1;
            this._actionLabel.Text = "Loading...";
            // 
            // FormSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(256, 128);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _programTitle;
        private System.Windows.Forms.Label _actionLabel;
        private System.Windows.Forms.Label _version;
    }
}