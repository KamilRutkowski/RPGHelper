namespace RPGHelper
{
    partial class ConnectionBetweenPlayerAndItems
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
            this.comboBoxPlayerTables = new System.Windows.Forms.ComboBox();
            this.comboBoxItemTables = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxPlayerTables
            // 
            this.comboBoxPlayerTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.comboBoxPlayerTables.FormattingEnabled = true;
            this.comboBoxPlayerTables.Location = new System.Drawing.Point(3, 3);
            this.comboBoxPlayerTables.Name = "comboBoxPlayerTables";
            this.comboBoxPlayerTables.Size = new System.Drawing.Size(147, 21);
            this.comboBoxPlayerTables.TabIndex = 0;
            this.comboBoxPlayerTables.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlayerTables_SelectedIndexChanged);
            // 
            // comboBoxItemTables
            // 
            this.comboBoxItemTables.FormattingEnabled = true;
            this.comboBoxItemTables.Location = new System.Drawing.Point(287, 3);
            this.comboBoxItemTables.Name = "comboBoxItemTables";
            this.comboBoxItemTables.Size = new System.Drawing.Size(144, 21);
            this.comboBoxItemTables.TabIndex = 1;
            this.comboBoxItemTables.SelectedIndexChanged += new System.EventHandler(this.comboBoxItemTables_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(156, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "takes values from";
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(437, 1);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(60, 23);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // ConnectionBetweenPlayerAndItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxItemTables);
            this.Controls.Add(this.comboBoxPlayerTables);
            this.MaximumSize = new System.Drawing.Size(500, 30);
            this.MinimumSize = new System.Drawing.Size(500, 30);
            this.Name = "ConnectionBetweenPlayerAndItems";
            this.Size = new System.Drawing.Size(500, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPlayerTables;
        private System.Windows.Forms.ComboBox comboBoxItemTables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRemove;
    }
}
