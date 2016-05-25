namespace RPGHelper
{
    partial class MainMenuControl
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
            this.ButtonStartNewSession = new System.Windows.Forms.Button();
            this.buttonLoadSession = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonStartNewSession
            // 
            this.ButtonStartNewSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ButtonStartNewSession.Location = new System.Drawing.Point(168, 219);
            this.ButtonStartNewSession.Name = "ButtonStartNewSession";
            this.ButtonStartNewSession.Size = new System.Drawing.Size(165, 36);
            this.ButtonStartNewSession.TabIndex = 0;
            this.ButtonStartNewSession.Text = "Start New Session";
            this.ButtonStartNewSession.UseVisualStyleBackColor = true;
            this.ButtonStartNewSession.Click += new System.EventHandler(this.ButtonStartNewSession_Click);
            // 
            // buttonLoadSession
            // 
            this.buttonLoadSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLoadSession.Location = new System.Drawing.Point(168, 303);
            this.buttonLoadSession.Name = "buttonLoadSession";
            this.buttonLoadSession.Size = new System.Drawing.Size(165, 33);
            this.buttonLoadSession.TabIndex = 1;
            this.buttonLoadSession.Text = "Resume Session";
            this.buttonLoadSession.UseVisualStyleBackColor = true;
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonExit.Location = new System.Drawing.Point(168, 386);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(165, 32);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // MainMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonLoadSession);
            this.Controls.Add(this.ButtonStartNewSession);
            this.MaximumSize = new System.Drawing.Size(500, 600);
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "MainMenuControl";
            this.Size = new System.Drawing.Size(500, 600);
            this.Load += new System.EventHandler(this.MainMenuControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonStartNewSession;
        private System.Windows.Forms.Button buttonLoadSession;
        private System.Windows.Forms.Button buttonExit;
    }
}
