namespace BioBooker.WinApp.Uil.Views
{
    partial class CreateMovieTheaterView
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
            this.txtBoxAmountOfRows = new System.Windows.Forms.TextBox();
            this.lblAmountOfRows = new System.Windows.Forms.Label();
            this.lblSeatsPerRow = new System.Windows.Forms.Label();
            this.txtBoxSeatsPerRow = new System.Windows.Forms.TextBox();
            this.btnCreateMovieTheater = new System.Windows.Forms.Button();
            this.lblMovieTheaterName = new System.Windows.Forms.Label();
            this.txtBoxMovieTheaterName = new System.Windows.Forms.TextBox();
            this.txtBoxAuditoriumName = new System.Windows.Forms.TextBox();
            this.lblAuditoriumName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBoxAmountOfRows
            // 
            this.txtBoxAmountOfRows.Location = new System.Drawing.Point(12, 37);
            this.txtBoxAmountOfRows.Name = "txtBoxAmountOfRows";
            this.txtBoxAmountOfRows.Size = new System.Drawing.Size(124, 23);
            this.txtBoxAmountOfRows.TabIndex = 0;
            // 
            // lblAmountOfRows
            // 
            this.lblAmountOfRows.AutoSize = true;
            this.lblAmountOfRows.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAmountOfRows.Location = new System.Drawing.Point(12, 14);
            this.lblAmountOfRows.Name = "lblAmountOfRows";
            this.lblAmountOfRows.Size = new System.Drawing.Size(124, 20);
            this.lblAmountOfRows.TabIndex = 1;
            this.lblAmountOfRows.Text = "Amount of rows";
            // 
            // lblSeatsPerRow
            // 
            this.lblSeatsPerRow.AutoSize = true;
            this.lblSeatsPerRow.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSeatsPerRow.Location = new System.Drawing.Point(12, 86);
            this.lblSeatsPerRow.Name = "lblSeatsPerRow";
            this.lblSeatsPerRow.Size = new System.Drawing.Size(104, 20);
            this.lblSeatsPerRow.TabIndex = 2;
            this.lblSeatsPerRow.Text = "Seats per row";
            // 
            // txtBoxSeatsPerRow
            // 
            this.txtBoxSeatsPerRow.Location = new System.Drawing.Point(12, 109);
            this.txtBoxSeatsPerRow.Name = "txtBoxSeatsPerRow";
            this.txtBoxSeatsPerRow.Size = new System.Drawing.Size(124, 23);
            this.txtBoxSeatsPerRow.TabIndex = 3;
            // 
            // btnCreateMovieTheater
            // 
            this.btnCreateMovieTheater.Location = new System.Drawing.Point(12, 172);
            this.btnCreateMovieTheater.Name = "btnCreateMovieTheater";
            this.btnCreateMovieTheater.Size = new System.Drawing.Size(140, 23);
            this.btnCreateMovieTheater.TabIndex = 4;
            this.btnCreateMovieTheater.Text = "Create Movie Theater";
            this.btnCreateMovieTheater.UseVisualStyleBackColor = true;
            this.btnCreateMovieTheater.Click += new System.EventHandler(this.btnCreateMovieTheater_Click);
            // 
            // lblMovieTheaterName
            // 
            this.lblMovieTheaterName.AutoSize = true;
            this.lblMovieTheaterName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMovieTheaterName.Location = new System.Drawing.Point(200, 14);
            this.lblMovieTheaterName.Name = "lblMovieTheaterName";
            this.lblMovieTheaterName.Size = new System.Drawing.Size(150, 20);
            this.lblMovieTheaterName.TabIndex = 5;
            this.lblMovieTheaterName.Text = "Movie theater name";
            // 
            // txtBoxMovieTheaterName
            // 
            this.txtBoxMovieTheaterName.Location = new System.Drawing.Point(200, 37);
            this.txtBoxMovieTheaterName.Name = "txtBoxMovieTheaterName";
            this.txtBoxMovieTheaterName.Size = new System.Drawing.Size(150, 23);
            this.txtBoxMovieTheaterName.TabIndex = 6;
            // 
            // txtBoxAuditoriumName
            // 
            this.txtBoxAuditoriumName.Location = new System.Drawing.Point(200, 109);
            this.txtBoxAuditoriumName.Name = "txtBoxAuditoriumName";
            this.txtBoxAuditoriumName.Size = new System.Drawing.Size(150, 23);
            this.txtBoxAuditoriumName.TabIndex = 7;
            // 
            // lblAuditoriumName
            // 
            this.lblAuditoriumName.AutoSize = true;
            this.lblAuditoriumName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAuditoriumName.Location = new System.Drawing.Point(200, 86);
            this.lblAuditoriumName.Name = "lblAuditoriumName";
            this.lblAuditoriumName.Size = new System.Drawing.Size(133, 20);
            this.lblAuditoriumName.TabIndex = 8;
            this.lblAuditoriumName.Text = "Auditorium name";
            // 
            // CreateMovieTheaterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAuditoriumName);
            this.Controls.Add(this.txtBoxAuditoriumName);
            this.Controls.Add(this.txtBoxMovieTheaterName);
            this.Controls.Add(this.lblMovieTheaterName);
            this.Controls.Add(this.btnCreateMovieTheater);
            this.Controls.Add(this.txtBoxSeatsPerRow);
            this.Controls.Add(this.lblSeatsPerRow);
            this.Controls.Add(this.lblAmountOfRows);
            this.Controls.Add(this.txtBoxAmountOfRows);
            this.Name = "CreateMovieTheaterView";
            this.Text = "CreateMovieTheaterView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxAmountOfRows;
        private System.Windows.Forms.Label lblAmountOfRows;
        private System.Windows.Forms.Label lblSeatsPerRow;
        private System.Windows.Forms.TextBox txtBoxSeatsPerRow;
        private System.Windows.Forms.Button btnCreateMovieTheater;
        private System.Windows.Forms.Label lblMovieTheaterName;
        private System.Windows.Forms.TextBox txtBoxMovieTheaterName;
        private System.Windows.Forms.TextBox txtBoxAuditoriumName;
        private System.Windows.Forms.Label lblAuditoriumName;
    }
}