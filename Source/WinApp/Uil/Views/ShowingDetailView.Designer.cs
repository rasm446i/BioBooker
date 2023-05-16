namespace BioBooker.WinApp.Uil.Views
{
    partial class ShowingDetailView
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
            this.buttonDetails = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelAuditorium = new System.Windows.Forms.Label();
            this.textBoxSearchShowing = new System.Windows.Forms.TextBox();
            this.labelNoShowingsFound = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonDetails
            // 
            this.buttonDetails.Location = new System.Drawing.Point(12, 344);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(75, 23);
            this.buttonDetails.TabIndex = 1;
            this.buttonDetails.Text = "Details";
            this.buttonDetails.UseVisualStyleBackColor = true;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(114, 385);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 2;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(12, 385);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(12, 304);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(5, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(250, 273);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(312, 9);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(134, 23);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // labelAuditorium
            // 
            this.labelAuditorium.AutoSize = true;
            this.labelAuditorium.Location = new System.Drawing.Point(643, 9);
            this.labelAuditorium.Name = "labelAuditorium";
            this.labelAuditorium.Size = new System.Drawing.Size(74, 15);
            this.labelAuditorium.TabIndex = 8;
            this.labelAuditorium.Text = "Auditorium: ";
            // 
            // textBoxSearchShowing
            // 
            this.textBoxSearchShowing.Location = new System.Drawing.Point(114, 304);
            this.textBoxSearchShowing.Name = "textBoxSearchShowing";
            this.textBoxSearchShowing.PlaceholderText = "Movie Title...";
            this.textBoxSearchShowing.Size = new System.Drawing.Size(141, 23);
            this.textBoxSearchShowing.TabIndex = 9;
            // 
            // labelNoShowingsFound
            // 
            this.labelNoShowingsFound.AutoSize = true;
            this.labelNoShowingsFound.Location = new System.Drawing.Point(116, 287);
            this.labelNoShowingsFound.Name = "labelNoShowingsFound";
            this.labelNoShowingsFound.Size = new System.Drawing.Size(0, 15);
            this.labelNoShowingsFound.TabIndex = 10;
            // 
            // ShowingDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelNoShowingsFound);
            this.Controls.Add(this.textBoxSearchShowing);
            this.Controls.Add(this.labelAuditorium);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonDetails);
            this.Name = "ShowingDetailView";
            this.Text = "ShowingDetailView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonDetails;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelAuditorium;
        private System.Windows.Forms.TextBox textBoxSearchShowing;
        private System.Windows.Forms.Label labelNoShowingsFound;
    }
}