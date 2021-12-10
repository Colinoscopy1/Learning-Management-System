
namespace LMS_Final_Project
{
    partial class StudentHome
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGrades = new System.Windows.Forms.Button();
            this.btnYourClasses = new System.Windows.Forms.Button();
            this.btnClasses = new System.Windows.Forms.Button();
            this.btnRegProg = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstContainer = new System.Windows.Forms.ListBox();
            this.flowMain = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel1.Controls.Add(this.btnGrades);
            this.panel1.Controls.Add(this.btnYourClasses);
            this.panel1.Controls.Add(this.btnClasses);
            this.panel1.Controls.Add(this.btnRegProg);
            this.panel1.Controls.Add(this.btnLogOut);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1185, 50);
            this.panel1.TabIndex = 0;
            // 
            // btnGrades
            // 
            this.btnGrades.Location = new System.Drawing.Point(794, 11);
            this.btnGrades.Name = "btnGrades";
            this.btnGrades.Size = new System.Drawing.Size(148, 23);
            this.btnGrades.TabIndex = 5;
            this.btnGrades.Text = "Your Grades";
            this.btnGrades.UseVisualStyleBackColor = true;
            this.btnGrades.Click += new System.EventHandler(this.btnGrades_Click);
            // 
            // btnYourClasses
            // 
            this.btnYourClasses.Location = new System.Drawing.Point(948, 11);
            this.btnYourClasses.Name = "btnYourClasses";
            this.btnYourClasses.Size = new System.Drawing.Size(148, 23);
            this.btnYourClasses.TabIndex = 4;
            this.btnYourClasses.Text = "Your Classes";
            this.btnYourClasses.UseVisualStyleBackColor = true;
            this.btnYourClasses.Click += new System.EventHandler(this.btnYourClasses_Click);
            // 
            // btnClasses
            // 
            this.btnClasses.Location = new System.Drawing.Point(640, 11);
            this.btnClasses.Name = "btnClasses";
            this.btnClasses.Size = new System.Drawing.Size(148, 23);
            this.btnClasses.TabIndex = 3;
            this.btnClasses.Text = "Add/Drop Classes";
            this.btnClasses.UseVisualStyleBackColor = true;
            this.btnClasses.Click += new System.EventHandler(this.btnClasses_Click);
            // 
            // btnRegProg
            // 
            this.btnRegProg.Location = new System.Drawing.Point(486, 11);
            this.btnRegProg.Name = "btnRegProg";
            this.btnRegProg.Size = new System.Drawing.Size(148, 23);
            this.btnRegProg.TabIndex = 2;
            this.btnRegProg.Text = "Register in a Program";
            this.btnRegProg.UseVisualStyleBackColor = true;
            this.btnRegProg.Click += new System.EventHandler(this.btnRegProg_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(1102, 11);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 1;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.SystemColors.WindowText;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWelcome.ForeColor = System.Drawing.SystemColors.Window;
            this.lblWelcome.Location = new System.Drawing.Point(12, 13);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(220, 21);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome, Your Name Here!";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel2.Controls.Add(this.lstContainer);
            this.panel2.Location = new System.Drawing.Point(0, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(308, 576);
            this.panel2.TabIndex = 5;
            // 
            // lstContainer
            // 
            this.lstContainer.FormattingEnabled = true;
            this.lstContainer.ItemHeight = 15;
            this.lstContainer.Location = new System.Drawing.Point(13, 38);
            this.lstContainer.Name = "lstContainer";
            this.lstContainer.Size = new System.Drawing.Size(268, 529);
            this.lstContainer.TabIndex = 0;
            this.lstContainer.SelectedIndexChanged += new System.EventHandler(this.lstContainer_SelectedIndexChanged);
            // 
            // flowMain
            // 
            this.flowMain.AutoScroll = true;
            this.flowMain.Location = new System.Drawing.Point(330, 86);
            this.flowMain.Name = "flowMain";
            this.flowMain.Size = new System.Drawing.Size(841, 529);
            this.flowMain.TabIndex = 6;
            // 
            // StudentHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 623);
            this.Controls.Add(this.flowMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "StudentHome";
            this.Text = "StudentHome";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnRegProg;
        private System.Windows.Forms.Button btnYourClasses;
        private System.Windows.Forms.Button btnClasses;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowMain;
        private System.Windows.Forms.ListBox lstContainer;
        private System.Windows.Forms.Button btnGrades;
    }
}