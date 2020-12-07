using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metric_US_Converter
{
    class Temperature
    {
        private double InputValue;
        private int FromIndex;
        private int ToIndex;

        //constructor
        public Temperature(double inputValue, int fromIndex, int toIndex)
        {
            this.InputValue = inputValue;
            this.FromIndex = fromIndex;
            this.ToIndex = toIndex;
        }

        public string ConvertTemperature()
        {
            string output = "";
            switch (FromIndex)
            {
                case 0:
                    if (ToIndex == FromIndex)
                        output = String.Format("{0} 'F", InputValue.ToString("0.#"));
                    if (ToIndex == 1) //celcius
                        output = FarenheitToCelcius(InputValue);
                    if (ToIndex == 2) //kelvin
                        output = FarenheitToKelvin(InputValue);
                    break;
                case 1:
                    if (ToIndex == FromIndex)
                        output = String.Format("{0}'C", InputValue.ToString("0.#"));
                    if (ToIndex == 0) //farenheit
                        output = CelciusToFarenheit(InputValue);
                    if (ToIndex == 2) //kelvin
                        output = CelciusToKelvin(InputValue);
                    break;
                case 2:
                    if (ToIndex == FromIndex)
                        output = String.Format("{0}'K", InputValue.ToString("0.##"));
                    if (ToIndex == 0) //farenheit
                        output = KelvinToFarenheit(InputValue);
                    if (ToIndex == 1) //Celcius
                        output = KelvinToCelcius(InputValue);
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
            return String.Format("{0}'F", myValue.ToString("0.#"));
        }

        private string FarenheitToKelvin(double inputValue)
        {
            double myValue = (inputValue - 32) * 5 / 9 + 273.15;
            return String.Format("{0}'K", myValue.ToString("0.###"));
        }

        private string KelvinToFarenheit(double inputValue)
        {
            double myValue = (inputValue - 273.15) * 9/5 + 32;
            return String.Format("{0}'F", myValue.ToString("0.###"));
        }

        private string CelciusToKelvin(double inputValue)
        {
            double myValue = (inputValue + 273.15);
            return String.Format("{0}'K", myValue.ToString("0.##"));
        }

        private string KelvinToCelcius(double inputValue)
        {
            double myValue = (inputValue - 273.15);
            return String.Format("{0}'C", myValue.ToString("0.##"));
        }


    }
}
