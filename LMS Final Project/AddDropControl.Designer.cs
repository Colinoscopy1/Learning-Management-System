
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInst = new System.Windows.Forms.Label();
            this.lblBuilding = new System.Windows.Forms.Label();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lblProgram = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstEnrolled
            // 
            this.lstEnrolled.FormattingEnabled = true;
            this.lstEnrolled.ItemHeight = 15;
            this.lstEnrolled.Location = new System.Drawing.Point(16, 56);
            this.lstEnrolled.Name = "lstEnrolled";
            this.lstEnrolled.Size = new System.Drawing.Size(323, 409);
            this.lstEnrolled.TabIndex = 1;
            this.lstEnrolled.SelectedIndexChanged += new System.EventHandler(this.lstEnrolled_SelectedIndexChanged);
            // 
            // btnDrop
            // 
            this.btnDrop.Location = new System.Drawing.Point(24, 3);
            this.btnDrop.Name = "btnDrop";
            this.btnDrop.Size = new System.Drawing.Size(136, 23);
            this.btnDrop.TabIndex = 2;
            this.btnDrop.Text = "Drop Course";
            this.btnDrop.UseVisualStyleBackColor = true;
            this.btnDrop.Click += new System.EventHandler(this.btnDrop_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(665, 96);
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
            this.lblClassName.Location = new System.Drawing.Point(360, 56);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(441, 32);
            this.lblClassName.TabIndex = 4;
            this.lblClassName.Text = "Dynamic Web Application Development";
            // 
            // lblClassNum
            // 
            this.lblClassNum.AutoSize = true;
            this.lblClassNum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblClassNum.Location = new System.Drawing.Point(364, 95);
            this.lblClassNum.Name = "lblClassNum";
            this.lblClassNum.Size = new System.Drawing.Size(67, 21);
            this.lblClassNum.TabIndex = 5;
            this.lblClassNum.Text = "ITEC999";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(364, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Instructor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(364, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Building:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(364, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Room Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(364, 444);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Program:";
            // 
            // lblInst
            // 
            this.lblInst.AutoSize = true;
            this.lblInst.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInst.Location = new System.Drawing.Point(521, 144);
            this.lblInst.Name = "lblInst";
            this.lblInst.Size = new System.Drawing.Size(80, 21);
            this.lblInst.TabIndex = 10;
            this.lblInst.Text = "Instructor:";
            // 
            // lblBuilding
            // 
            this.lblBuilding.AutoSize = true;
            this.lblBuilding.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBuilding.Location = new System.Drawing.Point(521, 179);
            this.lblBuilding.Name = "lblBuilding";
            this.lblBuilding.Size = new System.Drawing.Size(80, 21);
            this.lblBuilding.TabIndex = 11;
            this.lblBuilding.Text = "Instructor:";
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRoom.Location = new System.Drawing.Point(521, 212);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(80, 21);
            this.lblRoom.TabIndex = 12;
            this.lblRoom.Text = "Instructor:";
            // 
            // lblProgram
            // 
            this.lblProgram.AutoSize = true;
            this.lblProgram.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProgram.Location = new System.Drawing.Point(521, 444);
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Size = new System.Drawing.Size(80, 21);
            this.lblProgram.TabIndex = 13;
            this.lblProgram.Text = "Instructor:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(-8, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(849, 50);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.btnDrop);
            this.panel2.Location = new System.Drawing.Point(-8, 472);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(849, 57);
            this.panel2.TabIndex = 15;
            // 
            // AddDropControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblProgram);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.lblBuilding);
            this.Controls.Add(this.lblInst);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblClassNum);
            this.Controls.Add(this.lblClassName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstEnrolled);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "AddDropControl";
            this.Size = new System.Drawing.Size(841, 529);
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInst;
        private System.Windows.Forms.Label lblBuilding;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblProgram;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
