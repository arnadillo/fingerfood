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

        BoppityPopDesc boppityPop = new BoppityPopDesc();
        PopMcgeeDesc popMcgee = new PopMcgeeDesc();
        CacoCaloDesc cacoCalo = new CacoCaloDesc();
        BottledWaterDesc bottledWater = new BottledWaterDesc();
        ChocoMilkDesc chocoMilk = new ChocoMilkDesc();
        BerrySmoothieDesc berrySmoothie = new BerrySmoothieDesc();
        EdgeHakuLatteDesc edgeHakuLatte = new EdgeHakuLatteDesc();

        public DrinksList()
        {
            InitializeComponent();
            //navHeader.Navigate(new Uri("NavHeader.xaml", UriKind.Relative)); // Load up the Navigation header for each list page

        }

        private void Boppity_Pop_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(boppityPop);
        }

        private void Pop_McGee_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(popMcgee);
        }

        private void Caco_Calo_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(cacoCalo);
        }

        private void Bottled_Water_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(bottledWater);
        }

        private void Choco_Milk_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(chocoMilk);
        }

        private void Berry_Smoothie_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(berrySmoothie);
        }

        private void Edge_Haku_Latte_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(edgeHakuLatte);
        }


        
    }
}
