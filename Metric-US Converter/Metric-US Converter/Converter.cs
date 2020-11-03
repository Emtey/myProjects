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
        private int indexType;

        //Constructor
        public Converter(double inputValue, int index, int indexType)
        {
            this.InputValue = inputValue;
            this.Index = index;
            this.IndexType = indexType;
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
            set { index = value; }
        }

        public int IndexType
        {
            get { return indexType; }
            set { indexType = value; }
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
            switch (IndexType)
            {
                case 0: //temperature
                    Temperature myTemp = new Temperature(inputValue, index);
                    conversionOutput = myTemp.ConvertTemperature();
                    break;
                case 1: //Length
                    Length myLength = new Length(inputValue, index);
                    conversionOutput = myLength.ConvertLength();
                    break;
            }

            return conversionOutput;
        }

        

        
    }
}
