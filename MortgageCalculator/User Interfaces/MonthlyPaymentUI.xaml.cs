using System;
using System.Collections.Generic;
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

namespace MortgageCalculator
{
    public partial class MonthlyPaymentUI
    {
        MonthlyPaymentCalculator _calculator = new MonthlyPaymentCalculator();
        public MonthlyPaymentUI()
        {
            InitializeComponent();
            DataContext = _calculator;
            LoanTermComboBox.ItemsSource = _calculator.LoanTermOptions;
        }
        private void InterestRateTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txtDecimal = sender as TextBox;

            if ((e.Key == Key.OemPeriod || e.Key == Key.Decimal) && (txtDecimal.Text.Contains(".") == false))
            {
                e.Handled = false;
            }
            else if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.Back || e.Key == Key.Tab)
            {
                e.Handled = false;
            }
            else if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void LoanAmountTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.Decimal || e.Key == Key.Back || e.Key == Key.Tab)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void LoanTermComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selection = LoanTermComboBox.SelectedItem.ToString();

            if (selection.Equals("30-Year Fixed"))
            {
                _calculator.LoanTerm = 30;
            }
            else if (selection.Equals("20-Year Fixed"))
            {
                _calculator.LoanTerm = 20;
            }
            else
            {
                _calculator.LoanTerm = 15;
            }
        }
    }
}