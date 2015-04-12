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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {

        public MainMenu()
        {
            InitializeComponent();
        }

        private void Burgers_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BurgersList());
        }

        private void Desserts_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DessertsList());
        }

        private void Sides_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SidesList());
        }

        private void Drinks_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DrinksList());
        }

        private void burgers_imgPressed(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new BurgersList());
        }

        private void sides_imgPressed(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new SidesList());
        }

        private void drinks_imgPressed(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new DrinksList());
        }

        private void desserts_imgPressed(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new DessertsList());
        }


    }
}
