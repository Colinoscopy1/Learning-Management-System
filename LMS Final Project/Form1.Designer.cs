
namespace LMS_Final_Project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.grpStudents = new System.Windows.Forms.GroupBox();
            this.grpEmployees = new System.Windows.Forms.GroupBox();
            this.btnEmployeeLogin = new System.Windows.Forms.Button();
            this.grpStudents.SuspendLayout();
            this.grpEmployees.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.Location = new System.Drawing.Point(6, 28);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(188, 45);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRegister.Location = new System.Drawing.Point(6, 88);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(188, 45);
            this.btnRegister.TabIndex = 1;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // grpStudents
            // 
            this.grpStudents.Controls.Add(this.btnLogin);
            this.grpStudents.Controls.Add(this.btnRegister);
            this.grpStudents.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpStudents.Location = new System.Drawing.Point(240, 12);
            this.grpStudents.Name = "grpStudents";
            this.grpStudents.Size = new System.Drawing.Size(200, 144);
            this.grpStudents.TabIndex = 3;
            this.grpStudents.TabStop = false;
            this.grpStudents.Text = "Students";
            // 
            // grpEmployees
            // 
            this.grpEmployees.Controls.Add(this.btnEmployeeLogin);
            this.grpEmployees.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpEmployees.Location = new System.Drawing.Point(12, 12);
            this.grpEmployees.Name = "grpEmployees";
            this.grpEmployees.Size = new System.Drawing.Size(200, 144);
            this.grpEmployees.TabIndex = 4;
            this.grpEmployees.TabStop = false;
            this.grpEmployees.Text = "Employees";
            // 
            // btnEmployeeLogin
            // 
            this.btnEmployeeLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEmployeeLogin.Location = new System.Drawing.Point(6, 28);
            this.btnEmployeeLogin.Name = "btnEmployeeLogin";
            this.btnEmployeeLogin.Size = new System.Drawing.Size(188, 45);
            this.btnEmployeeLogin.TabIndex = 2;
            this.btnEmployeeLogin.Text = "Login";
            this.btnEmployeeLogin.UseVisualStyleBackColor = true;
            this.btnEmployeeLogin.Click += new System.EventHandler(this.btnEmployeeLogin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 166);
            this.Controls.Add(this.grpEmployees);
            this.Controls.Add(this.grpStudents);
            this.Name = "Form1";
            this.Text = "Welcome";
            this.grpStudents.ResumeLayout(false);
            this.grpEmployees.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.GroupBox grpStudents;
        private System.Windows.Forms.GroupBox grpEmployees;
        private System.Windows.Forms.Button btnEmployeeLogin;
    }
}

