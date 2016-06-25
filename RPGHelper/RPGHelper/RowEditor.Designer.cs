namespace RPGHelper
{
    partial class RowEditor
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
            this.labelColumnName = new System.Windows.Forms.Label();
            this.textBoxValueInRow = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelColumnName
            // 
            this.labelColumnName.AutoSize = true;
            this.labelColumnName.Location = new System.Drawing.Point(3, 9);
            this.labelColumnName.Name = "labelColumnName";
            this.labelColumnName.Size = new System.Drawing.Size(70, 13);
            this.labelColumnName.TabIndex = 0;
            this.labelColumnName.Text = "ColumnName";
            // 
            // textBoxValueInRow
            // 
            this.textBoxValueInRow.Location = new System.Drawing.Point(135, 6);
            this.textBoxValueInRow.Name = "textBoxValueInRow";
            this.textBoxValueInRow.Size = new System.Drawing.Size(100, 20);
            this.textBoxValueInRow.TabIndex = 1;
            // 
            // RowEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxValueInRow);
            this.Controls.Add(this.labelColumnName);
            this.Name = "RowEditor";
            this.Size = new System.Drawing.Size(238, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelColumnName;
        private System.Windows.Forms.TextBox textBoxValueInRow;
    }
}
