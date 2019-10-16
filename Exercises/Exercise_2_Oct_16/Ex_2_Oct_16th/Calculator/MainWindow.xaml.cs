using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            currentOperation = Operations.NO_OP;
        }

        #region Data Members
        private double leftInput;
        private double result;

        private Operations currentOperation;
        private enum Operations
        {
            ADD, SUBTR, MULTIP, DIVIDE, NO_OP
        }

        #endregion

        #region Operation event handlers

        private void OperationProcessing(string operationText)
        {
            switch (operationText)
            {
                case "+":
                    currentOperation = Operations.ADD;
                    break;

                case "-":
                    currentOperation = Operations.SUBTR;
                    break;

                case "X":
                    currentOperation = Operations.MULTIP;
                    break;

                case "/":
                    currentOperation = Operations.DIVIDE;

                    break;
                default:
                    currentOperation = Operations.NO_OP;
                    break;
            }

            leftInput = Convert.ToDouble(TxtInput.Text);
            TxtInput.Text = "0";

        }

        private void Btn_OperationClick(object sender, RoutedEventArgs e)
        {
            OperationProcessing((string)((Button)sender).Content);
        }

        private void Btn_ComputeClick(object sender, RoutedEventArgs e)
        {
            switch (currentOperation)
            {
                case Operations.ADD:
                    result = leftInput + Convert.ToDouble(TxtInput.Text);
                    break;
                case Operations.SUBTR:
                    result = leftInput - Convert.ToDouble(TxtInput.Text);
                    break;
                case Operations.MULTIP:
                    result = leftInput * Convert.ToDouble(TxtInput.Text);
                    break;
                case Operations.DIVIDE:
                    double rightInput = Convert.ToDouble(TxtInput.Text);
                    if (!rightInput.Equals(0))
                    {
                        result = leftInput / Convert.ToDouble(TxtInput.Text);
                    }
                    else
                    {
                        TxtInput.Text = "Division by 0 is undefined";
                    }
                    break;
                case Operations.NO_OP:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            TxtInput.Text = result.ToString();
            currentOperation = Operations.NO_OP;
            result = 0;
        }
        #endregion

        #region Number event handlers

        private void TypeDigit(string digit)
        {
           
            if (TxtInput.Text.Equals("0"))
            {
                TxtInput.Text = digit;
            }
            else
            {

                TxtInput.Text += digit;
            }
        }

        private void NumberBtn_OnClick(object sender, RoutedEventArgs e)
        {
            TypeDigit((string)((Button)sender).Content);
        }
        #endregion

        private void Btn_DotClick(object sender, RoutedEventArgs e)
        {
            TypeDigit((string)((Button)sender).Content);
        }

        #region Clearing handlers
        private void Btn_ClearLast(object sender, RoutedEventArgs e)
        {
            TxtInput.Text = "0";
        }

        private void Btn_ClearAll(object sender, RoutedEventArgs e)
        {
            TxtInput.Text = "0";
            currentOperation = Operations.NO_OP;
            result = 0;
        } 
        #endregion
    }
}
