using StoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        
        private int price, numberPr;
        public AddProduct()
        {
            InitializeComponent();
            Background = new SolidColorBrush(Color.FromRgb(0, 0, 64));
        }

        private void GoBack(object sender, RoutedEventArgs e) {
            MainPage menuPage = new MainPage();
            NavigationService.Navigate(menuPage);
        }

        private void SetErrorMessage(String error) {
            ErrorLabel.Foreground = new SolidColorBrush(Colors.OrangeRed);
            ErrorLabel.Content = error;
        }

        private bool Validate() {
            if (String.IsNullOrEmpty(PrPrice.Text) || String.IsNullOrEmpty(PrNumber.Text) || String.IsNullOrEmpty(PrTitle.Text))
            {
                SetErrorMessage("Fill all empty fields");
                return false;
            } else if (!(Int32.TryParse(PrPrice.Text, out price) && Int32.TryParse(PrNumber.Text,out numberPr))) {
                SetErrorMessage("Check data correctness and try again");
                return false;
            }
            return true;
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            if (Validate()) {

                var db = DbEntity.Instance();

                PRODUCT product = new PRODUCT();

                product.ID = db.PRODUCT.Count() + 1;
                product.PRICE = price;
                product.NUMBER_PREISCURANT = numberPr;
                product.NAME = PrTitle.Text;

                db.PRODUCT.Add(product);

                db.SaveChanges();

                ErrorLabel.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                ErrorLabel.Content = "Succesfully added to DB";
            }
            
        }
    }
}
