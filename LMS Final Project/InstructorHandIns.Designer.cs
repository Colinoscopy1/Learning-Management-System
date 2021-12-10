
namespace LMS_Final_Project
{
    partial class InstructorHandIns
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lstPosts = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.lblDetails = new System.Windows.Forms.Label();
            this.btnGrade = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 56);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, 473);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(841, 56);
            this.panel3.TabIndex = 2;
            // 
            // lstPosts
            // 
            this.lstPosts.FormattingEnabled = true;
            this.lstPosts.ItemHeight = 15;
            this.lstPosts.Location = new System.Drawing.Point(12, 88);
            this.lstPosts.Name = "lstPosts";
            this.lstPosts.Size = new System.Drawing.Size(344, 379);
            this.lstPosts.TabIndex = 3;
            this.lstPosts.SelectedIndexChanged += new System.EventHandler(this.lstPosts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ungraded Hand Ins:";
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(371, 125);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 23);
            this.btnFile.TabIndex = 5;
            this.btnFile.Text = "Get File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // txtGrade
            // 
            this.txtGrade.Location = new System.Drawing.Point(629, 126);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(64, 23);
            this.txtGrade.TabIndex = 6;
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDetails.Location = new System.Drawing.Point(371, 88);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(57, 21);
            this.lblDetails.TabIndex = 7;
            this.lblDetails.Text = "label2";
            // 
            // btnGrade
            // 
            this.btnGrade.Location = new System.Drawing.Point(699, 125);
            this.btnGrade.Name = "btnGrade";
            this.btnGrade.Size = new System.Drawing.Size(113, 23);
            this.btnGrade.TabIndex = 8;
            this.btnGrade.Text = "Assign Grade";
            this.btnGrade.UseVisualStyleBackColor = true;
            this.btnGrade.Click += new System.EventHandler(this.btnGrade_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(582, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Grade:";
            // 
            // InstructorHandIns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGrade);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.txtGrade);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstPosts);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "InstructorHandIns";
            this.Size = new System.Drawing.Size(841, 529);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox lstPosts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox txtGrade;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Button btnGrade;
        private System.Windows.Forms.Label label2;
    }
}
