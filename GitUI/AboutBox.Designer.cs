﻿namespace GitUI
{
    partial class AboutBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this._NO_TRANSLATE_labelCopyright = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this._NO_TRANSLATE_labelVersionInfo = new System.Windows.Forms.Label();
            this.pictureDonate = new System.Windows.Forms.PictureBox();
            this._NO_TRANSLATE_labelProductName = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDonate)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this._NO_TRANSLATE_labelCopyright, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 4);
            this.tableLayoutPanel.Controls.Add(this._NO_TRANSLATE_labelVersionInfo, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.pictureDonate, 1, 0);
            this.tableLayoutPanel.Controls.Add(this._NO_TRANSLATE_labelProductName, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.okButton, 1, 5);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.4717F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.792453F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.169811F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(417, 265);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPictureBox.Image = global::GitUI.Properties.Resources.Cow1;
            this.logoPictureBox.Location = new System.Drawing.Point(3, 3);
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
            this.logoPictureBox.Size = new System.Drawing.Size(131, 259);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // _NO_TRANSLATE_labelCopyright
            // 
            this._NO_TRANSLATE_labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this._NO_TRANSLATE_labelCopyright.Location = new System.Drawing.Point(143, 59);
            this._NO_TRANSLATE_labelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this._NO_TRANSLATE_labelCopyright.MaximumSize = new System.Drawing.Size(0, 17);
            this._NO_TRANSLATE_labelCopyright.Name = "_NO_TRANSLATE_labelCopyright";
            this._NO_TRANSLATE_labelCopyright.Size = new System.Drawing.Size(271, 17);
            this._NO_TRANSLATE_labelCopyright.TabIndex = 21;
            this._NO_TRANSLATE_labelCopyright.Text = "Henk Westhuis (henk_westhuis@hotmail.com)";
            this._NO_TRANSLATE_labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(143, 107);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDescription.Size = new System.Drawing.Size(271, 127);
            this.textBoxDescription.TabIndex = 23;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = resources.GetString("textBoxDescription.Text");
            // 
            // _NO_TRANSLATE_labelVersionInfo
            // 
            this._NO_TRANSLATE_labelVersionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._NO_TRANSLATE_labelVersionInfo.Location = new System.Drawing.Point(143, 41);
            this._NO_TRANSLATE_labelVersionInfo.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this._NO_TRANSLATE_labelVersionInfo.MaximumSize = new System.Drawing.Size(0, 17);
            this._NO_TRANSLATE_labelVersionInfo.Name = "_NO_TRANSLATE_labelVersionInfo";
            this._NO_TRANSLATE_labelVersionInfo.Size = new System.Drawing.Size(271, 17);
            this._NO_TRANSLATE_labelVersionInfo.TabIndex = 0;
            this._NO_TRANSLATE_labelVersionInfo.Text = "Version ";
            this._NO_TRANSLATE_labelVersionInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._NO_TRANSLATE_labelVersionInfo.Click += new System.EventHandler(this.labelVersion_Click);
            // 
            // pictureDonate
            // 
            this.pictureDonate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureDonate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureDonate.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureDonate.Image = global::GitUI.Properties.Resources.Donate;
            this.pictureDonate.Location = new System.Drawing.Point(316, 3);
            this.pictureDonate.Name = "pictureDonate";
            this.pictureDonate.Size = new System.Drawing.Size(98, 35);
            this.pictureDonate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureDonate.TabIndex = 25;
            this.pictureDonate.TabStop = false;
            this.pictureDonate.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // _NO_TRANSLATE_labelProductName
            // 
            this._NO_TRANSLATE_labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this._NO_TRANSLATE_labelProductName.Location = new System.Drawing.Point(143, 78);
            this._NO_TRANSLATE_labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this._NO_TRANSLATE_labelProductName.MaximumSize = new System.Drawing.Size(0, 17);
            this._NO_TRANSLATE_labelProductName.Name = "_NO_TRANSLATE_labelProductName";
            this._NO_TRANSLATE_labelProductName.Size = new System.Drawing.Size(271, 17);
            this._NO_TRANSLATE_labelProductName.TabIndex = 19;
            this._NO_TRANSLATE_labelProductName.Text = "Git extensions";
            this._NO_TRANSLATE_labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(339, 240);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 22);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // AboutBox
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 283);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.AboutBox_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDonate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label _NO_TRANSLATE_labelProductName;
        private System.Windows.Forms.Label _NO_TRANSLATE_labelVersionInfo;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label _NO_TRANSLATE_labelCopyright;
        private System.Windows.Forms.PictureBox pictureDonate;
    }
}
