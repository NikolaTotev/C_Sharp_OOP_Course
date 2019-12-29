using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Homework_4_Ex2_UserControl
{
    /// <summary>
    /// Interaction logic for CashRegister.xaml
    /// </summary>
    public partial class CashRegister : UserControl
    {
        private List<decimal> m_NumberArray;
        public CashRegister()
        {
            InitializeComponent();
            m_NumberArray = new List<decimal>();
        }

        
        private void OnEnterClick(object sender, RoutedEventArgs e)
        {
            decimal input;
            if (decimal.TryParse(TbDisplay.Text, out input))
            {
                m_NumberArray.Add(input);
                TbDisplay.Text = "";
            }
        }

        private void OnNumberBtnClick(object sender, RoutedEventArgs e)
        {

            string inputChar = (sender as Button).Content.ToString();
            string newText = TbDisplay.Text + inputChar;
            TbDisplay.Text = newText;
        }

        private void OnTotalClick(object sender, RoutedEventArgs e)
        {
            decimal sum = 0;
            foreach (var number in m_NumberArray)
            {
                sum += number;
            }

            decimal tax;
            if (!decimal.TryParse(TxtTaxInput.Text, out tax))
            {
                tax = 0;
            }

            LbSubtotal.Content = sum.ToString(CultureInfo.CurrentCulture);
            LbTotal.Content = (sum + tax).ToString(CultureInfo.CurrentCulture);

        }

        private void OnDeleteClick(object sender, RoutedEventArgs e)
        {
            TbDisplay.Text = "";
        }

        private void OnClearClick(object sender, RoutedEventArgs e)
        {
            m_NumberArray.Clear();
            
            TbDisplay.Text = "";

            LbSubtotal.Content = "";
            TxtTaxInput.Text = "0";
            LbTotal.Content = "";
            
        }
    }
}

