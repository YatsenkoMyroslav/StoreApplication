using StoreApplication.Models;
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

namespace StoreApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListProducts.xaml
    /// </summary>
    public partial class ListProducts : Page
    {
        public ListProducts()
        {
            InitializeComponent();
            Background = new SolidColorBrush(Color.FromRgb(0, 0, 64));
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            IEnumerable<PRODUCT> tttns = DbEntity.Instance().PRODUCT.ToArray().OrderBy(p => p.ID);

            dataList.ItemsSource = tttns;
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            MainPage menuPage = new MainPage();
            NavigationService.Navigate(menuPage);
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            dataList.ItemsSource = SearchData(SearchingField.Text);

            dataList.Items.Refresh();
        }

        private IEnumerable<PRODUCT> SearchData(String name)
        {
            return DbEntity.Instance().PRODUCT.ToArray().OrderBy(p => p.ID).Where(p => p.NAME.ToString().StartsWith(name));
        }
    }
}
