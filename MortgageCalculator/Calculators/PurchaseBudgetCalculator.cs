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
    public class PurchaseBudgetCalculator : ObservableObject
    {
        private double _annualIncome;
        private string[] _creditScoreOptions;
        private double _downPayment;
        private double _interestRate;
        private double[,] _interestRateTable;
        private int _loanTerm;
        private string[] _loanTermOptions;
        private double _monthlyDebt;
        private double _mortgageAmount;
        private int _paymentsPerYear;
        private double _purchaseBudget;
        public PurchaseBudgetCalculator()
        {
            SetUp();
        }
        public void InterestRateTableSetUp()
        {
            _interestRateTable = new double[6, 1];

            for (int row = 0; row < _interestRateTable.GetLength(0); row++)
            {
                for (int column = 0; column < _interestRateTable.GetLength(1); column++)
                {
                    if (row == 0)
                    {
                        _interestRateTable[row, column] = 4.402;
                    }
                    else if (row == 1)
                    {
                        _interestRateTable[row, column] = 3.856;
                    }
                    else if (row == 2)
                    {
                        _interestRateTable[row, column] = 3.426;
                    }
                    else if (row == 3)
                    {
                        _interestRateTable[row, column] = 3.212;
                    }
                    else if (row == 4)
                    {
                        _interestRateTable[row, column] = 3.035;
                    }
                    else
                    {
                        _interestRateTable[row, column] = 2.813;
                    }
                }
            }
        }
        public double MortgageAmountCalculator()
        {
            double monthlyNetIncome = (_annualIncome / 12) - _monthlyDebt;

            double monthlyBudget = (monthlyNetIncome / 100) * 28;

            double numerator = monthlyBudget * (Math.Pow((1 + ((_interestRate / 100) / _paymentsPerYear)), _paymentsPerYear * _loanTerm) - 1);

            double denominator = ((_interestRate / 100) / _paymentsPerYear) * Math.Pow((1 + ((_interestRate / 100) / _paymentsPerYear)), (_paymentsPerYear * _loanTerm));

            double mortgageAmount = Math.Round((numerator / denominator), 0, MidpointRounding.AwayFromZero);

            return mortgageAmount;
        }
        public double PBCalculator()
        {
            return _downPayment + _mortgageAmount;
        }
        public void SetUp()
        {
            _annualIncome = 57000;
            _creditScoreOptions = new string[] { "760 - 850", "700 - 759", "680 - 699", "660 - 679", "640 - 659", "620 - 639" };
            _downPayment = 60000;
            _interestRate = 6;
            _loanTerm = 30;
            _loanTermOptions = new string[] { "15-Year Fixed", "20-Year Fixed", "30-Year Fixed" };
            _monthlyDebt = 250;
            _paymentsPerYear = 12;
            InterestRateTableSetUp();
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
        public double AnnualIncome
        {
            get { return _annualIncome; }
            set
            {
                _annualIncome = value;
                var mortgageAmountUpdate = MortgageAmountCalculator();
                this.MortgageAmount = mortgageAmountUpdate;
            }
        }
        public string[] CreditScoreOptions
        {
            get { return _creditScoreOptions; }
            set { _creditScoreOptions = value; }
        }
        public double DownPayment
        {
            get { return _downPayment; }
            set
            {
                _downPayment = value;
                var mortgageAmountUpdate = MortgageAmountCalculator();
                this.MortgageAmount = mortgageAmountUpdate;
            }
        }
        public double InterestRate
        {
            get { return _interestRate; }
            set
            {
                _interestRate = value;
                OnPropertyChanged();
                var mortgageAmountUpdate = MortgageAmountCalculator();
                this.MortgageAmount = mortgageAmountUpdate;
            }
        }
        public double[,] InterestRateTable
        {
            get { return _interestRateTable; }
            set { _interestRateTable = value; }
        }
        public int LoanTerm
        {
            get { return _loanTerm; }
            set
            {
                _loanTerm = value;
                var mortgageAmountUpdate = MortgageAmountCalculator();
                this.MortgageAmount = mortgageAmountUpdate;
            }
        }
        public string[] LoanTermOptions
        {
            get { return _loanTermOptions; }
        }
        public double MonthlyDebt
        {
            get { return _monthlyDebt; }
            set
            {
                if (value > (_annualIncome / 12))
                {
                    MessageBox.Show("Monthly Debt cannot exceed Monthly Income.");
                }
                else
                {
                    _monthlyDebt = value;
                    var mortgageAmountUpdate = MortgageAmountCalculator();
                    this.MortgageAmount = mortgageAmountUpdate;
                }
            }
        }
        public double MortgageAmount
        {
            get { return _mortgageAmount; }
            set
            {
                _mortgageAmount = value;
                OnPropertyChanged();
                var purchaseBudgetUpdate = PBCalculator();
                this.PurchaseBudget = purchaseBudgetUpdate;
            }
        }
        public double PurchaseBudget
        {
            get { return _purchaseBudget; }
            set
            {
                _purchaseBudget = value;
                OnPropertyChanged();
            }
        }
    }
}