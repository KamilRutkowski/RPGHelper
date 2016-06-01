namespace RPGHelper
{
    partial class DatabaseRelationsCreator
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
            this.buttonReturnToNameCreation = new System.Windows.Forms.Button();
            this.buttonCreateDatabase = new System.Windows.Forms.Button();
            this.buttonStopCreation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonReturnToNameCreation);
            this.splitContainer1.Panel2.Controls.Add(this.buttonCreateDatabase);
            this.splitContainer1.Panel2.Controls.Add(this.buttonStopCreation);
            this.splitContainer1.Size = new System.Drawing.Size(500, 600);
            this.splitContainer1.SplitterDistance = 533;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonReturnToNameCreation
            // 
            this.buttonReturnToNameCreation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonReturnToNameCreation.Location = new System.Drawing.Point(3, 14);
            this.buttonReturnToNameCreation.Name = "buttonReturnToNameCreation";
            this.buttonReturnToNameCreation.Size = new System.Drawing.Size(142, 35);
            this.buttonReturnToNameCreation.TabIndex = 15;
            this.buttonReturnToNameCreation.Text = "Poprzedni krok";
            this.buttonReturnToNameCreation.UseVisualStyleBackColor = true;
            this.buttonReturnToNameCreation.Click += new System.EventHandler(this.buttonReturnToNameCreation_Click);
            // 
            // buttonCreateDatabase
            // 
            this.buttonCreateDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonCreateDatabase.Location = new System.Drawing.Point(355, 14);
            this.buttonCreateDatabase.Name = "buttonCreateDatabase";
            this.buttonCreateDatabase.Size = new System.Drawing.Size(142, 35);
            this.buttonCreateDatabase.TabIndex = 14;
            this.buttonCreateDatabase.Text = "Zakończ kreację";
            this.buttonCreateDatabase.UseVisualStyleBackColor = true;
            this.buttonCreateDatabase.Click += new System.EventHandler(this.buttonCreateDatabase_Click);
            // 
            // buttonStopCreation
            // 
            this.buttonStopCreation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonStopCreation.Location = new System.Drawing.Point(180, 14);
            this.buttonStopCreation.Name = "buttonStopCreation";
            this.buttonStopCreation.Size = new System.Drawing.Size(142, 35);
            this.buttonStopCreation.TabIndex = 13;
            this.buttonStopCreation.Text = "Przerwij kreację";
            this.buttonStopCreation.UseVisualStyleBackColor = true;
            this.buttonStopCreation.Click += new System.EventHandler(this.buttonStopCreation_Click);
            // 
            // DatabaseRelationsCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.MaximumSize = new System.Drawing.Size(500, 600);
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "DatabaseRelationsCreator";
            this.Size = new System.Drawing.Size(500, 600);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonReturnToNameCreation;
        private System.Windows.Forms.Button buttonCreateDatabase;
        private System.Windows.Forms.Button buttonStopCreation;
    }
}
