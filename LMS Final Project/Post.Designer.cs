
namespace LMS_Final_Project
{
    partial class Post
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
            this.lblClass = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblBody = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHandin = new System.Windows.Forms.Button();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lblClass);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(822, 52);
            this.panel1.TabIndex = 0;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.ForeColor = System.Drawing.Color.White;
            this.lblClass.Location = new System.Drawing.Point(740, 4);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(34, 15);
            this.lblClass.TabIndex = 1;
            this.lblClass.Text = "Class";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(4, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(71, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            // 
            // lblBody
            // 
            this.lblBody.BackColor = System.Drawing.Color.White;
            this.lblBody.Location = new System.Drawing.Point(0, 55);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(818, 429);
            this.lblBody.TabIndex = 1;
            this.lblBody.Text = "Body";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.btnHandin);
            this.panel2.Controls.Add(this.lblDueDate);
            this.panel2.Location = new System.Drawing.Point(0, 487);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(822, 42);
            this.panel2.TabIndex = 2;
            // 
            // btnHandin
            // 
            this.btnHandin.Location = new System.Drawing.Point(671, 9);
            this.btnHandin.Name = "btnHandin";
            this.btnHandin.Size = new System.Drawing.Size(135, 23);
            this.btnHandin.TabIndex = 1;
            this.btnHandin.Text = "Upload Assignment";
            this.btnHandin.UseVisualStyleBackColor = true;
            this.btnHandin.Click += new System.EventHandler(this.btnHandin_Click);
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.ForeColor = System.Drawing.Color.White;
            this.lblDueDate.Location = new System.Drawing.Point(4, 13);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(55, 15);
            this.lblDueDate.TabIndex = 0;
            this.lblDueDate.Text = "Due Date";
            this.lblDueDate.Visible = false;
            this.lblDueDate.Click += new System.EventHandler(this.lblDueDate_Click);
            // 
            // Post
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblBody);
            this.Controls.Add(this.panel1);
            this.Name = "Post";
            this.Size = new System.Drawing.Size(821, 529);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Button btnHandin;
    }
}
