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
                    conversionOutput = CentimetersToInches(InputValue);
                    break;
            }

            return conversionOutput;
        }

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

        private string CentimetersToInches(double InputValue)
        {
            double myValue = (inputValue / 2.54);
            return String.Format("{0} in", myValue.ToString("0.##"));
        }
    }
}
