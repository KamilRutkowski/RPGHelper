namespace RPGHelper
{
    partial class ManageSession
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
            this.labelSelectedEntity = new System.Windows.Forms.Label();
            this.menuStripManage = new System.Windows.Forms.MenuStrip();
            this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxSelectedPlayer = new System.Windows.Forms.TextBox();
            this.textBoxSelectedItem = new System.Windows.Forms.TextBox();
            this.buttonLeftArrow = new System.Windows.Forms.Button();
            this.buttonRightArrow = new System.Windows.Forms.Button();
            this.labelDatabaseSelected = new System.Windows.Forms.Label();
            this.textBoxSelectedDatabase = new System.Windows.Forms.TextBox();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.tableEntity = new System.Windows.Forms.DataGridView();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.comboBoxDBSelector = new System.Windows.Forms.ComboBox();
            this.buttonDropTheBase = new System.Windows.Forms.Button();
            this.buttonInsUp = new System.Windows.Forms.Button();
            this.buttonManageRows = new System.Windows.Forms.Button();
            this.menuStripManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableEntity)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSelectedEntity
            // 
            this.labelSelectedEntity.AutoSize = true;
            this.labelSelectedEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelSelectedEntity.Location = new System.Drawing.Point(266, 87);
            this.labelSelectedEntity.Name = "labelSelectedEntity";
            this.labelSelectedEntity.Size = new System.Drawing.Size(120, 20);
            this.labelSelectedEntity.TabIndex = 5;
            this.labelSelectedEntity.Text = "Selected Entity:";
            // 
            // menuStripManage
            // 
            this.menuStripManage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.menuStripManage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerToolStripMenuItem,
            this.itemsToolStripMenuItem,
            this.connectorToolStripMenuItem});
            this.menuStripManage.Location = new System.Drawing.Point(0, 0);
            this.menuStripManage.Name = "menuStripManage";
            this.menuStripManage.Size = new System.Drawing.Size(500, 28);
            this.menuStripManage.TabIndex = 6;
            this.menuStripManage.Text = "menuStrip1";
            // 
            // playerToolStripMenuItem
            // 
            this.playerToolStripMenuItem.Name = "playerToolStripMenuItem";
            this.playerToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.playerToolStripMenuItem.Text = "Player";
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.itemsToolStripMenuItem.Text = "Items";
            // 
            // connectorToolStripMenuItem
            // 
            this.connectorToolStripMenuItem.Name = "connectorToolStripMenuItem";
            this.connectorToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.connectorToolStripMenuItem.Text = "Connector";
            // 
            // textBoxSelectedPlayer
            // 
            this.textBoxSelectedPlayer.Enabled = false;
            this.textBoxSelectedPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSelectedPlayer.Location = new System.Drawing.Point(378, 2);
            this.textBoxSelectedPlayer.Name = "textBoxSelectedPlayer";
            this.textBoxSelectedPlayer.Size = new System.Drawing.Size(82, 26);
            this.textBoxSelectedPlayer.TabIndex = 7;
            this.textBoxSelectedPlayer.Text = "Player";
            // 
            // textBoxSelectedItem
            // 
            this.textBoxSelectedItem.Enabled = false;
            this.textBoxSelectedItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSelectedItem.Location = new System.Drawing.Point(392, 84);
            this.textBoxSelectedItem.Name = "textBoxSelectedItem";
            this.textBoxSelectedItem.Size = new System.Drawing.Size(100, 26);
            this.textBoxSelectedItem.TabIndex = 8;
            // 
            // buttonLeftArrow
            // 
            this.buttonLeftArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonLeftArrow.Location = new System.Drawing.Point(346, 3);
            this.buttonLeftArrow.Name = "buttonLeftArrow";
            this.buttonLeftArrow.Size = new System.Drawing.Size(26, 25);
            this.buttonLeftArrow.TabIndex = 9;
            this.buttonLeftArrow.Text = "<";
            this.buttonLeftArrow.UseVisualStyleBackColor = true;
            this.buttonLeftArrow.Click += new System.EventHandler(this.buttonLeftArrow_Click);
            // 
            // buttonRightArrow
            // 
            this.buttonRightArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonRightArrow.Location = new System.Drawing.Point(466, 3);
            this.buttonRightArrow.Name = "buttonRightArrow";
            this.buttonRightArrow.Size = new System.Drawing.Size(26, 25);
            this.buttonRightArrow.TabIndex = 10;
            this.buttonRightArrow.Text = ">";
            this.buttonRightArrow.UseVisualStyleBackColor = true;
            this.buttonRightArrow.Click += new System.EventHandler(this.buttonRightArrow_Click);
            // 
            // labelDatabaseSelected
            // 
            this.labelDatabaseSelected.AutoSize = true;
            this.labelDatabaseSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelDatabaseSelected.Location = new System.Drawing.Point(303, 50);
            this.labelDatabaseSelected.Name = "labelDatabaseSelected";
            this.labelDatabaseSelected.Size = new System.Drawing.Size(83, 20);
            this.labelDatabaseSelected.TabIndex = 11;
            this.labelDatabaseSelected.Text = "Database:";
            // 
            // textBoxSelectedDatabase
            // 
            this.textBoxSelectedDatabase.Enabled = false;
            this.textBoxSelectedDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSelectedDatabase.Location = new System.Drawing.Point(392, 47);
            this.textBoxSelectedDatabase.Name = "textBoxSelectedDatabase";
            this.textBoxSelectedDatabase.Size = new System.Drawing.Size(79, 26);
            this.textBoxSelectedDatabase.TabIndex = 12;
            // 
            // buttonQuit
            // 
            this.buttonQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonQuit.Location = new System.Drawing.Point(363, 544);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(129, 43);
            this.buttonQuit.TabIndex = 13;
            this.buttonQuit.Text = "Quit Manager";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // tableEntity
            // 
            this.tableEntity.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tableEntity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableEntity.Location = new System.Drawing.Point(13, 180);
            this.tableEntity.Name = "tableEntity";
            this.tableEntity.Size = new System.Drawing.Size(471, 286);
            this.tableEntity.TabIndex = 15;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Enabled = false;
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonRefresh.Location = new System.Drawing.Point(181, 140);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(119, 35);
            this.buttonRefresh.TabIndex = 16;
            this.buttonRefresh.Text = "Refresh (F5)";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // comboBoxDBSelector
            // 
            this.comboBoxDBSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBoxDBSelector.FormattingEnabled = true;
            this.comboBoxDBSelector.Location = new System.Drawing.Point(234, 0);
            this.comboBoxDBSelector.Name = "comboBoxDBSelector";
            this.comboBoxDBSelector.Size = new System.Drawing.Size(95, 28);
            this.comboBoxDBSelector.TabIndex = 25;
            this.comboBoxDBSelector.SelectedIndexChanged += new System.EventHandler(this.comboBoxDBSelector_SelectedIndexChanged);
            // 
            // buttonDropTheBase
            // 
            this.buttonDropTheBase.Enabled = false;
            this.buttonDropTheBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonDropTheBase.Location = new System.Drawing.Point(13, 481);
            this.buttonDropTheBase.Name = "buttonDropTheBase";
            this.buttonDropTheBase.Size = new System.Drawing.Size(125, 31);
            this.buttonDropTheBase.TabIndex = 26;
            this.buttonDropTheBase.Text = "Drop the Base";
            this.buttonDropTheBase.UseVisualStyleBackColor = true;
            this.buttonDropTheBase.Click += new System.EventHandler(this.buttonDropTheBase_Click);
            // 
            // buttonInsUp
            // 
            this.buttonInsUp.Enabled = false;
            this.buttonInsUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonInsUp.Location = new System.Drawing.Point(306, 140);
            this.buttonInsUp.Name = "buttonInsUp";
            this.buttonInsUp.Size = new System.Drawing.Size(154, 35);
            this.buttonInsUp.TabIndex = 27;
            this.buttonInsUp.Text = "Insert/Update (F6)";
            this.buttonInsUp.UseVisualStyleBackColor = true;
            this.buttonInsUp.Click += new System.EventHandler(this.buttonInsUp_Click);
            // 
            // buttonManageRows
            // 
            this.buttonManageRows.Enabled = false;
            this.buttonManageRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonManageRows.Location = new System.Drawing.Point(13, 140);
            this.buttonManageRows.Name = "buttonManageRows";
            this.buttonManageRows.Size = new System.Drawing.Size(162, 34);
            this.buttonManageRows.TabIndex = 28;
            this.buttonManageRows.Text = "Manage Rows (F4)";
            this.buttonManageRows.UseVisualStyleBackColor = true;
            this.buttonManageRows.Click += new System.EventHandler(this.buttonManageRows_Click);
            // 
            // ManageSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonManageRows);
            this.Controls.Add(this.buttonInsUp);
            this.Controls.Add(this.buttonDropTheBase);
            this.Controls.Add(this.comboBoxDBSelector);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.tableEntity);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.textBoxSelectedDatabase);
            this.Controls.Add(this.labelDatabaseSelected);
            this.Controls.Add(this.buttonRightArrow);
            this.Controls.Add(this.buttonLeftArrow);
            this.Controls.Add(this.textBoxSelectedItem);
            this.Controls.Add(this.textBoxSelectedPlayer);
            this.Controls.Add(this.labelSelectedEntity);
            this.Controls.Add(this.menuStripManage);
            this.MaximumSize = new System.Drawing.Size(500, 600);
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "ManageSession";
            this.Size = new System.Drawing.Size(500, 600);
            this.Load += new System.EventHandler(this.ManageSession_Load);
            this.menuStripManage.ResumeLayout(false);
            this.menuStripManage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableEntity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSelectedEntity;
        private System.Windows.Forms.MenuStrip menuStripManage;
        private System.Windows.Forms.ToolStripMenuItem playerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxSelectedPlayer;
        private System.Windows.Forms.TextBox textBoxSelectedItem;
        private System.Windows.Forms.Button buttonLeftArrow;
        private System.Windows.Forms.Button buttonRightArrow;
        private System.Windows.Forms.Label labelDatabaseSelected;
        private System.Windows.Forms.TextBox textBoxSelectedDatabase;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.DataGridView tableEntity;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ComboBox comboBoxDBSelector;
        private System.Windows.Forms.Button buttonDropTheBase;
        private System.Windows.Forms.Button buttonInsUp;
        private System.Windows.Forms.Button buttonManageRows;
        private System.Windows.Forms.ToolStripMenuItem connectorToolStripMenuItem;
    }
}
