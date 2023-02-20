using StoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace StoreApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignContract.xaml
    /// </summary>
    public partial class SignContract : Page
    {
        private int amount;
        public SignContract()
        {
            InitializeComponent();
            Background = new SolidColorBrush(Color.FromRgb(0, 0, 64));
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            MainPage menuPage = new MainPage();
            NavigationService.Navigate(menuPage);
        }

        private void SetErrorMessage(String error)
        {
            ErrorLabel.Foreground = new SolidColorBrush(Colors.OrangeRed);
            ErrorLabel.Content = error;
        }

        private bool Validate()
        {
            if (String.IsNullOrEmpty(CompanyName.Text) || String.IsNullOrEmpty(PrTitle.Text) || String.IsNullOrEmpty(Amount.Text))
            {
                SetErrorMessage("Fill all empty fields");
                return false;
            }
            else if (!(Int32.TryParse(Amount.Text, out amount)))
            {
                SetErrorMessage("Check amount correctness and try again");
                return false;
            } else if (DbEntity.Instance().PRODUCT.FirstOrDefault(p => p.NAME == PrTitle.Text)==null) {
                SetErrorMessage("Incorrect product title");
                return false;
            }
            return true;
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {

                CONTRACT contract = new CONTRACT();

                var db = DbEntity.Instance();

                var customer = db.CUSTOMER.FirstOrDefault(c => c.COMPANY_NAME == CompanyName.Text);

                int customerId = 0;

                if (customer == null)
                {
                    customer = new CUSTOMER();
                    customer.ID = db.CUSTOMER.ToArray().Max(c => c.ID) + 1;
                    customer.COMPANY_NAME = CompanyName.Text;
                }
                
                customerId = customer.ID;

                db.CUSTOMER.Add(customer);
                db.SaveChanges();

                
                contract.PRODUCT_TYPE = db.PRODUCT.FirstOrDefault(p => p.NAME == PrTitle.Text).ID;
                contract.CONTRACT_NUMBER = db.CONTRACT.Count() + 1;
                contract.CUSTOMER_ID = customerId;
                contract.AMOUNT = amount;
                contract.DATA = DateTime.Now;

                db.CONTRACT.Add(contract);

                db.SaveChanges();

                ErrorLabel.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                ErrorLabel.Content = $"Contract number {contract.CONTRACT_NUMBER}";
            }

        }
    }
}
