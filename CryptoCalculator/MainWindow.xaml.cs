using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CryptoCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            NumberFormatInfo nfi = NumberFormatInfo.CurrentInfo;
            //Regex regex = new Regex(@"^[^0-9]+[^\.]?$");
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
            
        }

        private void TxtExpectedProfit_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtBoxBoughtPrice.Text != string.Empty
                && TxtExpectedProfit.Text != string.Empty
                && TxtBoxBoughtAmount.Text != string.Empty)
            {
                LabelSellPrice.Content =
                    (float.Parse(TxtExpectedProfit.Text) + 1.01*float.Parse(TxtBoxBoughtAmount.Text)) * float.Parse(TxtBoxBoughtPrice.Text) /
                    (0.99*float.Parse(TxtBoxBoughtAmount.Text));
            }
            else
            {
                LabelSellPrice.Content = string.Empty;
            }
        }
    }
}
