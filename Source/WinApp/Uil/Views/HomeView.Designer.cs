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
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCreateMovies = new System.Windows.Forms.Button();
            this.buttonViewMovies = new System.Windows.Forms.Button();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Location = new System.Drawing.Point(12, 415);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(860, 34);
            this.pnlButtons.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(745, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnCreateMovies
            // 
            this.btnCreateMovies.Location = new System.Drawing.Point(12, 12);
            this.btnCreateMovies.Name = "btnCreateMovies";
            this.btnCreateMovies.Size = new System.Drawing.Size(110, 25);
            this.btnCreateMovies.TabIndex = 1;
            this.btnCreateMovies.Text = "Create movie";
            this.btnCreateMovies.UseVisualStyleBackColor = true;
            this.btnCreateMovies.Click += new System.EventHandler(this.btnCreateMovies_Click);
            // 
            // buttonViewMovies
            // 
            this.buttonViewMovies.Location = new System.Drawing.Point(128, 12);
            this.buttonViewMovies.Name = "buttonViewMovies";
            this.buttonViewMovies.Size = new System.Drawing.Size(110, 25);
            this.buttonViewMovies.TabIndex = 2;
            this.buttonViewMovies.Text = "View movies";
            this.buttonViewMovies.UseVisualStyleBackColor = true;
            this.buttonViewMovies.Click += new System.EventHandler(this.buttonViewMovies_Click);
            // 
            // HomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.buttonViewMovies);
            this.Controls.Add(this.btnCreateMovies);
            this.Controls.Add(this.pnlButtons);
            this.Name = "HomeView";
            this.Text = "Home";
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCreateMovies;
        private System.Windows.Forms.Button buttonViewMovies;
    }
}