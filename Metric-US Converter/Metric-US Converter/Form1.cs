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

            //build the comboBox
            /*string[] conversions = {
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
            }*/
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

            //Check to see if the user selected a Conversion type, if not throw exception
            if (conversionTypeCmbBox.SelectedIndex > -1)
                    conversionType = conversionTypeCmbBox.SelectedIndex;
            else
            { 
                MessageBox.Show("Please select a conversion type");
                conversionTypeCmbBox.Focus();
                return;
            }
            //get the Selected Index from the Conversion Combo Box.
            conversionIndex = cmboConversion.SelectedIndex;

            //Instantiate Converter Class and call the do_conversion method to 
            //perform the conversion.
            Converter myConverter = new Converter(inputValue, conversionIndex, conversionType);
            TxtBoxResult.Text = myConverter.Do_Conversion();
            TxtBoxInput.Focus();
        }

        private void conversionTypeCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (conversionTypeCmbBox.SelectedIndex > -1)
            {
                cmboConversion.Items.Clear();
                
                switch (conversionTypeCmbBox.SelectedIndex)
                {
                    case 0: //temperature
                        cmboConversion.Items.Add("Farenheit to Celcius");
                        cmboConversion.Items.Add("Celcius to Farenheit");
                        cmboConversion.Items.Add("Farenheit to Kelvin");
                        cmboConversion.Items.Add("Kelvin to Farenheit");
                        cmboConversion.Items.Add("Celcius to Kelvin");
                        cmboConversion.Items.Add("Kelvin to Celcius");
                        break;
                    case 1: //Length
                        cmboConversion.Items.Add("Inches to Centimeters");
                        cmboConversion.Items.Add("Centimeters to Inches");
                        cmboConversion.Items.Add("Feet to Meters");
                        cmboConversion.Items.Add("Meters to Feet");
                        break;
                    case 2: //Volume
                        cmboConversion.Items.Add("US Cups to US Gallon");
                        cmboConversion.Items.Add("US Gallons to Cups");
                        cmboConversion.Items.Add("US Cup to US Quart");
                        cmboConversion.Items.Add("US Quart to US Cup");
                        cmboConversion.Items.Add("US Cup to US Pint");
                        cmboConversion.Items.Add("US Pint to US Cup");
                        break;

                }
               
                //now set the first item in the cmboConversion box to the 0 value (first value)
                cmboConversion.SelectedIndex = 0;

            }

        }
    }
}
