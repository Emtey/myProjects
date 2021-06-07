
namespace PasswordCreator
{
    partial class frmCreatePassword
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
            this.txtBoxPassowrdLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoBtnYes = new System.Windows.Forms.RadioButton();
            this.rdoBtnNo = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.btnCreatePassword = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxPassowrdLength
            // 
            this.txtBoxPassowrdLength.Location = new System.Drawing.Point(276, 42);
            this.txtBoxPassowrdLength.Name = "txtBoxPassowrdLength";
            this.txtBoxPassowrdLength.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPassowrdLength.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please enter length of password: (between 8 - 25)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Special Characters  Allowed:  (ex: \"!$<>*+_\" )";
            // 
            // rdoBtnYes
            // 
            this.rdoBtnYes.AutoSize = true;
            this.rdoBtnYes.Checked = true;
            this.rdoBtnYes.Location = new System.Drawing.Point(276, 78);
            this.rdoBtnYes.Name = "rdoBtnYes";
            this.rdoBtnYes.Size = new System.Drawing.Size(43, 17);
            this.rdoBtnYes.TabIndex = 3;
            this.rdoBtnYes.TabStop = true;
            this.rdoBtnYes.Text = "Yes";
            this.rdoBtnYes.UseVisualStyleBackColor = true;
            // 
            // rdoBtnNo
            // 
            this.rdoBtnNo.AutoSize = true;
            this.rdoBtnNo.Location = new System.Drawing.Point(325, 78);
            this.rdoBtnNo.Name = "rdoBtnNo";
            this.rdoBtnNo.Size = new System.Drawing.Size(39, 17);
            this.rdoBtnNo.TabIndex = 4;
            this.rdoBtnNo.Text = "No";
            this.rdoBtnNo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Generate Password For: (ex: Netflix, Google)";
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(228, 112);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(148, 20);
            this.txtBoxName.TabIndex = 6;
            // 
            // btnCreatePassword
            // 
            this.btnCreatePassword.Location = new System.Drawing.Point(66, 171);
            this.btnCreatePassword.Name = "btnCreatePassword";
            this.btnCreatePassword.Size = new System.Drawing.Size(107, 23);
            this.btnCreatePassword.TabIndex = 7;
            this.btnCreatePassword.Text = "Create Password";
            this.btnCreatePassword.UseVisualStyleBackColor = true;
            this.btnCreatePassword.Click += new System.EventHandler(this.btnCreatePassword_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(238, 171);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmCreatePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 206);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCreatePassword);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdoBtnNo);
            this.Controls.Add(this.rdoBtnYes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxPassowrdLength);
            this.Name = "frmCreatePassword";
            this.Text = "Create Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxPassowrdLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdoBtnYes;
        private System.Windows.Forms.RadioButton rdoBtnNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Button btnCreatePassword;
        private System.Windows.Forms.Button btnExit;
    }
}