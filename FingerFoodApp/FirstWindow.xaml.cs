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
    /// Interaction logic for FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        public FirstWindow()
        {
            InitializeComponent();

            // Hiding Back and Menu buttons from main menu
            

            // Setting the default content for main window
            navFrame.Navigate(new Uri("MainMenu.xaml", UriKind.Relative));
            
           

        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            //navHeader.Visibility = Visibility.Hidden;
        }


        private void Back_Clicked(object sender, RoutedEventArgs e)
        {
            if (navFrame.CanGoBack == true)
            {
                navFrame.GoBack();
            }
        }

        private void Menu_Clicked(object sender, RoutedEventArgs e)
        {
            // Need to tweak this with the Customer's current total
            navFrame.Navigate(new Uri("MainMenu.xaml", UriKind.Relative));
        }

        
    }
}
