using System;
using System.Collections.Generic;
using System.Linq;
using MortgageCalculator.User_Interfaces;
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
    public partial class StartupHeaderUI : Window
    {
        public StartupHeaderUI()
        {
            InitializeComponent();
            Main.Content = new StartupUI();
        }
        private void MonthlyPaymentButton(object sender, RoutedEventArgs e)
        {
            Main.Content = new MonthlyPaymentUI();
        }
        private void PurchaseBudgetButton(object sender, RoutedEventArgs e)
        {
            Main.Content = new PurchaseBudgetUI();
        }
    }
}
