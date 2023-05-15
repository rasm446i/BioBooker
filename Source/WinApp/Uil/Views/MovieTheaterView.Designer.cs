namespace BioBooker.WinApp.Uil.Views
{
    partial class MovieTheaterView
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
            this.btnCreateMovieTheater = new System.Windows.Forms.Button();
            this.btnCreateAuditoriums = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateMovieTheater
            // 
            this.btnCreateMovieTheater.Location = new System.Drawing.Point(112, 97);
            this.btnCreateMovieTheater.Name = "btnCreateMovieTheater";
            this.btnCreateMovieTheater.Size = new System.Drawing.Size(138, 23);
            this.btnCreateMovieTheater.TabIndex = 0;
            this.btnCreateMovieTheater.Text = "Create Movie Theater";
            this.btnCreateMovieTheater.UseVisualStyleBackColor = true;
            this.btnCreateMovieTheater.Click += new System.EventHandler(this.btnCreateMovieTheater_Click);
            // 
            // btnCreateAuditoriums
            // 
            this.btnCreateAuditoriums.Location = new System.Drawing.Point(280, 97);
            this.btnCreateAuditoriums.Name = "btnCreateAuditoriums";
            this.btnCreateAuditoriums.Size = new System.Drawing.Size(119, 23);
            this.btnCreateAuditoriums.TabIndex = 1;
            this.btnCreateAuditoriums.Text = "Show auditoriums";
            this.btnCreateAuditoriums.UseVisualStyleBackColor = true;
            this.btnCreateAuditoriums.Click += new System.EventHandler(this.btnCreateAuditoriums_Click);
            // 
            // MovieTheaterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCreateAuditoriums);
            this.Controls.Add(this.btnCreateMovieTheater);
            this.Name = "MovieTheaterView";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateMovieTheater;
        private System.Windows.Forms.Button btnCreateAuditoriums;
    }
}