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

        #region Get/Set
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
                            output = Divisor(InputValue, 4);
                        if (toIndex == 2) //US Pint
                            output = Divisor(InputValue, 2);
                        if (toIndex == 3) //US Gallon
                            output = Divisor(InputValue, 16);
                        if (toIndex == 4) //US Ounce
                            output = Multiplier(InputValue, 8);
                        if (toIndex == 5) //US Tablespoon
                            output = Multiplier(InputValue, 16);
                        if (toIndex == 6) //US Teaspoon
                            output = Multiplier(InputValue, 48);
                        if (toIndex == 7) //Liter
                            output = Divisor(InputValue, 4227);
                        if (toIndex == 8) //Milliliter
                            output = Multiplier(InputValue, 237);
                        break;
                    case 1: //US Quart
                        if (toIndex == 0) //US Cups
                            output = Multiplier(InputValue, 4);
                        if (toIndex == 2) //US Pint
                            output = Multiplier(InputValue, 2);
                        if (toIndex == 3) //US Gallon
                            output = Divisor(InputValue, 4);
                        if (toIndex == 4) //US Ounce
                            output = Multiplier(InputValue, 32);
                        if (toIndex == 5) //US Tablespoon
                            output = Multiplier(InputValue, 64);
                        if (toIndex == 6) //US Teaspoon
                            output = Multiplier(InputValue, 192);
                        if (toIndex == 7) //Liter
                            output = Divisor(InputValue, 1.057);
                        if (toIndex == 8) //Milliliter
                            output = Multiplier(InputValue, 946);
                        break;
                    case 2: //US Pint
                        if (toIndex == 0) //US Cups
                            output = Multiplier(InputValue, 2); 
                        if (toIndex == 1) //US Quart
                            output = Divisor(InputValue, 2);
                        if (toIndex == 3) //US Gallon
                            output = Divisor(InputValue, 8);
                        if (toIndex == 4) //US Ounce
                            output = Multiplier(InputValue, 16);
                        if (toIndex == 5) //US Tablespoon
                            output = Multiplier(InputValue, 32);
                        if (toIndex == 6) //US Teaspoon
                            output = Multiplier(InputValue, 96);
                        if (toIndex == 7) //Liter
                            output = Divisor(InputValue, 2.113);
                        if (toIndex == 8) //Milliliter
                            output = Multiplier(InputValue, 473);
                        break;
                    case 3: //US Gallon
                        if (toIndex == 0) //US Cups
                            output = Multiplier(InputValue, 16);
                        if (toIndex == 1) //US Quart
                            output = Multiplier(InputValue, 4);
                        if (toIndex == 2) //US Pint
                            output = Multiplier(InputValue, 8);
                        if (toIndex == 4) //US Ounce
                            output = Multiplier(InputValue, 128);
                        if (toIndex == 5) //US Tablespoon
                            output = Multiplier(InputValue, 256);
                        if (toIndex == 6) //US Teaspoon
                            output = Multiplier(InputValue, 768);
                        if (toIndex == 7) //Liter
                            output = Multiplier(InputValue, 3.785);
                        if (toIndex == 8) //Milliliter
                            output = Multiplier(InputValue, 3785);
                        break;
                    case 4: //US Ounce  
                        if (toIndex == 0) //US Cups
                            output = Divisor(InputValue, 8);
                        if (toIndex == 1) //US Quart
                            output = Divisor(InputValue, 32);
                        if (toIndex == 2) //US Pint
                            output = Divisor(InputValue, 16);
                        if (toIndex == 3) //US Gallon
                            output = Divisor(InputValue, 128);
                        if (toIndex == 5) //US Tablespoon
                            output = Multiplier(InputValue, 2);
                        if (toIndex == 6) //US Teaspoon
                            output = Multiplier(InputValue, 6);
                        if (toIndex == 7) //Liter
                            output = Divisor(InputValue, 33.814);
                        if (toIndex == 8) //Milliliter
                            output = Multiplier(InputValue, 29.574);
                        break;
                    case 5: //US Tablespoon
                        if (toIndex == 0) //US Cups
                            output = Divisor(InputValue, 16);
                        if (toIndex == 1) //US Quart
                            output = Divisor(InputValue, 64);
                        if (toIndex == 2) //US Pint
                            output = Divisor(InputValue, 32);
                        if (toIndex == 3) //US Gallon
                            output = Divisor(InputValue, 256);
                        if (toIndex == 4) //US Ounce
                            output = Divisor(InputValue, 2);
                        if (toIndex == 6) //US Teaspoon
                            output = Multiplier(InputValue, 3);
                        if (toIndex == 7) //Liter
                            output = Divisor(InputValue, 67.628);
                        if (toIndex == 8) //Milliliter
                            output = Multiplier(InputValue, 14.787);
                        break;
                    case 6: //US Teaspoon
                        if (toIndex == 0) //US Cups 
                            output = Divisor(InputValue, 48);
                        if (toIndex == 1) //US Quart
                            output = Divisor(InputValue, 192);
                        if (toIndex == 2) //US Pint
                            output = Divisor(InputValue, 96);
                        if (toIndex == 3) //US Gallon
                            output = Divisor(InputValue, 16);
                        if (toIndex == 4) //US Ounce
                            output = Divisor(InputValue, 6);
                        if (toIndex == 5) //US Tablespoon
                            output = Divisor(InputValue, 3); 
                        if (toIndex == 7) //Liter
                            output = Divisor(InputValue, 203);
                        if (toIndex == 8) //Milliliter
                            output = Multiplier(InputValue, 4.929);
                        break;
                    case 7: //Liter 
                        if (toIndex == 0) //US Cups
                            output = Multiplier(InputValue, 4.227);
                        if (toIndex == 1) //US Quart
                            output = Multiplier(InputValue, 1.057);
                        if (toIndex == 2) //US Pint
                            output = Multiplier(InputValue, 2.113);
                        if (toIndex == 3) //US Gallon
                            output = Divisor(InputValue, 3.785);
                        if (toIndex == 4) //US Ounce
                            output = Multiplier(InputValue, 33.814);
                        if (toIndex == 5) //US Tablespoon
                            output = Multiplier(InputValue, 67.628);
                        if (toIndex == 6) //US Teaspoon
                            output = Multiplier(InputValue, 203);
                        if (toIndex == 8) //Milliliter
                            output = Multiplier(InputValue, 1000);
                        break;
                    case 8: //Milliliter
                        if (toIndex == 0) //US Cups
                            output = Divisor(InputValue, 237);
                        if (toIndex == 1) //US Quart
                            output = Divisor(InputValue, 946);
                        if (toIndex == 2) //US Pint
                            output = Divisor(InputValue, 473);
                        if (toIndex == 3) //US Gallon
                            output = Divisor(InputValue, 3785);
                        if (toIndex == 4) //US Ounce
                            output = Divisor(InputValue, 28.574);
                        if (toIndex == 5) //US Tablespoon
                            output = Divisor(InputValue, 14.787);
                        if (toIndex == 6) //US Teaspoon
                            output = Divisor(InputValue, 4.929);
                        if (toIndex == 7) //Liter
                            output = Divisor(InputValue, 1000);
                        break;
                }

            }
            return output;           
        }

        /// <summary>
        /// Takes Inputvalue and performs a multipicative operation on it using the value passed in.
        /// </summary>
        /// <param name="inputValue"></param>
        /// <param name="value"></param>
        /// <returns> A string with the General Format specifications with 4 digits of precision</returns>
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
