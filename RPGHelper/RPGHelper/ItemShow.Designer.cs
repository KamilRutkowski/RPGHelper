namespace RPGHelper
{
    partial class ItemShow
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
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.textBoxTableName = new System.Windows.Forms.TextBox();
            this.labelTableName = new System.Windows.Forms.Label();
            this.labelFor = new System.Windows.Forms.Label();
            this.textBoxFor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.AllowUserToAddRows = false;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Location = new System.Drawing.Point(12, 91);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.ReadOnly = true;
            this.dataGridViewItems.Size = new System.Drawing.Size(425, 221);
            this.dataGridViewItems.TabIndex = 0;
            this.dataGridViewItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewItems_CellDoubleClick);
            // 
            // textBoxTableName
            // 
            this.textBoxTableName.Enabled = false;
            this.textBoxTableName.Location = new System.Drawing.Point(87, 17);
            this.textBoxTableName.Name = "textBoxTableName";
            this.textBoxTableName.Size = new System.Drawing.Size(100, 20);
            this.textBoxTableName.TabIndex = 1;
            // 
            // labelTableName
            // 
            this.labelTableName.AutoSize = true;
            this.labelTableName.Location = new System.Drawing.Point(45, 20);
            this.labelTableName.Name = "labelTableName";
            this.labelTableName.Size = new System.Drawing.Size(36, 13);
            this.labelTableName.TabIndex = 2;
            this.labelTableName.Text = "Entity:";
            // 
            // labelFor
            // 
            this.labelFor.AutoSize = true;
            this.labelFor.Location = new System.Drawing.Point(263, 20);
            this.labelFor.Name = "labelFor";
            this.labelFor.Size = new System.Drawing.Size(25, 13);
            this.labelFor.TabIndex = 4;
            this.labelFor.Text = "For:";
            // 
            // textBoxFor
            // 
            this.textBoxFor.Enabled = false;
            this.textBoxFor.Location = new System.Drawing.Point(294, 17);
            this.textBoxFor.Name = "textBoxFor";
            this.textBoxFor.Size = new System.Drawing.Size(100, 20);
            this.textBoxFor.TabIndex = 3;
            // 
            // ItemShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 324);
            this.Controls.Add(this.labelFor);
            this.Controls.Add(this.textBoxFor);
            this.Controls.Add(this.labelTableName);
            this.Controls.Add(this.textBoxTableName);
            this.Controls.Add(this.dataGridViewItems);
            this.Name = "ItemShow";
            this.Text = "ItemShow";
            this.Load += new System.EventHandler(this.ItemShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.TextBox textBoxTableName;
        private System.Windows.Forms.Label labelTableName;
        private System.Windows.Forms.Label labelFor;
        private System.Windows.Forms.TextBox textBoxFor;
    }
}