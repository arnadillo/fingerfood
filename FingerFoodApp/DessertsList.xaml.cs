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
        ChocoSundaeDesc chocoSundae = new ChocoSundaeDesc();
        BononoSplotDesc bononoSplot = new BononoSplotDesc();
        BooCakeDesc booCake = new BooCakeDesc();
        KumKakyeDesc kumKakye = new KumKakyeDesc();

        public DessertsList()
        {
            InitializeComponent();
        }

        private void Choco_Sundae_Clicked(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(chocoSundae);
        }

        private void Bonono_Splot_Clicked(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(bononoSplot);
        }

        private void Boo_Cake_Clicked(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(booCake);
        }

        private void Kum_Kakye_Clicked(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(kumKakye);
        }


    }
}
