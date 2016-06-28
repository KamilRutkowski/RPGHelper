namespace RPGHelper
{
    partial class DataBaseNameSelector
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
            this.labelSelectDatabase = new System.Windows.Forms.Label();
            this.comboBoxSelectDatabase = new System.Windows.Forms.ComboBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonToManage = new System.Windows.Forms.Button();
            this.labelSelectedDatabase = new System.Windows.Forms.Label();
            this.textBoxSelectedDatabase = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelSelectDatabase
            // 
            this.labelSelectDatabase.AutoSize = true;
            this.labelSelectDatabase.Location = new System.Drawing.Point(114, 210);
            this.labelSelectDatabase.Name = "labelSelectDatabase";
            this.labelSelectDatabase.Size = new System.Drawing.Size(77, 13);
            this.labelSelectDatabase.TabIndex = 0;
            this.labelSelectDatabase.Text = "Select Session";
            // 
            // comboBoxSelectDatabase
            // 
            this.comboBoxSelectDatabase.FormattingEnabled = true;
            this.comboBoxSelectDatabase.Location = new System.Drawing.Point(197, 207);
            this.comboBoxSelectDatabase.Name = "comboBoxSelectDatabase";
            this.comboBoxSelectDatabase.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSelectDatabase.TabIndex = 1;
            this.comboBoxSelectDatabase.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectDatabase_SelectedIndexChanged);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(117, 425);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(90, 23);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "Back to Menu";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonToManage
            // 
            this.buttonToManage.Location = new System.Drawing.Point(255, 425);
            this.buttonToManage.Name = "buttonToManage";
            this.buttonToManage.Size = new System.Drawing.Size(107, 23);
            this.buttonToManage.TabIndex = 3;
            this.buttonToManage.Text = "Manage Session";
            this.buttonToManage.UseVisualStyleBackColor = true;
            this.buttonToManage.Click += new System.EventHandler(this.buttonToManage_Click);
            // 
            // labelSelectedDatabase
            // 
            this.labelSelectedDatabase.AutoSize = true;
            this.labelSelectedDatabase.Location = new System.Drawing.Point(117, 276);
            this.labelSelectedDatabase.Name = "labelSelectedDatabase";
            this.labelSelectedDatabase.Size = new System.Drawing.Size(92, 13);
            this.labelSelectedDatabase.TabIndex = 4;
            this.labelSelectedDatabase.Text = "Selected Session:";
            // 
            // textBoxSelectedDatabase
            // 
            this.textBoxSelectedDatabase.Enabled = false;
            this.textBoxSelectedDatabase.Location = new System.Drawing.Point(215, 273);
            this.textBoxSelectedDatabase.Name = "textBoxSelectedDatabase";
            this.textBoxSelectedDatabase.Size = new System.Drawing.Size(100, 20);
            this.textBoxSelectedDatabase.TabIndex = 5;
            // 
            // DataBaseNameSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxSelectedDatabase);
            this.Controls.Add(this.labelSelectedDatabase);
            this.Controls.Add(this.buttonToManage);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.comboBoxSelectDatabase);
            this.Controls.Add(this.labelSelectDatabase);
            this.MaximumSize = new System.Drawing.Size(550, 700);
            this.MinimumSize = new System.Drawing.Size(550, 700);
            this.Name = "DataBaseNameSelector";
            this.Size = new System.Drawing.Size(550, 700);
            this.Load += new System.EventHandler(this.DataBaseNameSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSelectDatabase;
        private System.Windows.Forms.ComboBox comboBoxSelectDatabase;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonToManage;
        private System.Windows.Forms.Label labelSelectedDatabase;
        private System.Windows.Forms.TextBox textBoxSelectedDatabase;
    }
}
