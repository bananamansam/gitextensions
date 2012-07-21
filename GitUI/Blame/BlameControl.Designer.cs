﻿namespace GitUI.Blame
{
    partial class BlameControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.commitInfo = new GitUI.CommitInfo();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.BlameCommitter = new GitUI.Editor.FileViewer();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyLogMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.blamePreviousRevisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BlameFile = new GitUI.Editor.FileViewer();
            this.blameTooltip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.commitInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(858, 740);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.TabIndex = 7;
            // 
            // commitInfo
            // 
            this.commitInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.commitInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commitInfo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.commitInfo.Location = new System.Drawing.Point(0, 0);
            this.commitInfo.Margin = new System.Windows.Forms.Padding(4);
            this.commitInfo.Name = "commitInfo";
            this.commitInfo.Size = new System.Drawing.Size(858, 180);
            this.commitInfo.TabIndex = 5;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.BlameCommitter);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.BlameFile);
            this.splitContainer2.Size = new System.Drawing.Size(858, 556);
            this.splitContainer2.SplitterDistance = 186;
            this.splitContainer2.TabIndex = 0;
            // 
            // BlameCommitter
            // 
            this.BlameCommitter.ContextMenuStrip = this.contextMenu;
            this.BlameCommitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BlameCommitter.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.BlameCommitter.IsReadOnly = false;
            this.BlameCommitter.Location = new System.Drawing.Point(0, 0);
            this.BlameCommitter.Margin = new System.Windows.Forms.Padding(4);
            this.BlameCommitter.Name = "BlameCommitter";
            this.BlameCommitter.Size = new System.Drawing.Size(184, 554);
            this.BlameCommitter.TabIndex = 5;
            this.BlameCommitter.TabStop = false;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyLogMessageToolStripMenuItem,
            this.toolStripSeparator1,
            this.blamePreviousRevisionToolStripMenuItem,
            this.showChangesToolStripMenuItem});
            this.contextMenu.Name = "ContextMenu";
            this.contextMenu.Size = new System.Drawing.Size(239, 98);
            this.contextMenu.Opened += new System.EventHandler(this.contextMenu_Opened);
            // 
            // copyLogMessageToolStripMenuItem
            // 
            this.copyLogMessageToolStripMenuItem.Name = "copyLogMessageToolStripMenuItem";
            this.copyLogMessageToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.copyLogMessageToolStripMenuItem.Text = "Copy log message to clipboard";
            this.copyLogMessageToolStripMenuItem.Click += new System.EventHandler(this.copyLogMessageToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(235, 6);
            // 
            // blamePreviousRevisionToolStripMenuItem
            // 
            this.blamePreviousRevisionToolStripMenuItem.Name = "blamePreviousRevisionToolStripMenuItem";
            this.blamePreviousRevisionToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.blamePreviousRevisionToolStripMenuItem.Text = "Blame previous revision";
            this.blamePreviousRevisionToolStripMenuItem.Click += new System.EventHandler(this.blamePreviousRevisionToolStripMenuItem_Click);
            // 
            // showChangesToolStripMenuItem
            // 
            this.showChangesToolStripMenuItem.Name = "showChangesToolStripMenuItem";
            this.showChangesToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.showChangesToolStripMenuItem.Text = "Show changes";
            this.showChangesToolStripMenuItem.Click += new System.EventHandler(this.showChangesToolStripMenuItem_Click);
            // 
            // BlameFile
            // 
            this.BlameFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BlameFile.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.BlameFile.IsReadOnly = false;
            this.BlameFile.Location = new System.Drawing.Point(0, 0);
            this.BlameFile.Margin = new System.Windows.Forms.Padding(4);
            this.BlameFile.Name = "BlameFile";
            this.BlameFile.Size = new System.Drawing.Size(666, 554);
            this.BlameFile.TabIndex = 0;
            // 
            // BlameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BlameControl";
            this.Size = new System.Drawing.Size(858, 740);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private CommitInfo commitInfo;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private GitUI.Editor.FileViewer BlameCommitter;
        private GitUI.Editor.FileViewer BlameFile;
        private System.Windows.Forms.ToolTip blameTooltip;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyLogMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem blamePreviousRevisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showChangesToolStripMenuItem;
    }
}
