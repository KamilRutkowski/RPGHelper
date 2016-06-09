namespace RPGHelper
{
    partial class DatabaseTablesCreator
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonAddColumn = new System.Windows.Forms.Button();
            this.buttonReturnToNameCreation = new System.Windows.Forms.Button();
            this.buttonNextStep = new System.Windows.Forms.Button();
            this.buttonStopCreation = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.AutoScrollMinSize = new System.Drawing.Size(10, 0);
            this.splitContainer1.Panel1.Controls.Add(this.buttonAddColumn);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonReturnToNameCreation);
            this.splitContainer1.Panel2.Controls.Add(this.buttonNextStep);
            this.splitContainer1.Panel2.Controls.Add(this.buttonStopCreation);
            this.splitContainer1.Size = new System.Drawing.Size(550, 600);
            this.splitContainer1.SplitterDistance = 536;
            this.splitContainer1.TabIndex = 9;
            // 
            // buttonAddColumn
            // 
            this.buttonAddColumn.Location = new System.Drawing.Point(3, 27);
            this.buttonAddColumn.Name = "buttonAddColumn";
            this.buttonAddColumn.Size = new System.Drawing.Size(100, 23);
            this.buttonAddColumn.TabIndex = 2;
            this.buttonAddColumn.Text = "Add Column";
            this.buttonAddColumn.UseVisualStyleBackColor = true;
            this.buttonAddColumn.Click += new System.EventHandler(this.buttonAddColumn_Click);
            // 
            // buttonReturnToNameCreation
            // 
            this.buttonReturnToNameCreation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonReturnToNameCreation.Location = new System.Drawing.Point(28, 13);
            this.buttonReturnToNameCreation.Name = "buttonReturnToNameCreation";
            this.buttonReturnToNameCreation.Size = new System.Drawing.Size(142, 35);
            this.buttonReturnToNameCreation.TabIndex = 14;
            this.buttonReturnToNameCreation.Text = "Previous step";
            this.buttonReturnToNameCreation.UseVisualStyleBackColor = true;
            this.buttonReturnToNameCreation.Click += new System.EventHandler(this.buttonReturnToNameCreation_Click);
            // 
            // buttonNextStep
            // 
            this.buttonNextStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonNextStep.Location = new System.Drawing.Point(380, 13);
            this.buttonNextStep.Name = "buttonNextStep";
            this.buttonNextStep.Size = new System.Drawing.Size(142, 35);
            this.buttonNextStep.TabIndex = 13;
            this.buttonNextStep.Text = "Next step";
            this.buttonNextStep.UseVisualStyleBackColor = true;
            this.buttonNextStep.Click += new System.EventHandler(this.buttonNextStep_Click);
            // 
            // buttonStopCreation
            // 
            this.buttonStopCreation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonStopCreation.Location = new System.Drawing.Point(205, 13);
            this.buttonStopCreation.Name = "buttonStopCreation";
            this.buttonStopCreation.Size = new System.Drawing.Size(142, 35);
            this.buttonStopCreation.TabIndex = 12;
            this.buttonStopCreation.Text = "Stop creation";
            this.buttonStopCreation.UseVisualStyleBackColor = true;
            this.buttonStopCreation.Click += new System.EventHandler(this.buttonStopCreation_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerToolStripMenuItem,
            this.itemsToolStripMenuItem,
            this.tablesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(550, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // playerToolStripMenuItem
            // 
            this.playerToolStripMenuItem.Name = "playerToolStripMenuItem";
            this.playerToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.playerToolStripMenuItem.Text = "Player";
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.itemsToolStripMenuItem.Text = "Items";
            // 
            // tablesToolStripMenuItem
            // 
            this.tablesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createTableToolStripMenuItem,
            this.removeTableToolStripMenuItem});
            this.tablesToolStripMenuItem.Name = "tablesToolStripMenuItem";
            this.tablesToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.tablesToolStripMenuItem.Text = "Tables";
            // 
            // createTableToolStripMenuItem
            // 
            this.createTableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerTableToolStripMenuItem,
            this.itemsTableToolStripMenuItem});
            this.createTableToolStripMenuItem.Name = "createTableToolStripMenuItem";
            this.createTableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.createTableToolStripMenuItem.Text = "Create table";
            // 
            // playerTableToolStripMenuItem
            // 
            this.playerTableToolStripMenuItem.Name = "playerTableToolStripMenuItem";
            this.playerTableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.playerTableToolStripMenuItem.Text = "Player table";
            this.playerTableToolStripMenuItem.Click += new System.EventHandler(this.playerTableToolStripMenuItem_Click);
            // 
            // itemsTableToolStripMenuItem
            // 
            this.itemsTableToolStripMenuItem.Name = "itemsTableToolStripMenuItem";
            this.itemsTableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.itemsTableToolStripMenuItem.Text = "Items table";
            this.itemsTableToolStripMenuItem.Click += new System.EventHandler(this.itemsTableToolStripMenuItem_Click);
            // 
            // removeTableToolStripMenuItem
            // 
            this.removeTableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerTablesToolStripMenuItem,
            this.itemsTablesToolStripMenuItem});
            this.removeTableToolStripMenuItem.Name = "removeTableToolStripMenuItem";
            this.removeTableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeTableToolStripMenuItem.Text = "Remove table";
            // 
            // playerTablesToolStripMenuItem
            // 
            this.playerTablesToolStripMenuItem.Name = "playerTablesToolStripMenuItem";
            this.playerTablesToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.playerTablesToolStripMenuItem.Text = "Player tables";
            // 
            // itemsTablesToolStripMenuItem
            // 
            this.itemsTablesToolStripMenuItem.Name = "itemsTablesToolStripMenuItem";
            this.itemsTablesToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.itemsTablesToolStripMenuItem.Text = "Items tables";
            // 
            // DatabaseTablesCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.MaximumSize = new System.Drawing.Size(550, 600);
            this.MinimumSize = new System.Drawing.Size(550, 600);
            this.Name = "DatabaseTablesCreator";
            this.Size = new System.Drawing.Size(550, 600);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonReturnToNameCreation;
        private System.Windows.Forms.Button buttonNextStep;
        private System.Windows.Forms.Button buttonStopCreation;
        private System.Windows.Forms.Button buttonAddColumn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem playerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerTablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsTablesToolStripMenuItem;
    }
}
