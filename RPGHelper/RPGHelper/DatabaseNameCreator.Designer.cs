namespace RPGHelper
{
    partial class DatabaseNameCreator
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
            this.textBoxDatabaseName = new System.Windows.Forms.TextBox();
            this.labelGiveDatabaseName = new System.Windows.Forms.Label();
            this.buttonStopCreation = new System.Windows.Forms.Button();
            this.buttonNextStep = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxDatabaseName
            // 
            this.textBoxDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxDatabaseName.Location = new System.Drawing.Point(91, 263);
            this.textBoxDatabaseName.Name = "textBoxDatabaseName";
            this.textBoxDatabaseName.Size = new System.Drawing.Size(331, 26);
            this.textBoxDatabaseName.TabIndex = 0;
            this.textBoxDatabaseName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDatabaseName_KeyPress);
            // 
            // labelGiveDatabaseName
            // 
            this.labelGiveDatabaseName.AutoSize = true;
            this.labelGiveDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelGiveDatabaseName.Location = new System.Drawing.Point(178, 181);
            this.labelGiveDatabaseName.Name = "labelGiveDatabaseName";
            this.labelGiveDatabaseName.Size = new System.Drawing.Size(113, 20);
            this.labelGiveDatabaseName.TabIndex = 1;
            this.labelGiveDatabaseName.Text = "Name session:";
            // 
            // buttonStopCreation
            // 
            this.buttonStopCreation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonStopCreation.Location = new System.Drawing.Point(175, 427);
            this.buttonStopCreation.Name = "buttonStopCreation";
            this.buttonStopCreation.Size = new System.Drawing.Size(142, 35);
            this.buttonStopCreation.TabIndex = 2;
            this.buttonStopCreation.Text = "Abort creation";
            this.buttonStopCreation.UseVisualStyleBackColor = true;
            this.buttonStopCreation.Click += new System.EventHandler(this.buttonStopCreation_Click);
            // 
            // buttonNextStep
            // 
            this.buttonNextStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonNextStep.Location = new System.Drawing.Point(338, 427);
            this.buttonNextStep.Name = "buttonNextStep";
            this.buttonNextStep.Size = new System.Drawing.Size(142, 35);
            this.buttonNextStep.TabIndex = 3;
            this.buttonNextStep.Text = "Next step";
            this.buttonNextStep.UseVisualStyleBackColor = true;
            this.buttonNextStep.Click += new System.EventHandler(this.buttonNextStep_Click);
            // 
            // DatabaseNameCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonNextStep);
            this.Controls.Add(this.buttonStopCreation);
            this.Controls.Add(this.labelGiveDatabaseName);
            this.Controls.Add(this.textBoxDatabaseName);
            this.MaximumSize = new System.Drawing.Size(500, 600);
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "DatabaseNameCreator";
            this.Size = new System.Drawing.Size(500, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDatabaseName;
        private System.Windows.Forms.Label labelGiveDatabaseName;
        private System.Windows.Forms.Button buttonStopCreation;
        private System.Windows.Forms.Button buttonNextStep;
    }
}
