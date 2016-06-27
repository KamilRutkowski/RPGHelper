namespace RPGHelper
{
    partial class ConnectionBetweenPlayerTables
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
            this.labelRecordOfTable = new System.Windows.Forms.Label();
            this.comboBoxFirstTableConnectionCount = new System.Windows.Forms.ComboBox();
            this.comboBoxFirstTable = new System.Windows.Forms.ComboBox();
            this.buttonRemoveConnection = new System.Windows.Forms.Button();
            this.comboBoxSecondTable = new System.Windows.Forms.ComboBox();
            this.comboBoxSecondTableConnectionCount = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelRecordOfTable
            // 
            this.labelRecordOfTable.AutoSize = true;
            this.labelRecordOfTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelRecordOfTable.Location = new System.Drawing.Point(92, 7);
            this.labelRecordOfTable.Name = "labelRecordOfTable";
            this.labelRecordOfTable.Size = new System.Drawing.Size(103, 18);
            this.labelRecordOfTable.TabIndex = 0;
            this.labelRecordOfTable.Text = "record of table";
            // 
            // comboBoxFirstTableConnectionCount
            // 
            this.comboBoxFirstTableConnectionCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.comboBoxFirstTableConnectionCount.FormattingEnabled = true;
            this.comboBoxFirstTableConnectionCount.Items.AddRange(new object[] {
            "1",
            "∞"});
            this.comboBoxFirstTableConnectionCount.Location = new System.Drawing.Point(27, 6);
            this.comboBoxFirstTableConnectionCount.Name = "comboBoxFirstTableConnectionCount";
            this.comboBoxFirstTableConnectionCount.Size = new System.Drawing.Size(49, 26);
            this.comboBoxFirstTableConnectionCount.TabIndex = 0;
            // 
            // comboBoxFirstTable
            // 
            this.comboBoxFirstTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.comboBoxFirstTable.FormattingEnabled = true;
            this.comboBoxFirstTable.Location = new System.Drawing.Point(201, 6);
            this.comboBoxFirstTable.Name = "comboBoxFirstTable";
            this.comboBoxFirstTable.Size = new System.Drawing.Size(124, 26);
            this.comboBoxFirstTable.TabIndex = 1;
            this.comboBoxFirstTable.SelectedIndexChanged += new System.EventHandler(this.comboBoxFirstTable_SelectedIndexChanged);
            // 
            // buttonRemoveConnection
            // 
            this.buttonRemoveConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonRemoveConnection.Location = new System.Drawing.Point(343, 28);
            this.buttonRemoveConnection.Name = "buttonRemoveConnection";
            this.buttonRemoveConnection.Size = new System.Drawing.Size(154, 28);
            this.buttonRemoveConnection.TabIndex = 4;
            this.buttonRemoveConnection.Text = "Remove connection";
            this.buttonRemoveConnection.UseVisualStyleBackColor = true;
            this.buttonRemoveConnection.Click += new System.EventHandler(this.buttonRemoveConnection_Click);
            // 
            // comboBoxSecondTable
            // 
            this.comboBoxSecondTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.comboBoxSecondTable.FormattingEnabled = true;
            this.comboBoxSecondTable.Location = new System.Drawing.Point(201, 58);
            this.comboBoxSecondTable.Name = "comboBoxSecondTable";
            this.comboBoxSecondTable.Size = new System.Drawing.Size(124, 26);
            this.comboBoxSecondTable.TabIndex = 3;
            this.comboBoxSecondTable.SelectedIndexChanged += new System.EventHandler(this.comboBoxSecondTable_SelectedIndexChanged);
            // 
            // comboBoxSecondTableConnectionCount
            // 
            this.comboBoxSecondTableConnectionCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.comboBoxSecondTableConnectionCount.FormattingEnabled = true;
            this.comboBoxSecondTableConnectionCount.Items.AddRange(new object[] {
            "1",
            "∞"});
            this.comboBoxSecondTableConnectionCount.Location = new System.Drawing.Point(27, 57);
            this.comboBoxSecondTableConnectionCount.Name = "comboBoxSecondTableConnectionCount";
            this.comboBoxSecondTableConnectionCount.Size = new System.Drawing.Size(49, 26);
            this.comboBoxSecondTableConnectionCount.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(92, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "record of table";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(82, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "is connected with ";
            // 
            // ConnectionBetweenPlayerTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxSecondTable);
            this.Controls.Add(this.comboBoxSecondTableConnectionCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRemoveConnection);
            this.Controls.Add(this.comboBoxFirstTable);
            this.Controls.Add(this.comboBoxFirstTableConnectionCount);
            this.Controls.Add(this.labelRecordOfTable);
            this.MaximumSize = new System.Drawing.Size(500, 90);
            this.MinimumSize = new System.Drawing.Size(500, 90);
            this.Name = "ConnectionBetweenPlayerTables";
            this.Size = new System.Drawing.Size(500, 90);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRecordOfTable;
        private System.Windows.Forms.ComboBox comboBoxFirstTableConnectionCount;
        private System.Windows.Forms.ComboBox comboBoxFirstTable;
        private System.Windows.Forms.Button buttonRemoveConnection;
        private System.Windows.Forms.ComboBox comboBoxSecondTable;
        private System.Windows.Forms.ComboBox comboBoxSecondTableConnectionCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
