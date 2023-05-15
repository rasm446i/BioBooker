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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelStartTime = new System.Windows.Forms.Label();
            this.labelEndTime = new System.Windows.Forms.Label();
            this.listViewMovies = new System.Windows.Forms.ListView();
            this.labelChosenMovie = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelAuditorium
            // 
            this.labelAuditorium.AutoSize = true;
            this.labelAuditorium.Location = new System.Drawing.Point(2, 54);
            this.labelAuditorium.Name = "labelAuditorium";
            this.labelAuditorium.Size = new System.Drawing.Size(71, 15);
            this.labelAuditorium.TabIndex = 0;
            this.labelAuditorium.Text = "Auditorium:";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(2, 92);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(34, 15);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "Date:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(2, 166);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(2, 235);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 3;
            // 
            // labelStartTime
            // 
            this.labelStartTime.AutoSize = true;
            this.labelStartTime.Location = new System.Drawing.Point(2, 145);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Size = new System.Drawing.Size(82, 15);
            this.labelStartTime.TabIndex = 4;
            this.labelStartTime.Text = "labelStartTime";
            // 
            // labelEndTime
            // 
            this.labelEndTime.AutoSize = true;
            this.labelEndTime.Location = new System.Drawing.Point(2, 217);
            this.labelEndTime.Name = "labelEndTime";
            this.labelEndTime.Size = new System.Drawing.Size(78, 15);
            this.labelEndTime.TabIndex = 5;
            this.labelEndTime.Text = "labelEndTime";
            // 
            // listViewMovies
            // 
            this.listViewMovies.Location = new System.Drawing.Point(523, 33);
            this.listViewMovies.Name = "listViewMovies";
            this.listViewMovies.Size = new System.Drawing.Size(272, 300);
            this.listViewMovies.TabIndex = 6;
            this.listViewMovies.UseCompatibleStateImageBehavior = false;
            // 
            // labelChosenMovie
            // 
            this.labelChosenMovie.AutoSize = true;
            this.labelChosenMovie.Location = new System.Drawing.Point(2, 277);
            this.labelChosenMovie.Name = "labelChosenMovie";
            this.labelChosenMovie.Size = new System.Drawing.Size(46, 15);
            this.labelChosenMovie.TabIndex = 7;
            this.labelChosenMovie.Text = "Movie: ";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(2, 415);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 8;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
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
            // CreateShowingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.labelChosenMovie);
            this.Controls.Add(this.listViewMovies);
            this.Controls.Add(this.labelEndTime);
            this.Controls.Add(this.labelStartTime);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelStartTime;
        private System.Windows.Forms.Label labelEndTime;
        private System.Windows.Forms.ListView listViewMovies;
        private System.Windows.Forms.Label labelChosenMovie;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonCancel;
    }
}