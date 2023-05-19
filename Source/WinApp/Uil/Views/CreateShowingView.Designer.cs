namespace BioBooker.WinApp.Uil.Views
{
    partial class CreateShowingView
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
            this.labelAuditorium = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelStartTime = new System.Windows.Forms.Label();
            this.labelEndTime = new System.Windows.Forms.Label();
            this.listViewMovies = new System.Windows.Forms.ListView();
            this.labelChosenMovie = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelDateString = new System.Windows.Forms.Label();
            this.labelAuditoriumName = new System.Windows.Forms.Label();
            this.labelMovieTitle = new System.Windows.Forms.Label();
            this.comboBoxStartTime = new System.Windows.Forms.ComboBox();
            this.textBoxEndTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelAuditorium
            // 
            this.labelAuditorium.AutoSize = true;
            this.labelAuditorium.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAuditorium.Location = new System.Drawing.Point(27, 33);
            this.labelAuditorium.Name = "labelAuditorium";
            this.labelAuditorium.Size = new System.Drawing.Size(94, 20);
            this.labelAuditorium.TabIndex = 0;
            this.labelAuditorium.Text = "Auditorium:";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDate.Location = new System.Drawing.Point(27, 94);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(46, 20);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "Date:";
            // 
            // labelStartTime
            // 
            this.labelStartTime.AutoSize = true;
            this.labelStartTime.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelStartTime.Location = new System.Drawing.Point(24, 148);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Size = new System.Drawing.Size(79, 20);
            this.labelStartTime.TabIndex = 4;
            this.labelStartTime.Text = "Start time";
            // 
            // labelEndTime
            // 
            this.labelEndTime.AutoSize = true;
            this.labelEndTime.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEndTime.Location = new System.Drawing.Point(24, 217);
            this.labelEndTime.Name = "labelEndTime";
            this.labelEndTime.Size = new System.Drawing.Size(71, 20);
            this.labelEndTime.TabIndex = 5;
            this.labelEndTime.Text = "End time";
            // 
            // listViewMovies
            // 
            this.listViewMovies.Location = new System.Drawing.Point(429, 33);
            this.listViewMovies.Name = "listViewMovies";
            this.listViewMovies.Size = new System.Drawing.Size(366, 300);
            this.listViewMovies.TabIndex = 6;
            this.listViewMovies.UseCompatibleStateImageBehavior = false;
            this.listViewMovies.View = System.Windows.Forms.View.Details;
            this.listViewMovies.SelectedIndexChanged += new System.EventHandler(this.ListViewMovies_SelectedIndexChanged);
            // 
            // labelChosenMovie
            // 
            this.labelChosenMovie.AutoSize = true;
            this.labelChosenMovie.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelChosenMovie.Location = new System.Drawing.Point(27, 282);
            this.labelChosenMovie.Name = "labelChosenMovie";
            this.labelChosenMovie.Size = new System.Drawing.Size(52, 20);
            this.labelChosenMovie.TabIndex = 7;
            this.labelChosenMovie.Text = "Movie";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(2, 415);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 8;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(99, 415);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelDateString
            // 
            this.labelDateString.AutoSize = true;
            this.labelDateString.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDateString.Location = new System.Drawing.Point(27, 114);
            this.labelDateString.Name = "labelDateString";
            this.labelDateString.Size = new System.Drawing.Size(0, 20);
            this.labelDateString.TabIndex = 10;
            // 
            // labelAuditoriumName
            // 
            this.labelAuditoriumName.AutoSize = true;
            this.labelAuditoriumName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAuditoriumName.Location = new System.Drawing.Point(27, 63);
            this.labelAuditoriumName.Name = "labelAuditoriumName";
            this.labelAuditoriumName.Size = new System.Drawing.Size(0, 20);
            this.labelAuditoriumName.TabIndex = 11;
            // 
            // labelMovieTitle
            // 
            this.labelMovieTitle.AutoSize = true;
            this.labelMovieTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMovieTitle.Location = new System.Drawing.Point(27, 313);
            this.labelMovieTitle.Name = "labelMovieTitle";
            this.labelMovieTitle.Size = new System.Drawing.Size(0, 20);
            this.labelMovieTitle.TabIndex = 12;
            // 
            // comboBoxStartTime
            // 
            this.comboBoxStartTime.FormattingEnabled = true;
            this.comboBoxStartTime.Location = new System.Drawing.Point(27, 171);
            this.comboBoxStartTime.Name = "comboBoxStartTime";
            this.comboBoxStartTime.Size = new System.Drawing.Size(94, 23);
            this.comboBoxStartTime.TabIndex = 13;
            // 
            // textBoxEndTime
            // 
            this.textBoxEndTime.Location = new System.Drawing.Point(27, 240);
            this.textBoxEndTime.Name = "textBoxEndTime";
            this.textBoxEndTime.Size = new System.Drawing.Size(100, 23);
            this.textBoxEndTime.TabIndex = 14;
            // 
            // CreateShowingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxEndTime);
            this.Controls.Add(this.comboBoxStartTime);
            this.Controls.Add(this.labelMovieTitle);
            this.Controls.Add(this.labelAuditoriumName);
            this.Controls.Add(this.labelDateString);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.labelChosenMovie);
            this.Controls.Add(this.listViewMovies);
            this.Controls.Add(this.labelEndTime);
            this.Controls.Add(this.labelStartTime);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelAuditorium);
            this.Name = "CreateShowingView";
            this.Text = "CreateShowingView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAuditorium;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelStartTime;
        private System.Windows.Forms.Label labelEndTime;
        private System.Windows.Forms.ListView listViewMovies;
        private System.Windows.Forms.Label labelChosenMovie;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelDateString;
        private System.Windows.Forms.Label labelAuditoriumName;
        private System.Windows.Forms.Label labelMovieTitle;
        private System.Windows.Forms.ComboBox comboBoxStartTime;
        private System.Windows.Forms.TextBox textBoxEndTime;
    }
}