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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Background = new SolidColorBrush(Color.FromRgb(0, 0, 64));
        }

        private void Exit(object sender, EventArgs e)
        {
            var response = MessageBox.Show("Want to exit?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (response == MessageBoxResult.Yes)
            {
                DbEntity.ClearConnection();
                Environment.Exit(0);
            }
        }
    }
}
