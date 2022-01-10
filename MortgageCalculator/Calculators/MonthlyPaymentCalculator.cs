using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MortgageCalculator
{
    public class MonthlyPaymentCalculator : ObservableObject
    {
        private double _interestRate;
        private double _loanAmount;
        private int _loanTerm;
        private string[] _loanTermOptions;
        private double _monthlyPayment;
        private double _mortgage;
        private int _paymentsPerYear;
        public MonthlyPaymentCalculator()
        {
            SetUp();
        }
        public double MPCalculator()
        {
            double total = Math.Round(_mortgage, 0, MidpointRounding.AwayFromZero);

            return total;
        }
        public double MortgageCalculator()
        {
            double numerator = _loanAmount * ((_interestRate / 100) / _paymentsPerYear) * Math.Pow((1 + ((_interestRate / 100) / _paymentsPerYear)), (_paymentsPerYear * _loanTerm));

            double denominator = Math.Pow((1 + ((_interestRate / 100) / _paymentsPerYear)), _paymentsPerYear * _loanTerm) - 1;

            double mortgagePayment = Math.Round((numerator / denominator), 0, MidpointRounding.AwayFromZero);

            return mortgagePayment;
        }
        public void SetUp()
        {
            _interestRate = 3.5;
            _loanAmount = 240000;
            _loanTerm = 30;
            _loanTermOptions = new string[] { "15-Year Fixed", "20-Year Fixed", "30-Year Fixed" };
            _paymentsPerYear = 12;
        }
        public bool TextConversionToDouble(TextBox input)
        {
            double convertedText;
            try
            {
                convertedText = Convert.ToDouble(input.Text);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //Properties
        public double InterestRate
        {
            get { return _interestRate; }
            set
            {
                _interestRate = value;
                var mortgageUpdate = MortgageCalculator();
                this.Mortgage = mortgageUpdate;
            }
        }
        public double LoanAmount
        {
            get { return _loanAmount; }
            set
            {
                _loanAmount = value;
                var mortgageUpdate = MortgageCalculator();
                this.Mortgage = mortgageUpdate;
            }
        }
        public int LoanTerm
        {
            get { return _loanTerm; }
            set
            {
                _loanTerm = value;
                var mortgageUpdate = MortgageCalculator();
                this.Mortgage = mortgageUpdate;
            }
        }
        public string[] LoanTermOptions
        {
            get { return _loanTermOptions; }
        }
        public double MonthlyPayment
        {
            get { return _monthlyPayment; }
            set
            {
                _monthlyPayment = value;
                OnPropertyChanged();
            }
        }
        public double Mortgage
        {
            get { return _mortgage; }
            set
            {
                _mortgage = value;
                var monthlyPaymentUpdate = MPCalculator();
                this.MonthlyPayment = monthlyPaymentUpdate;
            }
        }
    }
}
