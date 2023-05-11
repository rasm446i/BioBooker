namespace BioBooker.WinApp.Uil.Views
{
    partial class ShowAuditoriumsView
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
            this.lblFoundMovieTheater = new System.Windows.Forms.Label();
            this.ListBoxOfMovieTheaters = new System.Windows.Forms.ListBox();
            this.ListBoxOfAuditoriums = new System.Windows.Forms.ListBox();
            this.lblSeatRows = new System.Windows.Forms.Label();
            this.lblSeatNumbers = new System.Windows.Forms.Label();
            this.lblTotalSeats = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddAuditorium = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFoundMovieTheater
            // 
            this.lblFoundMovieTheater.AutoSize = true;
            this.lblFoundMovieTheater.Location = new System.Drawing.Point(525, 33);
            this.lblFoundMovieTheater.Name = "lblFoundMovieTheater";
            this.lblFoundMovieTheater.Size = new System.Drawing.Size(0, 15);
            this.lblFoundMovieTheater.TabIndex = 3;
            // 
            // ListBoxOfMovieTheaters
            // 
            this.ListBoxOfMovieTheaters.FormattingEnabled = true;
            this.ListBoxOfMovieTheaters.ItemHeight = 15;
            this.ListBoxOfMovieTheaters.Location = new System.Drawing.Point(28, 42);
            this.ListBoxOfMovieTheaters.Name = "ListBoxOfMovieTheaters";
            this.ListBoxOfMovieTheaters.Size = new System.Drawing.Size(132, 244);
            this.ListBoxOfMovieTheaters.TabIndex = 4;
            this.ListBoxOfMovieTheaters.SelectedIndexChanged += new System.EventHandler(this.ListBoxOfMovieTheaters_SelectedIndexChanged);
            // 
            // ListBoxOfAuditoriums
            // 
            this.ListBoxOfAuditoriums.FormattingEnabled = true;
            this.ListBoxOfAuditoriums.ItemHeight = 15;
            this.ListBoxOfAuditoriums.Location = new System.Drawing.Point(248, 42);
            this.ListBoxOfAuditoriums.Name = "ListBoxOfAuditoriums";
            this.ListBoxOfAuditoriums.Size = new System.Drawing.Size(131, 244);
            this.ListBoxOfAuditoriums.TabIndex = 5;
            this.ListBoxOfAuditoriums.SelectedIndexChanged += new System.EventHandler(this.ListBoxOfAuditoriums_SelectedIndexChanged);
            // 
            // lblSeatRows
            // 
            this.lblSeatRows.AutoSize = true;
            this.lblSeatRows.Location = new System.Drawing.Point(403, 77);
            this.lblSeatRows.Name = "lblSeatRows";
            this.lblSeatRows.Size = new System.Drawing.Size(0, 15);
            this.lblSeatRows.TabIndex = 6;
            // 
            // lblSeatNumbers
            // 
            this.lblSeatNumbers.AutoSize = true;
            this.lblSeatNumbers.Location = new System.Drawing.Point(403, 138);
            this.lblSeatNumbers.Name = "lblSeatNumbers";
            this.lblSeatNumbers.Size = new System.Drawing.Size(0, 15);
            this.lblSeatNumbers.TabIndex = 7;
            // 
            // lblTotalSeats
            // 
            this.lblTotalSeats.AutoSize = true;
            this.lblTotalSeats.Location = new System.Drawing.Point(403, 192);
            this.lblTotalSeats.Name = "lblTotalSeats";
            this.lblTotalSeats.Size = new System.Drawing.Size(0, 15);
            this.lblTotalSeats.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(403, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Antal seat rows";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(403, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Antal seat numbers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Antal seats i alt";
            // 
            // btnAddAuditorium
            // 
            this.btnAddAuditorium.Location = new System.Drawing.Point(37, 353);
            this.btnAddAuditorium.Name = "btnAddAuditorium";
            this.btnAddAuditorium.Size = new System.Drawing.Size(105, 23);
            this.btnAddAuditorium.TabIndex = 12;
            this.btnAddAuditorium.Text = "Add Auditorium";
            this.btnAddAuditorium.UseVisualStyleBackColor = true;
            this.btnAddAuditorium.Click += new System.EventHandler(this.btnAddAuditorium_Click);
            // 
            // ShowAuditoriumsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddAuditorium);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalSeats);
            this.Controls.Add(this.lblSeatNumbers);
            this.Controls.Add(this.lblSeatRows);
            this.Controls.Add(this.ListBoxOfAuditoriums);
            this.Controls.Add(this.ListBoxOfMovieTheaters);
            this.Controls.Add(this.lblFoundMovieTheater);
            this.Name = "ShowAuditoriumsView";
            this.Text = "CreateAuditoriums";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFoundMovieTheater;
        private System.Windows.Forms.ListBox ListBoxOfMovieTheaters;
        private System.Windows.Forms.ListBox ListBoxOfAuditoriums;
        private System.Windows.Forms.Label lblSeatRows;
        private System.Windows.Forms.Label lblSeatNumbers;
        private System.Windows.Forms.Label lblTotalSeats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddAuditorium;
    }
}