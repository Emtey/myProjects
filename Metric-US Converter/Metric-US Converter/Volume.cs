using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metric_US_Converter
{
    class Volume
    {
        private double inputValue;
        private int fromIndex;
        private int toIndex;

        public Volume(double inputValue, int fromIndex, int toIndex)
        {
            this.InputValue = inputValue;
            this.FromIndex = fromIndex;
            this.ToIndex = toIndex;
        }

        #region Get/Seet
        public double InputValue
        {
            get { return inputValue; }
            set { inputValue = value; }
        }

        public int FromIndex
        {
            get { return fromIndex; }
            set { fromIndex = value; }
        }

        public int ToIndex
        {
            get { return toIndex; }
            set { toIndex = value; }
        }

        #endregion

        /* Zero based index
        US Cups         = 0
        US Quart        = 1
        US Pint         = 2
        US Gallon       = 3
        US Ounce        = 4
        US Tablespoon   = 5
        US Teaspoon     = 6
        Liter           = 7
        Milliliter      = 8
        */

        public string ConvertVolume()
        {
            string output = "";
            if (toIndex == fromIndex)
                output = String.Format("{0}", InputValue.ToString("0.#"));
            else
            { 
                switch (fromIndex)
                {
                    case 0: //US Cups
                        if (toIndex == 1) //US Quart
                            output = Divisor(InputValue, 3.943);

                        break;


                }

            }
            return output;           
        }

        private string Multiplier(double inputValue, double value)
        {
            double myValue = (inputValue * value);
            return myValue.ToString("G4");
        }

        private string Divisor(double inputValue, double value)
        {
            double myValue = (inputValue / value);
            return myValue.ToString("G4");
        }

    }
}
