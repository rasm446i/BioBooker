namespace BioBooker.WinApp.Uil.Views
{
    partial class HomeView
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
            pnlButtons = new System.Windows.Forms.Panel();
            btnClose = new System.Windows.Forms.Button();
            btnMovies = new System.Windows.Forms.Button();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlButtons
            // 
            pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlButtons.Controls.Add(btnClose);
            pnlButtons.Location = new System.Drawing.Point(12, 415);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new System.Drawing.Size(860, 34);
            pnlButtons.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Location = new System.Drawing.Point(745, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(110, 25);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnCloseClick;
            // 
            // btnMovies
            // 
            btnMovies.Location = new System.Drawing.Point(12, 12);
            btnMovies.Name = "btnMovies";
            btnMovies.Size = new System.Drawing.Size(110, 25);
            btnMovies.TabIndex = 1;
            btnMovies.Text = "Movies";
            btnMovies.UseVisualStyleBackColor = true;
            btnMovies.Click += BtnMoviesClick;
            // 
            // HomeView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(884, 461);
            Controls.Add(btnMovies);
            Controls.Add(pnlButtons);
            Name = "HomeView";
            Text = "Home";
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMovies;
    }
}