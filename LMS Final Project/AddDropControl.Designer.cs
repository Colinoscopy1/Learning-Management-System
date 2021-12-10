
namespace LMS_Final_Project
{
    partial class AddDropControl
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
            this.lstEnrolled = new System.Windows.Forms.ListBox();
            this.btnDrop = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblClassName = new System.Windows.Forms.Label();
            this.lblClassNum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstEnrolled
            // 
            this.lstEnrolled.FormattingEnabled = true;
            this.lstEnrolled.ItemHeight = 15;
            this.lstEnrolled.Location = new System.Drawing.Point(16, 73);
            this.lstEnrolled.Name = "lstEnrolled";
            this.lstEnrolled.Size = new System.Drawing.Size(323, 409);
            this.lstEnrolled.TabIndex = 1;
            // 
            // btnDrop
            // 
            this.btnDrop.Location = new System.Drawing.Point(16, 488);
            this.btnDrop.Name = "btnDrop";
            this.btnDrop.Size = new System.Drawing.Size(136, 23);
            this.btnDrop.TabIndex = 2;
            this.btnDrop.Text = "Drop Course";
            this.btnDrop.UseVisualStyleBackColor = true;
            this.btnDrop.Click += new System.EventHandler(this.btnDrop_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(665, 113);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(136, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add Course";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblClassName.Location = new System.Drawing.Point(360, 73);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(441, 32);
            this.lblClassName.TabIndex = 4;
            this.lblClassName.Text = "Dynamic Web Application Development";
            // 
            // lblClassNum
            // 
            this.lblClassNum.AutoSize = true;
            this.lblClassNum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblClassNum.Location = new System.Drawing.Point(364, 112);
            this.lblClassNum.Name = "lblClassNum";
            this.lblClassNum.Size = new System.Drawing.Size(67, 21);
            this.lblClassNum.TabIndex = 5;
            this.lblClassNum.Text = "ITEC999";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(364, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "ITEC999";
            // 
            // AddDropControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblClassNum);
            this.Controls.Add(this.lblClassName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDrop);
            this.Controls.Add(this.lstEnrolled);
            this.Name = "AddDropControl";
            this.Size = new System.Drawing.Size(841, 529);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstEnrolled;
        private System.Windows.Forms.Button btnDrop;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.Label lblClassNum;
        private System.Windows.Forms.Label label1;
    }
}
