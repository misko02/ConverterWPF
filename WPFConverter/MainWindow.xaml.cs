using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        Dictionary<string, int> posBase = new Dictionary<string, int>
        {
            {"Decimal", 10},
            {"Binary",2 },
            {"Octal",8 },
            {"Hexadecimal",16},
            {"ASCII",1 }
        };
      

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItemFrom_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            
            OptionsFrom.Header = menuItem.Header;
        }

        private void MenuItemTo_Click(object sender, RoutedEventArgs e)
        {
            MenuItem? menuItem = sender as MenuItem;

            OptionsTo.Header = menuItem.Header;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            
            switch (OptionsFrom.Header)
            {
                case "Decimal":Output.Text = DecConvert(Input.Text, posBase[(string)OptionsTo.Header]); break;
                case "Binary":break;
                case "Octal":Output.Text = DecConvert(Input.Text, posBase[(string)OptionsTo.Header]); break;
                case "Hexadecimal":break;
                case "ASCII":break;                                                                            
                default: Output.Text = Input.Text; break;                                                  
            }                                                                                              
        }                                                                                                   
        #region ConvertionFunctions

        static string DecConvert(string decimalVal,int posBase)
        {
            string ResultVal= "";
            int decimalValAsInt = Convert.ToInt32(decimalVal);
            while (decimalValAsInt != 0)
            {
                if (posBase == 16 && (decimalValAsInt % posBase) > 7)
                {
                    ResultVal += (char)(55 + (decimalValAsInt % posBase));          //54 dlatego że 64-9 czyli pierwsza litera w ASCII - 7 pozycji mające reprezentaje
                }
                else
                {
                    ResultVal += (decimalValAsInt % posBase);
                }
                decimalValAsInt /= posBase;

            }

            string ResultValReversed = "";
            for(int i = ResultVal.Length-1; i >= 0; i--)
            {
                ResultValReversed += ResultVal[i];
            }
            return ResultValReversed;
        }

        static string OctConvert(string octVal, int posBase)
        {
            string ResultVal = "";
            if (posBase == 10)
            {

                for (int i = 0; i < octVal.Length - 1; i++)
                {
                    ResultVal += ((int)octVal[i] * Math.Pow(8, octVal.Length - 1 - i));
                }
            }
            return ResultVal;
        }
            #endregion
    }
}
