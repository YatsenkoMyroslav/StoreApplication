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
    /// Логика взаимодействия для AddDelivery.xaml
    /// </summary>
    public partial class AddDelivery : Page
    {

        private int amount, price, contractNumber, trNumber;
        public AddDelivery()
        {
            InitializeComponent();
            Background = new SolidColorBrush(Color.FromRgb(0, 0, 64));

            var transports = DbEntity.Instance().TRANSPORT.OrderBy(t => t.ID);

            foreach (var t in transports) 
                TransportType.Items.Add(t.NAME);

            TransportType.SelectedIndex= 0;
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
            if (String.IsNullOrEmpty(DelNumber.Text) || String.IsNullOrEmpty(ContrNumber.Text) || String.IsNullOrEmpty(Amount.Text) || String.IsNullOrEmpty(Price.Text))
            {
                SetErrorMessage("Fill all empty fields");
                return false;
            }
            else if (!(Int32.TryParse(ContrNumber.Text, out contractNumber) && Int32.TryParse(Price.Text, out price) && Int32.TryParse(Amount.Text, out amount) && Int32.TryParse(DelNumber.Text, out trNumber)))
            {
                SetErrorMessage("Check data correctness and try again");
                return false;
            }
            else if (DbEntity.Instance().CONTRACT.FirstOrDefault(p => p.CONTRACT_NUMBER == contractNumber) == null)
            {
                SetErrorMessage("Incorrect contract number");
                return false;
            }
            return true;
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                var db = DbEntity.Instance();

                TTH ttn = new TTH();

                ttn.TRANSPORT_TYPE = TransportType.SelectedIndex + 1;
                ttn.NUMBER_TTH = trNumber;
                ttn.NUMBER_CONTRACT = contractNumber;
                ttn.PRODUCT_TYPE = db.CONTRACT.FirstOrDefault(c => c.CONTRACT_NUMBER == contractNumber).PRODUCT_TYPE;
                ttn.NUMBER_OF_PRODUCTS = amount;
                ttn.PRICE = price;
                ttn.DATE_OF_DEPARTURE = DateTime.Now;

                db.TTH.Add(ttn);

                db.SaveChanges();

                ErrorLabel.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                ErrorLabel.Content = "Succesfully added to DB";
            }

        }
    }
}
