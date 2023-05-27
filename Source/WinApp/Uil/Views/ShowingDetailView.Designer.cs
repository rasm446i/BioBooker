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
            this.buttonCreate = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelAuditoriumTitle = new System.Windows.Forms.Label();
            this.labelNoShowingsFound = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelAuditorium = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(12, 297);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 2;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 9);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(354, 273);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(382, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(185, 23);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // labelAuditoriumTitle
            // 
            this.labelAuditoriumTitle.AutoSize = true;
            this.labelAuditoriumTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAuditoriumTitle.Location = new System.Drawing.Point(382, 71);
            this.labelAuditoriumTitle.Name = "labelAuditoriumTitle";
            this.labelAuditoriumTitle.Size = new System.Drawing.Size(90, 20);
            this.labelAuditoriumTitle.TabIndex = 8;
            this.labelAuditoriumTitle.Text = "Auditorium";
            // 
            // labelNoShowingsFound
            // 
            this.labelNoShowingsFound.AutoSize = true;
            this.labelNoShowingsFound.Location = new System.Drawing.Point(116, 287);
            this.labelNoShowingsFound.Name = "labelNoShowingsFound";
            this.labelNoShowingsFound.Size = new System.Drawing.Size(0, 15);
            this.labelNoShowingsFound.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(382, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Pick a date";
            // 
            // labelAuditorium
            // 
            this.labelAuditorium.AutoSize = true;
            this.labelAuditorium.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAuditorium.Location = new System.Drawing.Point(382, 101);
            this.labelAuditorium.Name = "labelAuditorium";
            this.labelAuditorium.Size = new System.Drawing.Size(0, 20);
            this.labelAuditorium.TabIndex = 12;
            // 
            // ShowingDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelAuditorium);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelNoShowingsFound);
            this.Controls.Add(this.labelAuditoriumTitle);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buttonCreate);
            this.Name = "ShowingDetailView";
            this.Text = "ShowingDetailView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelAuditoriumTitle;
        private System.Windows.Forms.Label labelNoShowingsFound;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAuditorium;
    }
}