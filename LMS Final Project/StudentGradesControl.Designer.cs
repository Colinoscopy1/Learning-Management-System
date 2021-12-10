
namespace LMS_Final_Project
{
    partial class StudentGradesControl
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
            this.lstPosts = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFinalGrade = new System.Windows.Forms.Label();
            this.lblFinal = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHIGrade = new System.Windows.Forms.Label();
            this.lblPostName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstPosts
            // 
            this.lstPosts.FormattingEnabled = true;
            this.lstPosts.ItemHeight = 15;
            this.lstPosts.Location = new System.Drawing.Point(13, 105);
            this.lstPosts.Name = "lstPosts";
            this.lstPosts.Size = new System.Drawing.Size(244, 349);
            this.lstPosts.TabIndex = 0;
            this.lstPosts.SelectedIndexChanged += new System.EventHandler(this.lstPosts_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lblFinalGrade);
            this.panel1.Controls.Add(this.lblFinal);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 83);
            this.panel1.TabIndex = 3;
            // 
            // lblFinalGrade
            // 
            this.lblFinalGrade.AutoSize = true;
            this.lblFinalGrade.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFinalGrade.ForeColor = System.Drawing.SystemColors.Window;
            this.lblFinalGrade.Location = new System.Drawing.Point(769, 25);
            this.lblFinalGrade.Name = "lblFinalGrade";
            this.lblFinalGrade.Size = new System.Drawing.Size(48, 32);
            this.lblFinalGrade.TabIndex = 1;
            this.lblFinalGrade.Text = "A+";
            // 
            // lblFinal
            // 
            this.lblFinal.AutoSize = true;
            this.lblFinal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFinal.ForeColor = System.Drawing.SystemColors.Window;
            this.lblFinal.Location = new System.Drawing.Point(602, 25);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new System.Drawing.Size(150, 32);
            this.lblFinal.TabIndex = 0;
            this.lblFinal.Text = "Final Grade:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(-1, 473);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(849, 57);
            this.panel2.TabIndex = 16;
            // 
            // lblHIGrade
            // 
            this.lblHIGrade.AutoSize = true;
            this.lblHIGrade.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHIGrade.Location = new System.Drawing.Point(278, 156);
            this.lblHIGrade.Name = "lblHIGrade";
            this.lblHIGrade.Size = new System.Drawing.Size(40, 32);
            this.lblHIGrade.TabIndex = 17;
            this.lblHIGrade.Text = "80";
            // 
            // lblPostName
            // 
            this.lblPostName.AutoSize = true;
            this.lblPostName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPostName.Location = new System.Drawing.Point(278, 105);
            this.lblPostName.Name = "lblPostName";
            this.lblPostName.Size = new System.Drawing.Size(40, 32);
            this.lblPostName.TabIndex = 18;
            this.lblPostName.Text = "80";
            // 
            // StudentGradesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPostName);
            this.Controls.Add(this.lblHIGrade);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstPosts);
            this.Name = "StudentGradesControl";
            this.Size = new System.Drawing.Size(841, 529);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstPosts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblFinalGrade;
        private System.Windows.Forms.Label lblFinal;
        private System.Windows.Forms.Label lblHIGrade;
        private System.Windows.Forms.Label lblPostName;
    }
}
