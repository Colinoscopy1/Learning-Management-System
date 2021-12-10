
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
            this.SuspendLayout();
            // 
            // lstPosts
            // 
            this.lstPosts.FormattingEnabled = true;
            this.lstPosts.ItemHeight = 15;
            this.lstPosts.Location = new System.Drawing.Point(13, 60);
            this.lstPosts.Name = "lstPosts";
            this.lstPosts.Size = new System.Drawing.Size(244, 454);
            this.lstPosts.TabIndex = 0;
            // 
            // StudentGradesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstPosts);
            this.Name = "StudentGradesControl";
            this.Size = new System.Drawing.Size(841, 529);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstPosts;
    }
}
