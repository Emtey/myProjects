using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metric_US_Converter
{
    class Temperature
    {
        private double inputValue;
        private int index;

        //constructor
        public Temperature(double inputValue, int index)
        {
            this.InputValue = inputValue;
            this.Index = index;
        }

        #region Get/Set
        public double InputValue
        {
            get { return inputValue; }
            set { inputValue = value; }
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        #endregion

        public string ConvertTemperature()
        {
            string output = "";
            switch (index)
            {
                case 0:
                    output = FarenheitToCelcius(inputValue);
                    break;
                case 1:
                    output = CelciusToFarenheit(inputValue);
                    break;
            }
            return output;
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

    }
}
