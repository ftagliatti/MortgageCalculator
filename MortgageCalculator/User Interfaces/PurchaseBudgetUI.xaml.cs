using System;
using System.Collections.Generic;
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

namespace MortgageCalculator
{
    public partial class PurchaseBudgetUI
    {
        PurchaseBudgetCalculator _calculator = new PurchaseBudgetCalculator();
        public PurchaseBudgetUI()
        {
            InitializeComponent();
            DataContext = _calculator;
            LoanTermComboBox.ItemsSource = _calculator.LoanTermOptions;
            CreditScoreComboBox.ItemsSource = _calculator.CreditScoreOptions;
        }
        private void AnnualIncomeTextBox_KeyDown(object sender, KeyEventArgs e)
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
        private void CreditScoreComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selection = CreditScoreComboBox.SelectedItem.ToString();

            if (selection.Equals("620 - 639"))
            {
                _calculator.InterestRate = _calculator.InterestRateTable[0, 0];
            }
            else if (selection.Equals("640 - 659"))
            {
                _calculator.InterestRate = _calculator.InterestRateTable[1, 0];
            }
            else if (selection.Equals("660 - 679"))
            {
                _calculator.InterestRate = _calculator.InterestRateTable[2, 0];
            }
            else if (selection.Equals("680 - 699"))
            {
                _calculator.InterestRate = _calculator.InterestRateTable[3, 0];
            }
            else if (selection.Equals("700 - 759"))
            {
                _calculator.InterestRate = _calculator.InterestRateTable[4, 0];
            }
            else
            {
                _calculator.InterestRate = _calculator.InterestRateTable[5, 0];
            }
        }
        private void DownPaymentTextBox_KeyDown(object sender, KeyEventArgs e)
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
        private void MonthlyDebtTextBox_KeyDown(object sender, KeyEventArgs e)
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
    }
}