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
                case 2:
                    output = USCupToUSQuart(inputValue);
                    break;
                case 3:
                    output = USQuartToUSCup(inputValue);
                    break;
                case 4:
                    output = USCupToUSPint(inputValue);
                    break;
                case 5:
                    output = USPintToUSCup(inputValue);
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

        private string USCupToUSQuart(double inputValue)
        {
            double myValue = (inputValue / 4);
            return String.Format("{0} US Quarts", myValue.ToString("0.###"));
        }
        private string USQuartToUSCup(double inputValue)
        {
            double myValue = (inputValue * 4);
            return String.Format("{0} cups", myValue.ToString("0.###"));
        }

        private string USCupToUSPint(double inputValue)
        {
            double myValue = (inputValue / 2);
            return String.Format("{0} US Pints", myValue.ToString("0.##"));
        }

        private string USPintToUSCup(double inputValue)
        {
            double myValue = (inputValue * 2);
            return String.Format("{0} US Cups", myValue.ToString("0.##"));
        }

        private string USCuptoUSLegalCup(double inputValue)
        {
            double myValue = (inputValue / 1.014);
            return String.Format("{0} US Legal Cups", myValue.ToString("0.##"));
        }
        
        private string USCupToUSFluidOunce (double inputvalue)
        {
            double myValue = (inputValue * 8);
            return String.Format("{0} US Fluid Oz", myValue.ToString("0.##"));
        }
        
        private string USFLuidOunceToUSCup(double inputvalue)
        {
            double myValue = (inputValue / 8);
            return String.Format("{0} US Cups", myValue.ToString("0.##"));
        }

        private string USFLuidOunceToUSGallon(double inputvalue)
        {
            double myValue = (inputValue / 128);
            return String.Format("{0} US Gallons", myValue.ToString("0.####"));
        }

    }
}
