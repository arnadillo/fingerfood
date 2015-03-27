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

    public partial class MainWindow : Window
    {
        /**
         *  MainWindow()
         *      - Displays Main Menu of Application
         *      - Visibility of All Menu Lists is Off
         *
         */
        public MainWindow()
        {
            InitializeComponent();
            Burgers.Visibility = Visibility.Hidden;
            Desserts.Visibility = Visibility.Hidden;
            Sides.Visibility = Visibility.Hidden;
            Drinks.Visibility = Visibility.Hidden;

        }

        private void Burgers_Click(object sender, RoutedEventArgs e)
        {

            MainMenu.Visibility = Visibility.Hidden;
            Burgers.Visibility = Visibility.Visible;

        }

        private void Desserts_Click(object sender, RoutedEventArgs e)
        {

            MainMenu.Visibility = Visibility.Hidden;
            Desserts.Visibility = Visibility.Visible;

        }

        private void Sides_Click(object sender, RoutedEventArgs e)
        {

            MainMenu.Visibility = Visibility.Hidden;
            Sides.Visibility = Visibility.Visible;

        }

        private void Drinks_Click(object sender, RoutedEventArgs e)
        {

            MainMenu.Visibility = Visibility.Hidden;
            Drinks.Visibility = Visibility.Visible;

        }

    }

}
