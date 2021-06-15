using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;  //so we can use secure random number

namespace PasswordCreator
{
    public partial class frmCreatePassword : Form
    {

        PasswordInformation pi = PasswordInformation.Instance();
        public frmCreatePassword()
        {
            InitializeComponent();

            //load the Password Information file and store it in a dictionary
            pi.Load();
        }

        /// <summary>
        /// Close the Form and return to previous screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
       


        /// <summary>
        /// Create the password and save it to the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreatePassword_Click(object sender, EventArgs e)
        {
            int length;
            string name;
            string newPassword = "";
            bool specialChars = true;
            string[] passwordChars = new[]
            {
                "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz",
                "0123456789",
                "!$<>*+_"
            };  

            //make sure we have a numeric value
            try
            {
                length = int.Parse(txtBoxPassowrdLength.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Value to Convert must be numeric.");
                txtBoxPassowrdLength.Focus();
                return;
            }

            //Really??  A password longer than 25 chars?
            if (length > 25)
            {
                MessageBox.Show("Value cannot be larger than 25 digits");
                txtBoxPassowrdLength.Focus();
                return;
            }
            if (length < 8) //at minimum passwords should be at least 8 digits long
            {
                MessageBox.Show("Value should be at least 8 digits.");
                txtBoxPassowrdLength.Focus();
                return;
            }

            if (txtBoxName.Text != "")
                name = txtBoxName.Text.ToUpper();
            else
            {
                MessageBox.Show("Please enter a name for this password.");
                txtBoxName.Focus();
                return;
            }
            

            //we dont need to see if rdoBtnYes is checked since we default it to true already.
            if (rdoBtnNo.Checked)
                specialChars = false;


            int oldPasswordCharsLineNumber = -1;
            Random myRandom = new Random();            

            for (int x = 0; x < length; x++) //build the password
            {
                int passwordCharsLineNumber;               
                int passwordPosition = 0;

                //first thing to do is figure out what string of chars we are going to use from passwordChars  
                if (specialChars)
                    passwordCharsLineNumber = myRandom.Next(passwordChars.Count());
                else
                    passwordCharsLineNumber = myRandom.Next(passwordChars.Count() - 1);

                oldPasswordCharsLineNumber = passwordCharsLineNumber;

                //now we know what line number we have use it to seed the 
                //Random number generator to get a secure random number
                passwordPosition = GetSecureRandomNumber(0, passwordChars[passwordCharsLineNumber].Length - 1);

                char[] text = passwordChars[passwordCharsLineNumber].ToCharArray();
                newPassword += text[passwordPosition];             
            }
            //save the password to file
            pi.AddPassword(name, newPassword);
            

        }
        /// <summary>
        /// Gets a secured random number, using the Crypto Service Provider
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>Secured Random Number</returns>
        private int GetSecureRandomNumber(int min, int max)
        {
            var rand = new byte[4];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(rand);
            var i = Math.Abs(BitConverter.ToInt32(rand, 0));
            return Convert.ToInt32(i % (max - min + 1) + min);
        }
    }
}
