
namespace LMS_Final_Project
{
    partial class InstructorHome
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
            this.btnHandin = new System.Windows.Forms.Button();
            this.btnPosts = new System.Windows.Forms.Button();
            this.btnClassRoster = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstContainer = new System.Windows.Forms.ListBox();
            this.flowMain = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddPost = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel1.Controls.Add(this.btnHandin);
            this.panel1.Controls.Add(this.btnPosts);
            this.panel1.Controls.Add(this.btnClassRoster);
            this.panel1.Controls.Add(this.btnLogOut);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 42);
            this.panel1.TabIndex = 0;
            // 
            // btnHandin
            // 
            this.btnHandin.Location = new System.Drawing.Point(788, 14);
            this.btnHandin.Name = "btnHandin";
            this.btnHandin.Size = new System.Drawing.Size(148, 23);
            this.btnHandin.TabIndex = 11;
            this.btnHandin.Text = "View/Grade Handins";
            this.btnHandin.UseVisualStyleBackColor = true;
            this.btnHandin.Click += new System.EventHandler(this.btnHandin_Click);
            // 
            // btnPosts
            // 
            this.btnPosts.Location = new System.Drawing.Point(596, 14);
            this.btnPosts.Name = "btnPosts";
            this.btnPosts.Size = new System.Drawing.Size(186, 23);
            this.btnPosts.TabIndex = 10;
            this.btnPosts.Text = "Manage Posts/Assignments";
            this.btnPosts.UseVisualStyleBackColor = true;
            this.btnPosts.Click += new System.EventHandler(this.btnPosts_Click);
            // 
            // btnClassRoster
            // 
            this.btnClassRoster.Location = new System.Drawing.Point(942, 14);
            this.btnClassRoster.Name = "btnClassRoster";
            this.btnClassRoster.Size = new System.Drawing.Size(148, 23);
            this.btnClassRoster.TabIndex = 9;
            this.btnClassRoster.Text = "Your Class Rosters";
            this.btnClassRoster.UseVisualStyleBackColor = true;
            this.btnClassRoster.Click += new System.EventHandler(this.btnClassRoster_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(1096, 14);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 9;
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
            this.panel2.TabIndex = 1;
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
            this.flowMain.Location = new System.Drawing.Point(314, 75);
            this.flowMain.Name = "flowMain";
            this.flowMain.Size = new System.Drawing.Size(857, 540);
            this.flowMain.TabIndex = 8;
            // 
            // btnAddPost
            // 
            this.btnAddPost.Location = new System.Drawing.Point(314, 48);
            this.btnAddPost.Name = "btnAddPost";
            this.btnAddPost.Size = new System.Drawing.Size(75, 23);
            this.btnAddPost.TabIndex = 9;
            this.btnAddPost.Text = "Add Post";
            this.btnAddPost.UseVisualStyleBackColor = true;
            this.btnAddPost.Visible = false;
            this.btnAddPost.Click += new System.EventHandler(this.btnAddPost_Click);
            // 
            // InstructorHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 623);
            this.Controls.Add(this.btnAddPost);
            this.Controls.Add(this.flowMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "InstructorHome";
            this.Text = "Instructor Home";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lstContainer;
        private System.Windows.Forms.FlowLayoutPanel flowMain;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnHandin;
        private System.Windows.Forms.Button btnPosts;
        private System.Windows.Forms.Button btnClassRoster;
        private System.Windows.Forms.Button btnAddPost;
    }
}