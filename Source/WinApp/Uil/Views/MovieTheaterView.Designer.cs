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
            this.components = new System.ComponentModel.Container();
            this.textBoxMovieTheaterName = new System.Windows.Forms.TextBox();
            this.lblMovieTheaterName = new System.Windows.Forms.Label();
            this.textBoxAuditoriumNumber = new System.Windows.Forms.TextBox();
            this.lblAuditoriumName = new System.Windows.Forms.Label();
            this.btnCreateMovieTheater = new System.Windows.Forms.Button();
            this.buttonSeats = new System.Windows.Forms.Button();
            this.dataGridViewSeats = new System.Windows.Forms.DataGridView();
            this.isAvailableDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.seatNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seatRowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seatBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxMovieTheaterName
            // 
            this.textBoxMovieTheaterName.Location = new System.Drawing.Point(21, 44);
            this.textBoxMovieTheaterName.Name = "textBoxMovieTheaterName";
            this.textBoxMovieTheaterName.Size = new System.Drawing.Size(117, 23);
            this.textBoxMovieTheaterName.TabIndex = 0;
            // 
            // lblMovieTheaterName
            // 
            this.lblMovieTheaterName.AutoSize = true;
            this.lblMovieTheaterName.Location = new System.Drawing.Point(21, 26);
            this.lblMovieTheaterName.Name = "lblMovieTheaterName";
            this.lblMovieTheaterName.Size = new System.Drawing.Size(113, 15);
            this.lblMovieTheaterName.TabIndex = 1;
            this.lblMovieTheaterName.Text = "Movie theater name";
            // 
            // textBoxAuditoriumNumber
            // 
            this.textBoxAuditoriumNumber.Location = new System.Drawing.Point(21, 107);
            this.textBoxAuditoriumNumber.Name = "textBoxAuditoriumNumber";
            this.textBoxAuditoriumNumber.Size = new System.Drawing.Size(117, 23);
            this.textBoxAuditoriumNumber.TabIndex = 2;
            // 
            // lblAuditoriumName
            // 
            this.lblAuditoriumName.AutoSize = true;
            this.lblAuditoriumName.Location = new System.Drawing.Point(21, 89);
            this.lblAuditoriumName.Name = "lblAuditoriumName";
            this.lblAuditoriumName.Size = new System.Drawing.Size(113, 15);
            this.lblAuditoriumName.TabIndex = 3;
            this.lblAuditoriumName.Text = "Auditorium number";
            // 
            // btnCreateMovieTheater
            // 
            this.btnCreateMovieTheater.Location = new System.Drawing.Point(592, 302);
            this.btnCreateMovieTheater.Name = "btnCreateMovieTheater";
            this.btnCreateMovieTheater.Size = new System.Drawing.Size(129, 25);
            this.btnCreateMovieTheater.TabIndex = 4;
            this.btnCreateMovieTheater.Text = "Create Movie Theater";
            this.btnCreateMovieTheater.UseVisualStyleBackColor = true;
            // 
            // buttonSeats
            // 
            this.buttonSeats.Location = new System.Drawing.Point(614, 361);
            this.buttonSeats.Name = "buttonSeats";
            this.buttonSeats.Size = new System.Drawing.Size(107, 23);
            this.buttonSeats.TabIndex = 5;
            this.buttonSeats.Text = "Seats";
            this.buttonSeats.UseVisualStyleBackColor = true;
            this.buttonSeats.Click += new System.EventHandler(this.buttonSeats_Click);
            // 
            // dataGridViewSeats
            // 
            this.dataGridViewSeats.AutoGenerateColumns = false;
            this.dataGridViewSeats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isAvailableDataGridViewCheckBoxColumn,
            this.seatNumberDataGridViewTextBoxColumn,
            this.seatRowDataGridViewTextBoxColumn});
            this.dataGridViewSeats.DataSource = this.seatBindingSource;
            this.dataGridViewSeats.Location = new System.Drawing.Point(183, 44);
            this.dataGridViewSeats.Name = "dataGridViewSeats";
            this.dataGridViewSeats.RowTemplate.Height = 25;
            this.dataGridViewSeats.Size = new System.Drawing.Size(345, 187);
            this.dataGridViewSeats.TabIndex = 6;
            // 
            // isAvailableDataGridViewCheckBoxColumn
            // 
            this.isAvailableDataGridViewCheckBoxColumn.DataPropertyName = "IsAvailable";
            this.isAvailableDataGridViewCheckBoxColumn.HeaderText = "IsAvailable";
            this.isAvailableDataGridViewCheckBoxColumn.Name = "isAvailableDataGridViewCheckBoxColumn";
            // 
            // seatNumberDataGridViewTextBoxColumn
            // 
            this.seatNumberDataGridViewTextBoxColumn.DataPropertyName = "SeatNumber";
            this.seatNumberDataGridViewTextBoxColumn.HeaderText = "SeatNumber";
            this.seatNumberDataGridViewTextBoxColumn.Name = "seatNumberDataGridViewTextBoxColumn";
            // 
            // seatRowDataGridViewTextBoxColumn
            // 
            this.seatRowDataGridViewTextBoxColumn.DataPropertyName = "SeatRow";
            this.seatRowDataGridViewTextBoxColumn.HeaderText = "SeatRow";
            this.seatRowDataGridViewTextBoxColumn.Name = "seatRowDataGridViewTextBoxColumn";
            // 
            // seatBindingSource
            // 
            this.seatBindingSource.DataSource = typeof(BioBooker.Dml.Seat);
            // 
            // MovieTheaterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 450);
            this.Controls.Add(this.dataGridViewSeats);
            this.Controls.Add(this.buttonSeats);
            this.Controls.Add(this.btnCreateMovieTheater);
            this.Controls.Add(this.lblAuditoriumName);
            this.Controls.Add(this.textBoxAuditoriumNumber);
            this.Controls.Add(this.lblMovieTheaterName);
            this.Controls.Add(this.textBoxMovieTheaterName);
            this.Name = "MovieTheaterView";
            this.Text = "MovieTheaterView";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seatBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMovieTheaterName;
        private System.Windows.Forms.Label lblMovieTheaterName;
        private System.Windows.Forms.TextBox textBoxAuditoriumNumber;
        private System.Windows.Forms.Label lblAuditoriumName;
        private System.Windows.Forms.Button btnCreateMovieTheater;
        private System.Windows.Forms.Button buttonSeats;
        private System.Windows.Forms.DataGridView dataGridViewSeats;
        private System.Windows.Forms.BindingSource seatBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isAvailableDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seatNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seatRowDataGridViewTextBoxColumn;
    }
}