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
                            output = Divisor(InputValue, 1.094);
                        if (toIndex == 7)  //kilometers
                            output = Divisor(InputValue, 1094); 
                        break;
                    case 3:  //miles
                        if (toIndex == 0) //inches
                            output = Multiplier(InputValue, 63360);
                        if (toIndex == 1) //feet
                            output = Multiplier(InputValue, 5280);
                        if (toIndex == 2) //Yards
                            output = Multiplier(InputValue, 1760);
                        if (toIndex == 4) //Millimeters
                            output = Multiplier(InputValue, 1.609e+6);
                        if (toIndex == 5) //Centimeters
                            output = Multiplier(InputValue, 160934);
                        if (toIndex == 6) //Meters
                            output = Multiplier(InputValue, 1609);
                        if (toIndex == 7)  //kilometers
                            output = Multiplier(InputValue, 1.609);
                        break;
                    case 4: // millimeters
                        if (toIndex == 0) //inches
                            output = Divisor(InputValue, 25.4);
                        if (toIndex == 1) //feet
                            output = Divisor(InputValue, 305);
                        if (toIndex == 2) //yards
                            output = Divisor(InputValue, 914);
                        if (toIndex == 3) //miles
                            output = Divisor(InputValue, 1.609e+6);
                        if (toIndex == 5) //centimeters
                            output = Divisor(InputValue, 10);
                        if (toIndex == 6) //meters
                            output = Divisor(InputValue, 1000);
                        if (toIndex == 7) //Kilometers
                            output = Divisor(InputValue, 1000000);  
                        break; 
                    case 5: // centimeters
                        if (toIndex == 0) //inches
                            output = Divisor(InputValue, 2.54);
                        if (toIndex == 1) //feet
                            output = Divisor(InputValue, 30.48);
                        if (toIndex == 2) //yard
                            output = Divisor(InputValue, 91.44);
                        if (toIndex == 3) //miles
                            output = Divisor(InputValue, 160934);
                        if (toIndex == 4) //millimeters
                            output = Multiplier(InputValue, 10);
                        if (toIndex == 6) //meters
                            output = Divisor(InputValue, 100);
                        if (toIndex == 7) //Kilometers
                            output = Divisor(InputValue, 100000);
                        break;
                    case 6: //meters
                        if (toIndex == 0) //inches
                            output = Multiplier(InputValue, 39.37);
                        if (toIndex == 1) //feet
                            output = Multiplier(InputValue, 3.281);
                        if (toIndex == 2) //yard
                            output = Multiplier(InputValue, 1.094);
                        if (toIndex == 3) //miles
                            output = Divisor(InputValue, 1609);
                        if (toIndex == 4) //millimeters
                            output = Multiplier(InputValue, 1000);
                        if (toIndex == 5) //centimeters
                            output = Multiplier(InputValue, 100);
                        if (toIndex == 7) //Kilometers
                            output = Divisor(InputValue, 1000); 
                        break;
                    case 7: //kilometers
                        if (toIndex == 0) //inches
                            output = Multiplier(InputValue, 393370);
                        if (toIndex == 1) //feet
                            output = Multiplier(InputValue, 3281);
                        if (toIndex == 2) //yards
                            output = Multiplier(InputValue, 1094);
                        if (toIndex == 3) //miles
                            output = Divisor(InputValue, 1.609);
                        if (toIndex == 4) //millimeters
                            output = Multiplier(InputValue, 1e+6);
                        if (toIndex == 5) //centimeters
                            output = Multiplier(InputValue, 100000);
                        if (toIndex == 6) //meters
                            output = Multiplier(InputValue, 1000);
                        break;
                }
                return output;
            }
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
