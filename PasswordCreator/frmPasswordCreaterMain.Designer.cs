
namespace PasswordCreator
{
    partial class frmPasswordCreaterMain
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
            this.btnCreatePassword = new System.Windows.Forms.Button();
            this.btnDisplayPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreatePassword
            // 
            this.btnCreatePassword.Location = new System.Drawing.Point(63, 53);
            this.btnCreatePassword.Name = "btnCreatePassword";
            this.btnCreatePassword.Size = new System.Drawing.Size(104, 34);
            this.btnCreatePassword.TabIndex = 0;
            this.btnCreatePassword.Text = "Create Password";
            this.btnCreatePassword.UseVisualStyleBackColor = true;
            this.btnCreatePassword.Click += new System.EventHandler(this.btnCreatePassword_Click);
            // 
            // btnDisplayPassword
            // 
            this.btnDisplayPassword.Location = new System.Drawing.Point(63, 112);
            this.btnDisplayPassword.Name = "btnDisplayPassword";
            this.btnDisplayPassword.Size = new System.Drawing.Size(104, 34);
            this.btnDisplayPassword.TabIndex = 1;
            this.btnDisplayPassword.Text = "Display Password";
            this.btnDisplayPassword.UseVisualStyleBackColor = true;
            this.btnDisplayPassword.Click += new System.EventHandler(this.btnDisplayPassword_Click);
            // 
            // frmPasswordCreaterMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(231, 182);
            this.Controls.Add(this.btnDisplayPassword);
            this.Controls.Add(this.btnCreatePassword);
            this.Name = "frmPasswordCreaterMain";
            this.Text = "Password Creator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreatePassword;
        private System.Windows.Forms.Button btnDisplayPassword;
    }
}

