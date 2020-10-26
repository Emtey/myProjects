using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metric_US_Converter
{
    public class Converter
    {
        private double inputValue;
        private int index;
        
        //Constructor
        public Converter(double inputValue, int index)
        {
            this.InputValue = inputValue;
            this.Index = index;
        }

        #region Getters/Setters
        public double InputValue
        {
            get { return inputValue; }
            set { inputValue = value; }
        }

        public int Index
        {
            get { return index; }
            set { index = value;  }
        }
        #endregion

        /// <summary>
        /// Gets the index from the drop down box and uses it to call the 
        /// appropriate function.
        /// </summary>
        /// <returns></returns>
        public string do_conversion()
        {
            string conversionOutput = "";

            switch (index)
            {
                case 0:
                    conversionOutput = FarenheitToCelcius(inputValue);
                    break;
                case 1:
                    conversionOutput = CelciusToFarenheit(inputValue);
                    break;
                case 2:
                    conversionOutput = InchesToCentimeters(inputValue);
                    break;
                case 3:
                    conversionOutput = CentimetersToInches(inputValue);
                    break;
                case 4:
                    conversionOutput = FeetToMeters(inputValue);
                    break;
                case 5:
                    conversionOutput = MetersToFeet(inputValue);
                    break;
            }

            return conversionOutput;
        }

        /// <summary>
        /// Convert Farenheit to Celcius
        /// </summary>
        /// <param name="inputValue">inputted value</param>
        /// <returns></returns>
        private string FarenheitToCelcius(double inputValue)
        {
            double myValue = (inputValue - 32) * 5 / 9;
            return String.Format("{0}'C", myValue.ToString("0.#"));
        }

        private string CelciusToFarenheit(double inputValue)
        {
            double myValue = (inputValue * 9 / 5) + 32;
            return String.Format("{0}'C", myValue.ToString("0.#"));
        }

        private string InchesToCentimeters(double inputValue)
        {
            double myValue = (inputValue * 2.54);
            return String.Format("{0} cm", myValue.ToString("0.##"));
        }

        private string CentimetersToInches(double inputValue)
        {
            double myValue = (inputValue / 2.54);
            return String.Format("{0} in", myValue.ToString("0.##"));
        }

        private string FeetToMeters(double inputValue)
        {
            double myValue = (inputValue * .3048);
            return String.Format("{0} m", myValue.ToString("0.##"));
        }

        private string MetersToFeet(double inputValue)
        {
            double myValue = (inputValue / .3048);
            return String.Format("{0} ft", myValue.ToString("0.##"));
        }
    }
}
