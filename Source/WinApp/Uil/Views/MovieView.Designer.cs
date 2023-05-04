namespace BioBooker.WinApp.Uil.Views
{
    partial class MovieView
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
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.pnlInputs = new System.Windows.Forms.Panel();
            this.comboBoxGenre = new System.Windows.Forms.ComboBox();
            this.comboBoxMpaRating = new System.Windows.Forms.ComboBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labelPremierDate = new System.Windows.Forms.Label();
            this.labelRuntime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textReleaseYear = new System.Windows.Forms.TextBox();
            this.textLanguage = new System.Windows.Forms.TextBox();
            this.textBoxPremierDate = new System.Windows.Forms.TextBox();
            this.textBoxRunTime = new System.Windows.Forms.TextBox();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.txtMpaaRating = new System.Windows.Forms.TextBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblMpaaRating = new System.Windows.Forms.Label();
            this.lblReleaseYear = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAddPoster = new System.Windows.Forms.Button();
            this.pnlOutputs = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnlButtons.SuspendLayout();
            this.pnlInputs.SuspendLayout();
            this.pnlOutputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            // pnlButtons
            // 
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Location = new System.Drawing.Point(12, 415);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(860, 34);
            this.pnlButtons.TabIndex = 1;
            // 
            // pnlInputs
            // 
            this.pnlInputs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInputs.Controls.Add(this.comboBoxGenre);
            this.pnlInputs.Controls.Add(this.comboBoxMpaRating);
            this.pnlInputs.Controls.Add(this.checkedListBox1);
            this.pnlInputs.Controls.Add(this.label8);
            this.pnlInputs.Controls.Add(this.labelPremierDate);
            this.pnlInputs.Controls.Add(this.labelRuntime);
            this.pnlInputs.Controls.Add(this.label4);
            this.pnlInputs.Controls.Add(this.label3);
            this.pnlInputs.Controls.Add(this.label2);
            this.pnlInputs.Controls.Add(this.label1);
            this.pnlInputs.Controls.Add(this.textReleaseYear);
            this.pnlInputs.Controls.Add(this.textLanguage);
            this.pnlInputs.Controls.Add(this.textBoxPremierDate);
            this.pnlInputs.Controls.Add(this.textBoxRunTime);
            this.pnlInputs.Controls.Add(this.txtGenre);
            this.pnlInputs.Controls.Add(this.txtMpaaRating);
            this.pnlInputs.Controls.Add(this.lblGenre);
            this.pnlInputs.Controls.Add(this.lblMpaaRating);
            this.pnlInputs.Controls.Add(this.lblReleaseYear);
            this.pnlInputs.Controls.Add(this.txtTitle);
            this.pnlInputs.Controls.Add(this.lblTitle);
            this.pnlInputs.Location = new System.Drawing.Point(12, 12);
            this.pnlInputs.Name = "pnlInputs";
            this.pnlInputs.Size = new System.Drawing.Size(422, 392);
            this.pnlInputs.TabIndex = 2;
            this.pnlInputs.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInputs_Paint);
            // 
            // comboBoxGenre
            // 
            this.comboBoxGenre.FormattingEnabled = true;
            this.comboBoxGenre.Location = new System.Drawing.Point(118, 113);
            this.comboBoxGenre.Name = "comboBoxGenre";
            this.comboBoxGenre.Size = new System.Drawing.Size(121, 23);
            this.comboBoxGenre.TabIndex = 29;
            // 
            // comboBoxMpaRating
            // 
            this.comboBoxMpaRating.FormattingEnabled = true;
            this.comboBoxMpaRating.Location = new System.Drawing.Point(118, 36);
            this.comboBoxMpaRating.Name = "comboBoxMpaRating";
            this.comboBoxMpaRating.Size = new System.Drawing.Size(121, 23);
            this.comboBoxMpaRating.TabIndex = 28;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(297, 36);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 94);
            this.checkedListBox1.TabIndex = 27;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(12, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 20);
            this.label8.TabIndex = 25;
            this.label8.Text = "Director";
            // 
            // labelPremierDate
            // 
            this.labelPremierDate.AutoSize = true;
            this.labelPremierDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPremierDate.Location = new System.Drawing.Point(118, 242);
            this.labelPremierDate.Name = "labelPremierDate";
            this.labelPremierDate.Size = new System.Drawing.Size(101, 20);
            this.labelPremierDate.TabIndex = 22;
            this.labelPremierDate.Text = "Premier Date";
            // 
            // labelRuntime
            // 
            this.labelRuntime.AutoSize = true;
            this.labelRuntime.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelRuntime.Location = new System.Drawing.Point(118, 168);
            this.labelRuntime.Name = "labelRuntime";
            this.labelRuntime.Size = new System.Drawing.Size(69, 20);
            this.labelRuntime.TabIndex = 20;
            this.labelRuntime.Text = "Runtime";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(118, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "MPA Rating";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(303, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Subtitles";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(13, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Release Year";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Language";
            // 
            // textReleaseYear
            // 
            this.textReleaseYear.Location = new System.Drawing.Point(13, 342);
            this.textReleaseYear.Name = "textReleaseYear";
            this.textReleaseYear.Size = new System.Drawing.Size(78, 23);
            this.textReleaseYear.TabIndex = 15;
            // 
            // textLanguage
            // 
            this.textLanguage.Location = new System.Drawing.Point(13, 265);
            this.textLanguage.Name = "textLanguage";
            this.textLanguage.Size = new System.Drawing.Size(78, 23);
            this.textLanguage.TabIndex = 14;
            // 
            // textBoxPremierDate
            // 
            this.textBoxPremierDate.Location = new System.Drawing.Point(118, 265);
            this.textBoxPremierDate.Name = "textBoxPremierDate";
            this.textBoxPremierDate.Size = new System.Drawing.Size(78, 23);
            this.textBoxPremierDate.TabIndex = 13;
            // 
            // textBoxRunTime
            // 
            this.textBoxRunTime.Location = new System.Drawing.Point(118, 194);
            this.textBoxRunTime.Name = "textBoxRunTime";
            this.textBoxRunTime.Size = new System.Drawing.Size(78, 23);
            this.textBoxRunTime.TabIndex = 12;
            // 
            // txtGenre
            // 
            this.txtGenre.Location = new System.Drawing.Point(11, 194);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(78, 23);
            this.txtGenre.TabIndex = 8;
            this.txtGenre.TextChanged += new System.EventHandler(this.txtGenre_TextChanged);
            // 
            // txtMpaaRating
            // 
            this.txtMpaaRating.Location = new System.Drawing.Point(11, 113);
            this.txtMpaaRating.Name = "txtMpaaRating";
            this.txtMpaaRating.Size = new System.Drawing.Size(78, 23);
            this.txtMpaaRating.TabIndex = 7;
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGenre.Location = new System.Drawing.Point(13, 197);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(0, 20);
            this.lblGenre.TabIndex = 4;
            // 
            // lblMpaaRating
            // 
            this.lblMpaaRating.AutoSize = true;
            this.lblMpaaRating.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMpaaRating.Location = new System.Drawing.Point(13, 90);
            this.lblMpaaRating.Name = "lblMpaaRating";
            this.lblMpaaRating.Size = new System.Drawing.Size(48, 20);
            this.lblMpaaRating.TabIndex = 3;
            this.lblMpaaRating.Text = "Actor";
            // 
            // lblReleaseYear
            // 
            this.lblReleaseYear.AutoSize = true;
            this.lblReleaseYear.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblReleaseYear.Location = new System.Drawing.Point(118, 90);
            this.lblReleaseYear.Name = "lblReleaseYear";
            this.lblReleaseYear.Size = new System.Drawing.Size(51, 20);
            this.lblReleaseYear.TabIndex = 2;
            this.lblReleaseYear.Text = "Genre";
            this.lblReleaseYear.Click += new System.EventHandler(this.lblReleaseYear_Click_1);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(13, 36);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(78, 23);
            this.txtTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(13, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(40, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            // 
            // btnAddPoster
            // 
            this.btnAddPoster.Location = new System.Drawing.Point(-1, 366);
            this.btnAddPoster.Name = "btnAddPoster";
            this.btnAddPoster.Size = new System.Drawing.Size(110, 25);
            this.btnAddPoster.TabIndex = 9;
            this.btnAddPoster.Text = "Add Poster";
            this.btnAddPoster.UseVisualStyleBackColor = true;
            this.btnAddPoster.Click += new System.EventHandler(this.btnAddPoster_Click);
            // 
            // pnlOutputs
            // 
            this.pnlOutputs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOutputs.Controls.Add(this.pictureBox1);
            this.pnlOutputs.Controls.Add(this.btnAddPoster);
            this.pnlOutputs.Location = new System.Drawing.Point(450, 12);
            this.pnlOutputs.Name = "pnlOutputs";
            this.pnlOutputs.Size = new System.Drawing.Size(422, 392);
            this.pnlOutputs.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(414, 335);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MovieView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.pnlOutputs);
            this.Controls.Add(this.pnlInputs);
            this.Controls.Add(this.pnlButtons);
            this.Name = "MovieView";
            this.Text = "MovieView";
            this.pnlButtons.ResumeLayout(false);
            this.pnlInputs.ResumeLayout(false);
            this.pnlInputs.PerformLayout();
            this.pnlOutputs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel pnlInputs;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblReleaseYear;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblMpaaRating;
        private System.Windows.Forms.Panel pnlOutputs;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.TextBox txtMpaaRating;
        private System.Windows.Forms.Button btnAddPoster;
        private System.Windows.Forms.TextBox textReleaseYear;
        private System.Windows.Forms.TextBox textLanguage;
        private System.Windows.Forms.TextBox textBoxPremierDate;
        private System.Windows.Forms.Label labelPremierDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxGenre;
        private System.Windows.Forms.ComboBox comboBoxMpaRating;
        private System.Windows.Forms.Label labelRuntime;
        private System.Windows.Forms.TextBox textBoxRunTime;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}