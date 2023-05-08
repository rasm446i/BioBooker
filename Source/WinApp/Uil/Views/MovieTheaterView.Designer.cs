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
            this.btnCreateAuditorium = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateAuditorium
            // 
            this.btnCreateAuditorium.Location = new System.Drawing.Point(55, 56);
            this.btnCreateAuditorium.Name = "btnCreateAuditorium";
            this.btnCreateAuditorium.Size = new System.Drawing.Size(121, 23);
            this.btnCreateAuditorium.TabIndex = 0;
            this.btnCreateAuditorium.Text = "Create Auditorium";
            this.btnCreateAuditorium.UseVisualStyleBackColor = true;
            this.btnCreateAuditorium.Click += new System.EventHandler(this.btnCreateAuditorium_Click);
            // 
            // MovieTheaterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCreateAuditorium);
            this.Name = "MovieTheaterView";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateAuditorium;
    }
}