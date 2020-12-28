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
        private int fromIndex;
        private int toIndex;

        public Length(double inputValue, int fromIndex, int toIndex)
        {
            this.InputValue = inputValue;
            this.FromIndex = fromIndex;
            this.ToIndex = toIndex;
        }

        #region GET/SET
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

       /* This is the zero indexed list
         ("Inches");        = 0
         ("Feet");          = 1   
         ("Yards");         = 2
         ("Miles");         = 3
         ("Millimeters");   = 4
         ("Centimeters");   = 5
         ("Meters");        = 6
         ("Kilometers");    = 7
       */
        public string ConvertLength()
        {
            string output = "";

            if (toIndex == fromIndex)
                return String.Format("{0}", inputValue.ToString("0.##"));
            else
            {
                switch (fromIndex)
                {
                    case 0: //inches
                        if (toIndex == 1)  //Feet
                            output = Divisor(InputValue, 12);
                        if (toIndex == 2) //Yard
                            output = Divisor(InputValue, 36);
                        if (toIndex == 3) //Miles
                            output = Divisor(InputValue, 63360);
                        if (toIndex == 4) //Millimeters
                            output = Multiplier(InputValue, 25.4);
                        if (toIndex == 5) //Centimeters
                            output = Multiplier(InputValue, 2.54);
                        if (toIndex == 6) //Meters
                            output = Divisor(InputValue, 39.37);
                        if (toIndex == 7) //Kilometers
                            output = Divisor(InputValue, 39370);                        
                        break;
                    case 1:  //feet
                        if (toIndex == 0) //inches
                            output = Multiplier(InputValue, 12);
                        if (toIndex == 2) //Yards
                            output = Divisor(InputValue, 3);
                        if (toIndex == 3) //Miles
                            output = Divisor(InputValue, 5280);
                        if (toIndex == 4) //Millimeters
                            output = Multiplier(InputValue, 305);
                        if (toIndex == 5) //Centimeters
                            output = Multiplier(InputValue, 30.48);
                        if (toIndex == 6) //Meters
                            output = Divisor(InputValue, 3.281);
                        if (toIndex == 7)  //kilometers
                            output = Divisor(InputValue, 3281); 
                        break;
                    case 2:  //yards
                        if (toIndex == 0) //inches 
                            output = Multiplier(InputValue, 36);
                        if (toIndex == 1) //feet
                            output = Multiplier(InputValue, 3);
                        if (toIndex == 3) //Miles
                            output = Divisor(InputValue, 1760);
                        if (toIndex == 4) //Millimeters
                            output = Multiplier(InputValue, 914);
                        if (toIndex == 5) //Centimeters
                            output = Multiplier(InputValue, 91.44);
                        if (toIndex == 6) //Meters
                        if (toIndex == 7)  //kilometers
                       
                        break;
                    case 3:  //miles
                        if (toIndex == 0) //inches
                        if (toIndex == 1) //feet
                        if (toIndex == 2) //Yards
                        if (toIndex == 4) //Millimeters
                        if (toIndex == 5) //Centimeters
                        if (toIndex == 6) //Meters
                        if (toIndex == 7)  //kilometers
                       
                        break;
                }
                return output;
            }
        }

        private string Multiplier(double inputValue, double value)
        {
            double myValue = (inputValue * value);
            return String.Format("{0}", myValue.ToString("0.##"));
        }

        private string Divisor(double inputValue, double value)
        {
            double myValue = (inputValue / value);
            return String.Format("{0}", myValue.ToString("0.####"));
        }
    }
}
