﻿namespace RPGHelper
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
            this.buttonSaveSession = new System.Windows.Forms.Button();
            this.labelSelectedEntity = new System.Windows.Forms.Label();
            this.menuStripManage = new System.Windows.Forms.MenuStrip();
            this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxSelectedPlayer = new System.Windows.Forms.TextBox();
            this.textBoxSelectedEntity = new System.Windows.Forms.TextBox();
            this.buttonLeftArrow = new System.Windows.Forms.Button();
            this.buttonRightArrow = new System.Windows.Forms.Button();
            this.labelDatabaseSelected = new System.Windows.Forms.Label();
            this.textBoxSelectedDatabase = new System.Windows.Forms.TextBox();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonSaveQuit = new System.Windows.Forms.Button();
            this.menuStripManage.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSaveSession
            // 
            this.buttonSaveSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonSaveSession.Location = new System.Drawing.Point(370, 544);
            this.buttonSaveSession.Name = "buttonSaveSession";
            this.buttonSaveSession.Size = new System.Drawing.Size(127, 43);
            this.buttonSaveSession.TabIndex = 1;
            this.buttonSaveSession.Text = "Save Session";
            this.buttonSaveSession.UseVisualStyleBackColor = true;
            this.buttonSaveSession.Click += new System.EventHandler(this.buttonSaveSession_Click);
            // 
            // labelSelectedEntity
            // 
            this.labelSelectedEntity.AutoSize = true;
            this.labelSelectedEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelSelectedEntity.Location = new System.Drawing.Point(270, 63);
            this.labelSelectedEntity.Name = "labelSelectedEntity";
            this.labelSelectedEntity.Size = new System.Drawing.Size(116, 20);
            this.labelSelectedEntity.TabIndex = 5;
            this.labelSelectedEntity.Text = "Selected Entity";
            // 
            // menuStripManage
            // 
            this.menuStripManage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.menuStripManage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerToolStripMenuItem,
            this.itemsToolStripMenuItem});
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
            // textBoxSelectedPlayer
            // 
            this.textBoxSelectedPlayer.Enabled = false;
            this.textBoxSelectedPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSelectedPlayer.Location = new System.Drawing.Point(360, 2);
            this.textBoxSelectedPlayer.Name = "textBoxSelectedPlayer";
            this.textBoxSelectedPlayer.Size = new System.Drawing.Size(100, 26);
            this.textBoxSelectedPlayer.TabIndex = 7;
            this.textBoxSelectedPlayer.Text = "Player";
            // 
            // textBoxSelectedEntity
            // 
            this.textBoxSelectedEntity.Enabled = false;
            this.textBoxSelectedEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSelectedEntity.Location = new System.Drawing.Point(392, 60);
            this.textBoxSelectedEntity.Name = "textBoxSelectedEntity";
            this.textBoxSelectedEntity.Size = new System.Drawing.Size(100, 26);
            this.textBoxSelectedEntity.TabIndex = 8;
            // 
            // buttonLeftArrow
            // 
            this.buttonLeftArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonLeftArrow.Location = new System.Drawing.Point(328, 3);
            this.buttonLeftArrow.Name = "buttonLeftArrow";
            this.buttonLeftArrow.Size = new System.Drawing.Size(26, 25);
            this.buttonLeftArrow.TabIndex = 9;
            this.buttonLeftArrow.Text = "<";
            this.buttonLeftArrow.UseVisualStyleBackColor = true;
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
            // 
            // labelDatabaseSelected
            // 
            this.labelDatabaseSelected.AutoSize = true;
            this.labelDatabaseSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelDatabaseSelected.Location = new System.Drawing.Point(136, 5);
            this.labelDatabaseSelected.Name = "labelDatabaseSelected";
            this.labelDatabaseSelected.Size = new System.Drawing.Size(83, 20);
            this.labelDatabaseSelected.TabIndex = 11;
            this.labelDatabaseSelected.Text = "Database:";
            // 
            // textBoxSelectedDatabase
            // 
            this.textBoxSelectedDatabase.Enabled = false;
            this.textBoxSelectedDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSelectedDatabase.Location = new System.Drawing.Point(216, 3);
            this.textBoxSelectedDatabase.Name = "textBoxSelectedDatabase";
            this.textBoxSelectedDatabase.Size = new System.Drawing.Size(79, 26);
            this.textBoxSelectedDatabase.TabIndex = 12;
            // 
            // buttonQuit
            // 
            this.buttonQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonQuit.Location = new System.Drawing.Point(13, 544);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(162, 43);
            this.buttonQuit.TabIndex = 13;
            this.buttonQuit.Text = "Quit Without Saving";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonSaveQuit
            // 
            this.buttonSaveQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonSaveQuit.Location = new System.Drawing.Point(192, 544);
            this.buttonSaveQuit.Name = "buttonSaveQuit";
            this.buttonSaveQuit.Size = new System.Drawing.Size(162, 43);
            this.buttonSaveQuit.TabIndex = 14;
            this.buttonSaveQuit.Text = "Save and Quit";
            this.buttonSaveQuit.UseVisualStyleBackColor = true;
            this.buttonSaveQuit.Click += new System.EventHandler(this.buttonSaveQuit_Click);
            // 
            // ManageSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSaveQuit);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.textBoxSelectedDatabase);
            this.Controls.Add(this.labelDatabaseSelected);
            this.Controls.Add(this.buttonRightArrow);
            this.Controls.Add(this.buttonLeftArrow);
            this.Controls.Add(this.textBoxSelectedEntity);
            this.Controls.Add(this.textBoxSelectedPlayer);
            this.Controls.Add(this.labelSelectedEntity);
            this.Controls.Add(this.buttonSaveSession);
            this.Controls.Add(this.menuStripManage);
            this.MaximumSize = new System.Drawing.Size(500, 600);
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "ManageSession";
            this.Size = new System.Drawing.Size(500, 600);
            this.Load += new System.EventHandler(this.ManageSession_Load);
            this.menuStripManage.ResumeLayout(false);
            this.menuStripManage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveSession;
        private System.Windows.Forms.Label labelSelectedEntity;
        private System.Windows.Forms.MenuStrip menuStripManage;
        private System.Windows.Forms.ToolStripMenuItem playerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxSelectedPlayer;
        private System.Windows.Forms.TextBox textBoxSelectedEntity;
        private System.Windows.Forms.Button buttonLeftArrow;
        private System.Windows.Forms.Button buttonRightArrow;
        private System.Windows.Forms.Label labelDatabaseSelected;
        private System.Windows.Forms.TextBox textBoxSelectedDatabase;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonSaveQuit;
    }
}
