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
    /// Логика взаимодействия для ListDelivery.xaml
    /// </summary>
    public partial class ListDelivery : Page
    {
        public ListDelivery()
        {
            InitializeComponent();
            Background = new SolidColorBrush(Color.FromRgb(0, 0, 64));
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            IEnumerable<TTHInfoJoinedWithCompanyNameAndProductName> tttns = DbEntity.Instance().TTHInfoJoinedWithCompanyNameAndProductName.ToArray().OrderBy(t => t.ID);

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

        private IEnumerable<TTHInfoJoinedWithCompanyNameAndProductName> SearchData(String ttnNumber)
        {
            return DbEntity.Instance().TTHInfoJoinedWithCompanyNameAndProductName.ToArray().OrderBy(t => t.ID).Where(t => t.ID.ToString().StartsWith(ttnNumber));
        }
    }
}
