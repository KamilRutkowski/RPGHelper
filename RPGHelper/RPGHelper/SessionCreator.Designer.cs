namespace RPGHelper
{
    partial class SessionCreator
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTableToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerToolStripMenuItem,
            this.itemsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(500, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // playerToolStripMenuItem
            // 
            this.playerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewTableToolStripMenuItem});
            this.playerToolStripMenuItem.Name = "playerToolStripMenuItem";
            this.playerToolStripMenuItem.Size = new System.Drawing.Size(77, 32);
            this.playerToolStripMenuItem.Text = "Player";
            // 
            // addNewTableToolStripMenuItem
            // 
            this.addNewTableToolStripMenuItem.Name = "addNewTableToolStripMenuItem";
            this.addNewTableToolStripMenuItem.Size = new System.Drawing.Size(210, 32);
            this.addNewTableToolStripMenuItem.Text = "Add new table";
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewTableToolStripMenuItem1});
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(71, 32);
            this.itemsToolStripMenuItem.Text = "Items";
            // 
            // addNewTableToolStripMenuItem1
            // 
            this.addNewTableToolStripMenuItem1.Name = "addNewTableToolStripMenuItem1";
            this.addNewTableToolStripMenuItem1.Size = new System.Drawing.Size(211, 32);
            this.addNewTableToolStripMenuItem1.Text = "Add new Table";
            // 
            // SessionCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.MaximumSize = new System.Drawing.Size(500, 600);
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "SessionCreator";
            this.Size = new System.Drawing.Size(500, 600);
            this.Load += new System.EventHandler(this.SessionCreator_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem playerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewTableToolStripMenuItem1;
    }
}
