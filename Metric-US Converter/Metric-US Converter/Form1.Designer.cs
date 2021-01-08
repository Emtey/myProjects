namespace Metric_US_Converter
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.TxtBoxInput = new System.Windows.Forms.TextBox();
            this.TxtBoxResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblConversion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmboConvertFrom = new System.Windows.Forms.ComboBox();
            this.conversionTypeCmbBox = new System.Windows.Forms.ComboBox();
            this.cmboConvertTo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "Convert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtBoxInput
            // 
            this.TxtBoxInput.Location = new System.Drawing.Point(138, 73);
            this.TxtBoxInput.Name = "TxtBoxInput";
            this.TxtBoxInput.Size = new System.Drawing.Size(159, 20);
            this.TxtBoxInput.TabIndex = 2;
            // 
            // TxtBoxResult
            // 
            this.TxtBoxResult.Enabled = false;
            this.TxtBoxResult.Location = new System.Drawing.Point(352, 73);
            this.TxtBoxResult.Name = "TxtBoxResult";
            this.TxtBoxResult.ReadOnly = true;
            this.TxtBoxResult.Size = new System.Drawing.Size(158, 20);
            this.TxtBoxResult.TabIndex = 2;
            this.TxtBoxResult.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter Value to Convert: ";
            // 
            // LblConversion
            // 
            this.LblConversion.AutoSize = true;
            this.LblConversion.Location = new System.Drawing.Point(324, 192);
            this.LblConversion.Name = "LblConversion";
            this.LblConversion.Size = new System.Drawing.Size(0, 13);
            this.LblConversion.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "TO";
            // 
            // cmboConvertFrom
            // 
            this.cmboConvertFrom.FormattingEnabled = true;
            this.cmboConvertFrom.IntegralHeight = false;
            this.cmboConvertFrom.Location = new System.Drawing.Point(138, 93);
            this.cmboConvertFrom.Name = "cmboConvertFrom";
            this.cmboConvertFrom.Size = new System.Drawing.Size(159, 21);
            this.cmboConvertFrom.TabIndex = 3;
            // 
            // conversionTypeCmbBox
            // 
            this.conversionTypeCmbBox.FormattingEnabled = true;
            this.conversionTypeCmbBox.Location = new System.Drawing.Point(12, 21);
            this.conversionTypeCmbBox.Name = "conversionTypeCmbBox";
            this.conversionTypeCmbBox.Size = new System.Drawing.Size(285, 21);
            this.conversionTypeCmbBox.TabIndex = 1;
            this.conversionTypeCmbBox.Text = "Select Conversion Type...";
            this.conversionTypeCmbBox.SelectedIndexChanged += new System.EventHandler(this.conversionTypeCmbBox_SelectedIndexChanged);
            // 
            // cmboConvertTo
            // 
            this.cmboConvertTo.FormattingEnabled = true;
            this.cmboConvertTo.IntegralHeight = false;
            this.cmboConvertTo.Location = new System.Drawing.Point(351, 93);
            this.cmboConvertTo.Name = "cmboConvertTo";
            this.cmboConvertTo.Size = new System.Drawing.Size(159, 21);
            this.cmboConvertTo.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 248);
            this.Controls.Add(this.cmboConvertTo);
            this.Controls.Add(this.conversionTypeCmbBox);
            this.Controls.Add(this.cmboConvertFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblConversion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtBoxResult);
            this.Controls.Add(this.TxtBoxInput);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Metric Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtBoxInput;
        private System.Windows.Forms.TextBox TxtBoxResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblConversion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmboConvertFrom;
        private System.Windows.Forms.ComboBox conversionTypeCmbBox;
        private System.Windows.Forms.ComboBox cmboConvertTo;
    }
}

