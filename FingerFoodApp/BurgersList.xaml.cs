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
    /// Interaction logic for BurgersList.xaml
    /// </summary>
    public partial class BurgersList : Page
    {

        public BurgersList()
        {
            InitializeComponent();
            ((FirstWindow)System.Windows.Application.Current.MainWindow).navHeader.Visibility = Visibility.Visible;
            Application.Current.Properties["isList"] = true;
        }

        private void Simple_Simon_Clicked(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SimpleSimonDesc());
        }

        private void bangkok_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BangkokSandwichDesc());
        }

        private void Bactrian_Camel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CamelBurgerDesc());
        }

        private void Inverted_Burger_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new InvertedBurgerDesc());
        }

        private void Meat_Prism_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new meatPrismDesc());
        }

        private void Whoopity_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WhoopityDesc());
        }

        private void Mount_Angus_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MountAngusDesc());
        }



    }

}
