namespace GitUI.UserControls
{
    partial class StashTreeView
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
            this.StashTree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // StashTree
            // 
            this.StashTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StashTree.Location = new System.Drawing.Point(0, 0);
            this.StashTree.Name = "StashTree";
            this.StashTree.Size = new System.Drawing.Size(150, 150);
            this.StashTree.TabIndex = 0;
            // 
            // StashTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StashTree);
            this.Name = "StashTreeView";
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.TreeView StashTree;
    }
}
