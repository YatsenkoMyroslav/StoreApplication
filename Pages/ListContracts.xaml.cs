using StoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ListContracts.xaml
    /// </summary>
    public partial class ListContracts : Page
    {
        public ListContracts()
        {
            InitializeComponent();
            Background = new SolidColorBrush(Color.FromRgb(0, 0, 64));
        }

        private void Load(object sender, RoutedEventArgs e) {
            IEnumerable<CONTRACT> contracts = DbEntity.Instance().CONTRACT.ToArray().OrderBy(c => c.CONTRACT_NUMBER);

            dataList.ItemsSource = contracts;
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

        private IEnumerable<CONTRACT> SearchData(String contractNumber)
        {
            return DbEntity.Instance().CONTRACT.ToArray().OrderBy(c => c.CONTRACT_NUMBER).Where(c => c.CONTRACT_NUMBER.ToString().StartsWith(contractNumber));
        }
    }
}
