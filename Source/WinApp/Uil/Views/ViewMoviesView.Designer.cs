namespace BioBooker.WinApp.Uil.Views
{
    partial class ViewMoviesView
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
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.textBoxSortBy = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonSortBy = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.buttonDetails = new System.Windows.Forms.Button();
            this.labelNoMovieFound = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(206, 21);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(100, 23);
            this.textBoxSearch.TabIndex = 1;
            // 
            // textBoxSortBy
            // 
            this.textBoxSortBy.Location = new System.Drawing.Point(206, 92);
            this.textBoxSortBy.Name = "textBoxSortBy";
            this.textBoxSortBy.Size = new System.Drawing.Size(100, 23);
            this.textBoxSortBy.TabIndex = 2;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(109, 21);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(91, 23);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonSortBy
            // 
            this.buttonSortBy.Location = new System.Drawing.Point(109, 92);
            this.buttonSortBy.Name = "buttonSortBy";
            this.buttonSortBy.Size = new System.Drawing.Size(91, 23);
            this.buttonSortBy.TabIndex = 4;
            this.buttonSortBy.Text = "Sort by";
            this.buttonSortBy.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(206, 202);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(91, 23);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "Delete movie";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(689, 415);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(91, 23);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(355, 21);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(425, 379);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // buttonDetails
            // 
            this.buttonDetails.Location = new System.Drawing.Point(206, 151);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(91, 23);
            this.buttonDetails.TabIndex = 9;
            this.buttonDetails.Text = "Details";
            this.buttonDetails.UseVisualStyleBackColor = true;
            this.buttonDetails.Click += new System.EventHandler(this.buttonDetails_Click);
            // 
            // labelNoMovieFound
            // 
            this.labelNoMovieFound.AutoSize = true;
            this.labelNoMovieFound.ForeColor = System.Drawing.Color.IndianRed;
            this.labelNoMovieFound.Location = new System.Drawing.Point(143, 47);
            this.labelNoMovieFound.Name = "labelNoMovieFound";
            this.labelNoMovieFound.Size = new System.Drawing.Size(0, 15);
            this.labelNoMovieFound.TabIndex = 10;
            // 
            // ViewMoviesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelNoMovieFound);
            this.Controls.Add(this.buttonDetails);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSortBy);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSortBy);
            this.Controls.Add(this.textBoxSearch);
            this.Name = "ViewMoviesView";
            this.Text = "ViewMoviesView";
            this.Load += new System.EventHandler(this.ViewMoviesView_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.TextBox textBoxSortBy;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonSortBy;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonDetails;
        private System.Windows.Forms.Label labelNoMovieFound;
    }
}