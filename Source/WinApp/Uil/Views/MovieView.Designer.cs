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
            btnClose = new System.Windows.Forms.Button();
            pnlButtons = new System.Windows.Forms.Panel();
            pnlInputs = new System.Windows.Forms.Panel();
            lblGenre = new System.Windows.Forms.Label();
            lblMpaaRating = new System.Windows.Forms.Label();
            lblReleaseYear = new System.Windows.Forms.Label();
            txtTitle = new System.Windows.Forms.TextBox();
            lblTitle = new System.Windows.Forms.Label();
            pnlOutputs = new System.Windows.Forms.Panel();
            txtReleaseYear = new System.Windows.Forms.TextBox();
            txtMpaaRating = new System.Windows.Forms.TextBox();
            txtGenre = new System.Windows.Forms.TextBox();
            btnAddPoster = new System.Windows.Forms.Button();
            pnlButtons.SuspendLayout();
            pnlInputs.SuspendLayout();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Location = new System.Drawing.Point(745, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(110, 25);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnCloseClick;
            // 
            // pnlButtons
            // 
            pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlButtons.Controls.Add(btnClose);
            pnlButtons.Location = new System.Drawing.Point(12, 415);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new System.Drawing.Size(860, 34);
            pnlButtons.TabIndex = 1;
            // 
            // pnlInputs
            // 
            pnlInputs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlInputs.Controls.Add(btnAddPoster);
            pnlInputs.Controls.Add(txtGenre);
            pnlInputs.Controls.Add(txtMpaaRating);
            pnlInputs.Controls.Add(txtReleaseYear);
            pnlInputs.Controls.Add(lblGenre);
            pnlInputs.Controls.Add(lblMpaaRating);
            pnlInputs.Controls.Add(lblReleaseYear);
            pnlInputs.Controls.Add(txtTitle);
            pnlInputs.Controls.Add(lblTitle);
            pnlInputs.Location = new System.Drawing.Point(12, 12);
            pnlInputs.Name = "pnlInputs";
            pnlInputs.Size = new System.Drawing.Size(422, 392);
            pnlInputs.TabIndex = 2;
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblGenre.Location = new System.Drawing.Point(13, 197);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new System.Drawing.Size(51, 20);
            lblGenre.TabIndex = 4;
            lblGenre.Text = "Genre";
            // 
            // lblMpaaRating
            // 
            lblMpaaRating.AutoSize = true;
            lblMpaaRating.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblMpaaRating.Location = new System.Drawing.Point(13, 135);
            lblMpaaRating.Name = "lblMpaaRating";
            lblMpaaRating.Size = new System.Drawing.Size(103, 20);
            lblMpaaRating.TabIndex = 3;
            lblMpaaRating.Text = "MPAA Rating";
            // 
            // lblReleaseYear
            // 
            lblReleaseYear.AutoSize = true;
            lblReleaseYear.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblReleaseYear.Location = new System.Drawing.Point(13, 73);
            lblReleaseYear.Name = "lblReleaseYear";
            lblReleaseYear.Size = new System.Drawing.Size(92, 20);
            lblReleaseYear.TabIndex = 2;
            lblReleaseYear.Text = "ReleaseYear";
            lblReleaseYear.Click += lblReleaseYear_Click;
            // 
            // txtTitle
            // 
            txtTitle.Location = new System.Drawing.Point(13, 36);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new System.Drawing.Size(392, 23);
            txtTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTitle.Location = new System.Drawing.Point(13, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(40, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title";
            lblTitle.Click += label1_Click;
            // 
            // pnlOutputs
            // 
            pnlOutputs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlOutputs.Location = new System.Drawing.Point(450, 12);
            pnlOutputs.Name = "pnlOutputs";
            pnlOutputs.Size = new System.Drawing.Size(422, 392);
            pnlOutputs.TabIndex = 3;
            // 
            // txtReleaseYear
            // 
            txtReleaseYear.Location = new System.Drawing.Point(13, 96);
            txtReleaseYear.Name = "txtReleaseYear";
            txtReleaseYear.Size = new System.Drawing.Size(392, 23);
            txtReleaseYear.TabIndex = 6;
            // 
            // txtMpaaRating
            // 
            txtMpaaRating.Location = new System.Drawing.Point(13, 158);
            txtMpaaRating.Name = "txtMpaaRating";
            txtMpaaRating.Size = new System.Drawing.Size(392, 23);
            txtMpaaRating.TabIndex = 7;
            // 
            // txtGenre
            // 
            txtGenre.Location = new System.Drawing.Point(13, 220);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new System.Drawing.Size(392, 23);
            txtGenre.TabIndex = 8;
            // 
            // btnAddPoster
            // 
            btnAddPoster.Location = new System.Drawing.Point(13, 261);
            btnAddPoster.Name = "btnAddPoster";
            btnAddPoster.Size = new System.Drawing.Size(110, 25);
            btnAddPoster.TabIndex = 9;
            btnAddPoster.Text = "Add Poster";
            btnAddPoster.UseVisualStyleBackColor = true;
            btnAddPoster.Click += BtnAddPosterClick;
            // 
            // MovieView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(884, 461);
            Controls.Add(pnlOutputs);
            Controls.Add(pnlInputs);
            Controls.Add(pnlButtons);
            Name = "MovieView";
            Text = "MovieView";
            pnlButtons.ResumeLayout(false);
            pnlInputs.ResumeLayout(false);
            pnlInputs.PerformLayout();
            ResumeLayout(false);
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
        private System.Windows.Forms.TextBox txtReleaseYear;
        private System.Windows.Forms.Button btnAddPoster;
    }
}