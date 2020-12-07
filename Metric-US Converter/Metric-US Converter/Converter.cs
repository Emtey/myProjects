using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metric_US_Converter
{
    /// <summary>
    /// This class gets the values, then figures out what to do with them
    /// and calls the appropriate class depending on the values.
    /// </summary>
    public class Converter
    {
        private double inputValue;
        private int fromIndex;
        private int toIndex;
        private int indexType;

        //Constructor
        public Converter(double inputValue, int fromIndex, int toIndex, int indexType)
        {
            this.InputValue = inputValue;
            this.FromIndex = fromIndex;
            this.ToIndex = toIndex;
            this.IndexType = indexType;
        }

        #region Getters/Setters
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
        public string Do_Conversion()
        {
            string conversionOutput = "";
            switch (IndexType)
            {
                case 0: //temperature
                    Temperature myTemp = new Temperature(inputValue, FromIndex, ToIndex);
                    conversionOutput = myTemp.ConvertTemperature();
                    break;
                /*case 1: //Length
                    Length myLength = new Length(inputValue, index);
                    conversionOutput = myLength.ConvertLength();
                    break;
                case 2: //Volume
                    Volume myVolume = new Volume(inputValue, index);
                    conversionOutput = myVolume.ConvertVolume();
                    break;*/
            }

            return conversionOutput;
        }
    }
}
