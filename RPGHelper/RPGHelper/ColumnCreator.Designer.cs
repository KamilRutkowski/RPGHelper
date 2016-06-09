namespace RPGHelper
{
    partial class ColumnCreator
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
            this.comboBoxTypeOfColumn = new System.Windows.Forms.ComboBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelTypeOfColumn = new System.Windows.Forms.Label();
            this.buttonEnum = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxTypeOfColumn
            // 
            this.comboBoxTypeOfColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeOfColumn.FormattingEnabled = true;
            this.comboBoxTypeOfColumn.Location = new System.Drawing.Point(196, 3);
            this.comboBoxTypeOfColumn.Name = "comboBoxTypeOfColumn";
            this.comboBoxTypeOfColumn.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTypeOfColumn.TabIndex = 0;
            this.comboBoxTypeOfColumn.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(50, 3);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(9, 6);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Name:";
            // 
            // labelTypeOfColumn
            // 
            this.labelTypeOfColumn.AutoSize = true;
            this.labelTypeOfColumn.Location = new System.Drawing.Point(156, 6);
            this.labelTypeOfColumn.Name = "labelTypeOfColumn";
            this.labelTypeOfColumn.Size = new System.Drawing.Size(34, 13);
            this.labelTypeOfColumn.TabIndex = 3;
            this.labelTypeOfColumn.Text = "Type:";
            // 
            // buttonEnum
            // 
            this.buttonEnum.Location = new System.Drawing.Point(323, 3);
            this.buttonEnum.Name = "buttonEnum";
            this.buttonEnum.Size = new System.Drawing.Size(75, 23);
            this.buttonEnum.TabIndex = 4;
            this.buttonEnum.Text = "Edit Values";
            this.buttonEnum.UseVisualStyleBackColor = true;
            this.buttonEnum.Click += new System.EventHandler(this.buttonEnum_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(404, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(93, 23);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "Remove Column";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // ColumnCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEnum);
            this.Controls.Add(this.labelTypeOfColumn);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.comboBoxTypeOfColumn);
            this.MaximumSize = new System.Drawing.Size(500, 30);
            this.MinimumSize = new System.Drawing.Size(500, 30);
            this.Name = "ColumnCreator";
            this.Size = new System.Drawing.Size(500, 30);
            this.Load += new System.EventHandler(this.ColumnCreator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTypeOfColumn;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelTypeOfColumn;
        private System.Windows.Forms.Button buttonEnum;
        private System.Windows.Forms.Button buttonDelete;
    }
}
