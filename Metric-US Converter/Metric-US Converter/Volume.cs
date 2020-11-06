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
        private int index;

        public Volume(double inputValue, int index)
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

        public string ConvertVolume()
        {
            string output = "";
            switch (index)
            {
                case 0:
                    output = CupsToGallons(inputValue);
                    break;
                case 1:
                    output = GallonsToCups(inputValue);
                    break;
            }
            return output;
        }

        private string CupsToGallons(double inputValue)
        {
            double myValue = (inputValue / 16);
            return String.Format("{0} gals", myValue.ToString("0.####"));
        }

        private string GallonsToCups(double inputValue)
        {
            double myValue = (inputValue * 16);
            return String.Format("{0} cups", myValue.ToString("0.####"));
        }
    }
}
