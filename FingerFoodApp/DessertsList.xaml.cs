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

namespace FingerFoodApp
{
    /// <summary>
    /// Interaction logic for DessertsList.xaml
    /// </summary>
    public partial class DessertsList : Page
    {
        public DessertsList()
        {
            InitializeComponent();
            ((FirstWindow)System.Windows.Application.Current.MainWindow).navHeader.Visibility = Visibility.Visible;

            int isMenu = (int)Application.Current.Properties["counter"];
            isMenu++;
            Application.Current.Properties["counter"] = isMenu;

        }

        private void Choco_Sundae_Clicked(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ChocoSundaeDesc());
        }

        private void Bonono_Splot_Clicked(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BononoSplotDesc());
        }

        private void Boo_Cake_Clicked(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BooCakeDesc());
        }

        private void Kum_Kakye_Clicked(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new KumKakyeDesc());
        }


    }
}
