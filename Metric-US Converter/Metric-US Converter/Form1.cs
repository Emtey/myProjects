using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metric_US_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //build the comboBox
            string[] conversions = {
                "Farenheit to Celcius",
                "Celcius to Farenheit",
                "Inches to Centimeters",
                "Centimeters to Inches",
                "Feet to Meters",
                "Meters to Feet"
            };

            foreach (string conversion in conversions)
            {
                cmboConversion.Items.Add(conversion);
            }
        }

        /// <summary>
        /// On the button click of Convert.  Get the value in the TxtBoxInput field and
        /// the value in the cmbConversion drop down box and Convert them to the appropriate 
        /// values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            double inputValue = 0;
            int conversionIndex;
            
            if (TxtBoxInput.Text == "")
            {
                MessageBox.Show("Value to Convert is a required field.");
                TxtBoxInput.Focus();
                return;
            }

            //check to see if input is numeric, if not throw exception
            try
            {
                inputValue = double.Parse(TxtBoxInput.Text);
            }
            catch(FormatException)
            {
                MessageBox.Show("Value to Convert must be numeric.");
                TxtBoxInput.Focus();
                return;
       
            }

            //Check to see if the user selected a Conversion type, if not throw exception
            if (cmboConversion.SelectedIndex > -1)
                    conversionIndex = cmboConversion.SelectedIndex;
            else
            { 
                MessageBox.Show("Must select a conversion type");
                cmboConversion.Focus();
                return;
            }

            //Instantiate Converter Class and call the do_conversion method to 
            //perform the conversion.
            Converter myConverter = new Converter(inputValue, conversionIndex);
            TxtBoxResult.Text = myConverter.do_conversion();
            TxtBoxInput.Focus();
        }
    }
}
