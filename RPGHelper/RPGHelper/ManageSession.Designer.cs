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
            this.dataGridColumns = new System.Windows.Forms.DataGridView();
            this.columnPlaceHolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonLoadSession = new System.Windows.Forms.Button();
            this.buttonEditEntity = new System.Windows.Forms.Button();
            this.listBoxSubEntities = new System.Windows.Forms.ListBox();
            this.comboBoxEntities = new System.Windows.Forms.ComboBox();
            this.labelSelectEntity = new System.Windows.Forms.Label();
            this.labelSelectSubEntities = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridColumns
            // 
            this.dataGridColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnPlaceHolder});
            this.dataGridColumns.Location = new System.Drawing.Point(15, 408);
            this.dataGridColumns.Name = "dataGridColumns";
            this.dataGridColumns.Size = new System.Drawing.Size(502, 150);
            this.dataGridColumns.TabIndex = 0;
            // 
            // columnPlaceHolder
            // 
            this.columnPlaceHolder.HeaderText = "Place Holder";
            this.columnPlaceHolder.Name = "columnPlaceHolder";
            // 
            // buttonLoadSession
            // 
            this.buttonLoadSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonLoadSession.Location = new System.Drawing.Point(15, 13);
            this.buttonLoadSession.Name = "buttonLoadSession";
            this.buttonLoadSession.Size = new System.Drawing.Size(188, 43);
            this.buttonLoadSession.TabIndex = 1;
            this.buttonLoadSession.Text = "Load Another Session";
            this.buttonLoadSession.UseVisualStyleBackColor = true;
            // 
            // buttonEditEntity
            // 
            this.buttonEditEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonEditEntity.Location = new System.Drawing.Point(200, 359);
            this.buttonEditEntity.Name = "buttonEditEntity";
            this.buttonEditEntity.Size = new System.Drawing.Size(97, 43);
            this.buttonEditEntity.TabIndex = 2;
            this.buttonEditEntity.Text = "Edit Entity";
            this.buttonEditEntity.UseVisualStyleBackColor = true;
            // 
            // listBoxSubEntities
            // 
            this.listBoxSubEntities.FormattingEnabled = true;
            this.listBoxSubEntities.Location = new System.Drawing.Point(200, 95);
            this.listBoxSubEntities.Name = "listBoxSubEntities";
            this.listBoxSubEntities.Size = new System.Drawing.Size(145, 251);
            this.listBoxSubEntities.TabIndex = 3;
            // 
            // comboBoxEntities
            // 
            this.comboBoxEntities.FormattingEnabled = true;
            this.comboBoxEntities.Location = new System.Drawing.Point(15, 100);
            this.comboBoxEntities.Name = "comboBoxEntities";
            this.comboBoxEntities.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEntities.TabIndex = 4;
            // 
            // labelSelectEntity
            // 
            this.labelSelectEntity.AutoSize = true;
            this.labelSelectEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelSelectEntity.Location = new System.Drawing.Point(11, 77);
            this.labelSelectEntity.Name = "labelSelectEntity";
            this.labelSelectEntity.Size = new System.Drawing.Size(98, 20);
            this.labelSelectEntity.TabIndex = 5;
            this.labelSelectEntity.Text = "Select Entity";
            // 
            // labelSelectSubEntities
            // 
            this.labelSelectSubEntities.AutoSize = true;
            this.labelSelectSubEntities.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelSelectSubEntities.Location = new System.Drawing.Point(196, 72);
            this.labelSelectSubEntities.Name = "labelSelectSubEntities";
            this.labelSelectSubEntities.Size = new System.Drawing.Size(132, 20);
            this.labelSelectSubEntities.TabIndex = 6;
            this.labelSelectSubEntities.Text = "Select Sub-Entity";
            // 
            // ManageSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelSelectSubEntities);
            this.Controls.Add(this.labelSelectEntity);
            this.Controls.Add(this.comboBoxEntities);
            this.Controls.Add(this.listBoxSubEntities);
            this.Controls.Add(this.buttonEditEntity);
            this.Controls.Add(this.buttonLoadSession);
            this.Controls.Add(this.dataGridColumns);
            this.Name = "ManageSession";
            this.Size = new System.Drawing.Size(531, 575);
            this.Load += new System.EventHandler(this.ManageSession_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridColumns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridColumns;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPlaceHolder;
        private System.Windows.Forms.Button buttonLoadSession;
        private System.Windows.Forms.Button buttonEditEntity;
        private System.Windows.Forms.ListBox listBoxSubEntities;
        private System.Windows.Forms.ComboBox comboBoxEntities;
        private System.Windows.Forms.Label labelSelectEntity;
        private System.Windows.Forms.Label labelSelectSubEntities;
    }
}
