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
    /// Interaction logic for DrinksList.xaml
    /// </summary>
    public partial class DrinksList : Page
    {

        public DrinksList()
        {
            InitializeComponent();
            ((FirstWindow)System.Windows.Application.Current.MainWindow).navHeader.Visibility = Visibility.Visible;

            int isMenu = (int)Application.Current.Properties["counter"];
            isMenu++;
            Application.Current.Properties["counter"] = isMenu;

        }

        private void Boppity_Pop_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BoppityPopDesc());
        }

        private void Pop_McGee_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PopMcgeeDesc());
        }

        private void Caco_Calo_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CacoCaloDesc());
        }

        private void Bottled_Water_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BottledWaterDesc());
        }

        private void Choco_Milk_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ChocoMilkDesc());
        }

        private void Berry_Smoothie_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BerrySmoothieDesc());
        }

        private void Edge_Haku_Latte_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EdgeHakuLatteDesc());
        }
        
    }
}
