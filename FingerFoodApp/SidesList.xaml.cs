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
    /// Interaction logic for SidesList.xaml
    /// </summary>
    public partial class SidesList : Page
    {

        FriesDesc fries = new FriesDesc();
        PoutineDesc poutine = new PoutineDesc();
        OnionRingsDesc onionRings = new OnionRingsDesc();
        HashbrownDesc hashbrown = new HashbrownDesc();
        blueberryMuffin blueberryMuffin = new blueberryMuffin();

        public SidesList()
        {
            InitializeComponent();
            ((FirstWindow)System.Windows.Application.Current.MainWindow).navHeader.Visibility = Visibility.Visible;
        }

        private void Fries_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new FriesDesc());
        }

        private void Poutine_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PoutineDesc());
        }

        private void Onion_Rings_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new OnionRingsDesc());
        }

        private void Hashbrown_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HashbrownDesc());
        }

        private void Blueberry_Muffin_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(blueberryMuffin);
        }
    }
}
