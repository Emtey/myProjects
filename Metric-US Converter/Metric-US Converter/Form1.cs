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

            string[] conversionType =
            {
                "Temperature",
                "Length",
                "Volume"
            };

            foreach (string type in conversionType)
            {
                conversionTypeCmbBox.Items.Add(type);
            }

            //set the combobox to the first item 
            conversionTypeCmbBox.SelectedIndex = 0;

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
            double inputValue;
            int convertFromIndex;
            int convertToIndex;
            int conversionType;
            
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

            convertFromIndex = cmboConvertFrom.SelectedIndex;
            convertToIndex = cmboConvertTo.SelectedIndex;
            conversionType = conversionTypeCmbBox.SelectedIndex;
            //Instantiate Converter Class and call the do_conversion method to 
            //perform the conversion.
            Converter myConverter = new Converter(inputValue, convertFromIndex, convertToIndex, conversionType);
            TxtBoxResult.Text = myConverter.Do_Conversion();
            TxtBoxInput.Focus();
        }

        private void conversionTypeCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (conversionTypeCmbBox.SelectedIndex > -1)
            {
                cmboConvertFrom.Items.Clear();
                
                switch (conversionTypeCmbBox.SelectedIndex)
                {
                    case 0: //temperature
                        cmboConvertFrom.Items.Add("Farenheit");
                        cmboConvertFrom.Items.Add("Celcius");
                        cmboConvertFrom.Items.Add("Kelvin");

                        cmboConvertTo.Items.Add("Farenheit");
                        cmboConvertTo.Items.Add("Celcius");
                        cmboConvertTo.Items.Add("Kelvin");
                        break;
                    case 1: //Length
                        cmboConvertFrom.Items.Add("Inches");
                        cmboConvertFrom.Items.Add("Feet");
                        cmboConvertFrom.Items.Add("Yards");
                        cmboConvertFrom.Items.Add("Miles");
                        cmboConvertFrom.Items.Add("Millimeters");
                        cmboConvertFrom.Items.Add("Centimeters");
                        cmboConvertFrom.Items.Add("Meters");
                        cmboConvertFrom.Items.Add("Kilometers");

                        cmboConvertTo.Items.Add("Inches");
                        cmboConvertTo.Items.Add("Feet");
                        cmboConvertTo.Items.Add("Yards");
                        cmboConvertTo.Items.Add("Miles");
                        cmboConvertTo.Items.Add("Millimeters");
                        cmboConvertTo.Items.Add("Centimeters");
                        cmboConvertTo.Items.Add("Meters");
                        cmboConvertTo.Items.Add("Kilometers");
                        break;
                    case 2: //Volume
                        cmboConvertFrom.Items.Add("US Cups to US Gallon");
                        cmboConvertFrom.Items.Add("US Gallons to Cups");
                        cmboConvertFrom.Items.Add("US Cup to US Quart");
                        cmboConvertFrom.Items.Add("US Quart to US Cup");
                        cmboConvertFrom.Items.Add("US Cup to US Pint");
                        cmboConvertFrom.Items.Add("US Pint to US Cup");
                        break;

                }
               
                //now set the first item in the cmboConversion box to the 0 value (first value)
                cmboConvertFrom.SelectedIndex = 0;
                cmboConvertTo.SelectedIndex = 1; 

            }

        }
    }
}
