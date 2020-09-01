using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DriverGame
{
    public partial class Input : Form
    {
        public Input()
        {
            InitializeComponent();
        }
        private Input(string windowTitle, string MessageTitle)
        {
            InitializeComponent();
            this.Text = windowTitle;
            this.lblMessage.Text = MessageTitle;
        }

        public static string InputBox(string windowTitle, string messageTitle, string defaultText)
        {
            using (Input input = new Input(windowTitle, messageTitle))
            {
                input.txtInput.Text = defaultText;
                try
                {
                    if (input.ShowDialog() == DialogResult.OK)
                    {
                        return input.InputText;
                    }
                    else
                        return string.Empty;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
        public static string InputBox(string windowTitle, string messageTitle)
        {
            return Input.InputBox(windowTitle, messageTitle, string.Empty);
        }
        public string InputText
        {
            get { return this.txtInput.Text; }
        }
    }
}