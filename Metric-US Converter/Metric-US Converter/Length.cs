using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metric_US_Converter
{
    class Length
    {
        private double inputValue;
        private int index;

        public Length(double inputValue, int index)
        {
            this.InputValue = inputValue;
            this.index = index;
        }

        #region GET/SET
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

        public string ConvertLength()
        {
            string output = "";
            switch (index)
            {
                case 0: 
                    output = InchesToCentimeters(inputValue);
                    break;
                case 1:
                    output = CentimetersToInches(inputValue);
                    break;
                case 2:
                    output = FeetToMeters(inputValue);
                    break;
                case 3:
                    output = MetersToFeet(inputValue);
                    break;
            }
            return output;
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
