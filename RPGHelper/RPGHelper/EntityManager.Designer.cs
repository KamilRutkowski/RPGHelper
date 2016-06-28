namespace RPGHelper
{
    partial class EntityManager
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.textBoxFor = new System.Windows.Forms.TextBox();
            this.labelFor = new System.Windows.Forms.Label();
            this.buttonFinish = new System.Windows.Forms.Button();
            this.textBoxEntity = new System.Windows.Forms.TextBox();
            this.labelEntity = new System.Windows.Forms.Label();
            this.textBoxDatabase = new System.Windows.Forms.TextBox();
            this.labelDatabase = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.buttonShowItems = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(2, 5);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.buttonShowItems);
            this.splitContainer.Panel1.Controls.Add(this.textBoxFor);
            this.splitContainer.Panel1.Controls.Add(this.labelFor);
            this.splitContainer.Panel1.Controls.Add(this.buttonFinish);
            this.splitContainer.Panel1.Controls.Add(this.textBoxEntity);
            this.splitContainer.Panel1.Controls.Add(this.labelEntity);
            this.splitContainer.Panel1.Controls.Add(this.textBoxDatabase);
            this.splitContainer.Panel1.Controls.Add(this.labelDatabase);
            this.splitContainer.Panel1.Controls.Add(this.buttonDelete);
            this.splitContainer.Panel1.Controls.Add(this.buttonUpdate);
            this.splitContainer.Panel1.Controls.Add(this.buttonInsert);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AutoScroll = true;
            this.splitContainer.Size = new System.Drawing.Size(423, 338);
            this.splitContainer.SplitterDistance = 72;
            this.splitContainer.TabIndex = 13;
            // 
            // textBoxFor
            // 
            this.textBoxFor.Enabled = false;
            this.textBoxFor.Location = new System.Drawing.Point(309, 4);
            this.textBoxFor.Name = "textBoxFor";
            this.textBoxFor.Size = new System.Drawing.Size(70, 20);
            this.textBoxFor.TabIndex = 22;
            // 
            // labelFor
            // 
            this.labelFor.AutoSize = true;
            this.labelFor.Location = new System.Drawing.Point(278, 7);
            this.labelFor.Name = "labelFor";
            this.labelFor.Size = new System.Drawing.Size(25, 13);
            this.labelFor.TabIndex = 21;
            this.labelFor.Text = "For:";
            // 
            // buttonFinish
            // 
            this.buttonFinish.Location = new System.Drawing.Point(255, 40);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(75, 23);
            this.buttonFinish.TabIndex = 20;
            this.buttonFinish.Text = "Finish";
            this.buttonFinish.UseVisualStyleBackColor = true;
            this.buttonFinish.Click += new System.EventHandler(this.buttonFinish_Click);
            // 
            // textBoxEntity
            // 
            this.textBoxEntity.Enabled = false;
            this.textBoxEntity.Location = new System.Drawing.Point(194, 4);
            this.textBoxEntity.Name = "textBoxEntity";
            this.textBoxEntity.Size = new System.Drawing.Size(70, 20);
            this.textBoxEntity.TabIndex = 19;
            // 
            // labelEntity
            // 
            this.labelEntity.AutoSize = true;
            this.labelEntity.Location = new System.Drawing.Point(152, 7);
            this.labelEntity.Name = "labelEntity";
            this.labelEntity.Size = new System.Drawing.Size(36, 13);
            this.labelEntity.TabIndex = 18;
            this.labelEntity.Text = "Entity:";
            // 
            // textBoxDatabase
            // 
            this.textBoxDatabase.Enabled = false;
            this.textBoxDatabase.Location = new System.Drawing.Point(71, 4);
            this.textBoxDatabase.Name = "textBoxDatabase";
            this.textBoxDatabase.Size = new System.Drawing.Size(70, 20);
            this.textBoxDatabase.TabIndex = 17;
            // 
            // labelDatabase
            // 
            this.labelDatabase.AutoSize = true;
            this.labelDatabase.Location = new System.Drawing.Point(9, 7);
            this.labelDatabase.Name = "labelDatabase";
            this.labelDatabase.Size = new System.Drawing.Size(56, 13);
            this.labelDatabase.TabIndex = 16;
            this.labelDatabase.Text = "Database:";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(174, 40);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 15;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(93, 40);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 14;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(12, 40);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(75, 23);
            this.buttonInsert.TabIndex = 13;
            this.buttonInsert.Text = "Insert";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // buttonShowItems
            // 
            this.buttonShowItems.Enabled = false;
            this.buttonShowItems.Location = new System.Drawing.Point(337, 39);
            this.buttonShowItems.Name = "buttonShowItems";
            this.buttonShowItems.Size = new System.Drawing.Size(75, 23);
            this.buttonShowItems.TabIndex = 23;
            this.buttonShowItems.Text = "Items";
            this.buttonShowItems.UseVisualStyleBackColor = true;
            this.buttonShowItems.Click += new System.EventHandler(this.buttonShowItems_Click);
            // 
            // EntityManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 350);
            this.Controls.Add(this.splitContainer);
            this.Name = "EntityManager";
            this.Text = "EntityManager";
            this.Load += new System.EventHandler(this.EntityManager_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button buttonFinish;
        private System.Windows.Forms.TextBox textBoxEntity;
        private System.Windows.Forms.Label labelEntity;
        private System.Windows.Forms.TextBox textBoxDatabase;
        private System.Windows.Forms.Label labelDatabase;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.TextBox textBoxFor;
        private System.Windows.Forms.Label labelFor;
        private System.Windows.Forms.Button buttonShowItems;

    }
}