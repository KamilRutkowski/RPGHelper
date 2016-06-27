namespace RPGHelper
{
    partial class AddTableName
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxTableName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonNameTable = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxTableName
            // 
            this.textBoxTableName.Location = new System.Drawing.Point(12, 106);
            this.textBoxTableName.Name = "textBoxTableName";
            this.textBoxTableName.Size = new System.Drawing.Size(260, 20);
            this.textBoxTableName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(64, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Give this table a name:";
            // 
            // buttonNameTable
            // 
            this.buttonNameTable.Location = new System.Drawing.Point(67, 164);
            this.buttonNameTable.Name = "buttonNameTable";
            this.buttonNameTable.Size = new System.Drawing.Size(75, 23);
            this.buttonNameTable.TabIndex = 1;
            this.buttonNameTable.Text = "Set name";
            this.buttonNameTable.UseVisualStyleBackColor = true;
            this.buttonNameTable.Click += new System.EventHandler(this.buttonNameTable_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(146, 164);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // AddTableName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonNameTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTableName);
            this.Name = "AddTableName";
            this.Text = "Name of table to create";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonNameTable;
        private System.Windows.Forms.Button buttonCancel;
    }
}