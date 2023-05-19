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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonAddShowing = new System.Windows.Forms.Button();
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
            this.lblSeatRows.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSeatRows.Location = new System.Drawing.Point(403, 77);
            this.lblSeatRows.Name = "lblSeatRows";
            this.lblSeatRows.Size = new System.Drawing.Size(0, 20);
            this.lblSeatRows.TabIndex = 6;
            // 
            // lblSeatNumbers
            // 
            this.lblSeatNumbers.AutoSize = true;
            this.lblSeatNumbers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSeatNumbers.Location = new System.Drawing.Point(403, 138);
            this.lblSeatNumbers.Name = "lblSeatNumbers";
            this.lblSeatNumbers.Size = new System.Drawing.Size(0, 20);
            this.lblSeatNumbers.TabIndex = 7;
            // 
            // lblTotalSeats
            // 
            this.lblTotalSeats.AutoSize = true;
            this.lblTotalSeats.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalSeats.Location = new System.Drawing.Point(403, 192);
            this.lblTotalSeats.Name = "lblTotalSeats";
            this.lblTotalSeats.Size = new System.Drawing.Size(0, 20);
            this.lblTotalSeats.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(403, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Seat rows";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(403, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Seat numbers per row";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(403, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Total amount of seats";
            // 
            // btnAddAuditorium
            // 
            this.btnAddAuditorium.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddAuditorium.Location = new System.Drawing.Point(28, 321);
            this.btnAddAuditorium.Name = "btnAddAuditorium";
            this.btnAddAuditorium.Size = new System.Drawing.Size(132, 25);
            this.btnAddAuditorium.TabIndex = 12;
            this.btnAddAuditorium.Text = "Add Auditorium";
            this.btnAddAuditorium.UseVisualStyleBackColor = true;
            this.btnAddAuditorium.Click += new System.EventHandler(this.btnAddAuditorium_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(28, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Movie Theaters";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(248, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Auditoriums";
            // 
            // buttonAddShowing
            // 
            this.buttonAddShowing.Location = new System.Drawing.Point(259, 321);
            this.buttonAddShowing.Name = "buttonAddShowing";
            this.buttonAddShowing.Size = new System.Drawing.Size(109, 23);
            this.buttonAddShowing.TabIndex = 16;
            this.buttonAddShowing.Text = "Show showings";
            this.buttonAddShowing.UseVisualStyleBackColor = true;
            this.buttonAddShowing.Click += new System.EventHandler(this.buttonAddShowing_Click);
            // 
            // ShowAuditoriumsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAddShowing);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAddShowing;
    }
}