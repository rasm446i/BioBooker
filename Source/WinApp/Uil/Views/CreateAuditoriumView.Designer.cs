namespace BioBooker.WinApp.Uil.Views
{
    partial class CreateAuditoriumView
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
            this.btnCreateAuditorium = new System.Windows.Forms.Button();
            this.txtSeatRows = new System.Windows.Forms.TextBox();
            this.lblSeatRows = new System.Windows.Forms.Label();
            this.txtSeatNumbers = new System.Windows.Forms.TextBox();
            this.lblSeatNumbers = new System.Windows.Forms.Label();
            this.txtAuditoriumName = new System.Windows.Forms.TextBox();
            this.lblAuditoriumName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCreateAuditorium
            // 
            this.btnCreateAuditorium.Location = new System.Drawing.Point(22, 207);
            this.btnCreateAuditorium.Name = "btnCreateAuditorium";
            this.btnCreateAuditorium.Size = new System.Drawing.Size(126, 23);
            this.btnCreateAuditorium.TabIndex = 0;
            this.btnCreateAuditorium.Text = "Create Auditorium";
            this.btnCreateAuditorium.UseVisualStyleBackColor = true;
            this.btnCreateAuditorium.Click += new System.EventHandler(this.btnCreateAuditorium_Click);
            // 
            // txtSeatRows
            // 
            this.txtSeatRows.Location = new System.Drawing.Point(22, 68);
            this.txtSeatRows.Name = "txtSeatRows";
            this.txtSeatRows.Size = new System.Drawing.Size(100, 23);
            this.txtSeatRows.TabIndex = 1;
            // 
            // lblSeatRows
            // 
            this.lblSeatRows.AutoSize = true;
            this.lblSeatRows.Location = new System.Drawing.Point(22, 41);
            this.lblSeatRows.Name = "lblSeatRows";
            this.lblSeatRows.Size = new System.Drawing.Size(57, 15);
            this.lblSeatRows.TabIndex = 2;
            this.lblSeatRows.Text = "Seat rows";
            // 
            // txtSeatNumbers
            // 
            this.txtSeatNumbers.Location = new System.Drawing.Point(22, 147);
            this.txtSeatNumbers.Name = "txtSeatNumbers";
            this.txtSeatNumbers.Size = new System.Drawing.Size(100, 23);
            this.txtSeatNumbers.TabIndex = 3;
            // 
            // lblSeatNumbers
            // 
            this.lblSeatNumbers.AutoSize = true;
            this.lblSeatNumbers.Location = new System.Drawing.Point(22, 129);
            this.lblSeatNumbers.Name = "lblSeatNumbers";
            this.lblSeatNumbers.Size = new System.Drawing.Size(79, 15);
            this.lblSeatNumbers.TabIndex = 4;
            this.lblSeatNumbers.Text = "Seat numbers";
            // 
            // txtAuditoriumName
            // 
            this.txtAuditoriumName.Location = new System.Drawing.Point(171, 68);
            this.txtAuditoriumName.Name = "txtAuditoriumName";
            this.txtAuditoriumName.Size = new System.Drawing.Size(100, 23);
            this.txtAuditoriumName.TabIndex = 5;
            // 
            // lblAuditoriumName
            // 
            this.lblAuditoriumName.AutoSize = true;
            this.lblAuditoriumName.Location = new System.Drawing.Point(171, 41);
            this.lblAuditoriumName.Name = "lblAuditoriumName";
            this.lblAuditoriumName.Size = new System.Drawing.Size(101, 15);
            this.lblAuditoriumName.TabIndex = 6;
            this.lblAuditoriumName.Text = "Auditorium name";
            // 
            // CreateAuditoriumView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAuditoriumName);
            this.Controls.Add(this.txtAuditoriumName);
            this.Controls.Add(this.lblSeatNumbers);
            this.Controls.Add(this.txtSeatNumbers);
            this.Controls.Add(this.lblSeatRows);
            this.Controls.Add(this.txtSeatRows);
            this.Controls.Add(this.btnCreateAuditorium);
            this.Name = "CreateAuditoriumView";
            this.Text = "CreateAuditoriumView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateAuditorium;
        private System.Windows.Forms.TextBox txtSeatRows;
        private System.Windows.Forms.Label lblSeatRows;
        private System.Windows.Forms.TextBox txtSeatNumbers;
        private System.Windows.Forms.Label lblSeatNumbers;
        private System.Windows.Forms.TextBox txtAuditoriumName;
        private System.Windows.Forms.Label lblAuditoriumName;
    }
}