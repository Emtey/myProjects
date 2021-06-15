
namespace PasswordCreator
{
    partial class frmDisplayPassword
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
            this.LstViewPassword = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // LstViewPassword
            // 
            this.LstViewPassword.GridLines = true;
            this.LstViewPassword.HideSelection = false;
            this.LstViewPassword.Location = new System.Drawing.Point(0, 0);
            this.LstViewPassword.Name = "LstViewPassword";
            this.LstViewPassword.Size = new System.Drawing.Size(340, 179);
            this.LstViewPassword.TabIndex = 0;
            this.LstViewPassword.UseCompatibleStateImageBehavior = false;
            // 
            // frmDisplayPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 180);
            this.Controls.Add(this.LstViewPassword);
            this.Name = "frmDisplayPassword";
            this.Text = "frmDisplayPassword";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LstViewPassword;
    }
}