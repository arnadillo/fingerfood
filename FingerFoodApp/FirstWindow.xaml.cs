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
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace FingerFoodApp
{
    /// <summary>
    /// Interaction logic for FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        bool viewTotalFlag = false;
        public FirstWindow()
        {
            InitializeComponent();
            MainMenu testPage = new MainMenu();
            // Hiding Back and Menu buttons from main menu
            navHeader.Visibility = Visibility.Hidden;

            // Setting the default content for main window
            //navFrame.Navigate(new Uri("MainMenu.xaml", UriKind.Relative));
            navFrame.Content = testPage;

            decimal current = Math.Round(0.00m, 2);
            decimal gst = Math.Round(0.00m,2);
            decimal actual = Math.Round(0.00m,2);
            List<List<string>> orderList = new List<List<string>>();

            Application.Current.Properties["CurrentTotal"] = current;
            Application.Current.Properties["isList"] = false;
            Application.Current.Properties["orderList"] = orderList;

            int pageCounter = 0;
            Application.Current.Properties["counter"] = pageCounter;

            // Index 0 : Ordered Burgers
            orderList.Add(new List<string>());

            // Index 1 : Ordered Sides
            orderList.Add(new List<string>());

            // Index 2 : Ordered Drinks
            orderList.Add(new List<string>());

            // Index 3 : Ordered Desserts
            orderList.Add(new List<string>());

            //orderList[0].Add("No cheese");
            //orderList[0].Add("No Bacon");

            //this.getBackButton.Visibility = Visibility.Visible;
            decimal CurrentTotal = (decimal)Application.Current.Properties["CurrentTotal"];
            Current_Cost.Content = "Current Total: $" + CurrentTotal.ToString();

            gstBox.Text = "+GST (5%): $0.00";

            totalBox.Text = "TOTAL: $0.00";


            
        }

        public Button getBackButton { get { return Back_Button; } }
        

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            
        }


        private void Back_Clicked(object sender, RoutedEventArgs e)
        {

            int isMenu = (int)Application.Current.Properties["counter"];
            
            if (isMenu == 1)
            {
                navFrame.GoBack();
                navHeader.Visibility = Visibility.Hidden;
                isMenu--;
                Application.Current.Properties["counter"] = isMenu;
            }
            else if (navFrame.CanGoBack == true)
            {
                navFrame.GoBack();
                isMenu--;
                Application.Current.Properties["counter"] = isMenu;
            }

            
        }

        private void Menu_Clicked(object sender, RoutedEventArgs e)
        {
            while (navFrame.CanGoBack == true)
            {
                navFrame.GoBack();
                navHeader.Visibility = Visibility.Hidden;
                Application.Current.Properties["counter"] = 0;
            }
        }

        private void Current_Cost_Click(object sender, RoutedEventArgs e)
        {
            if (!viewTotalFlag)
            {
                Storyboard viewTotalSB = (Storyboard)FindResource("viewTotal");
                viewTotalSB.Begin(this);
                viewTotalFlag = true;
                
            }
            else {
                Storyboard viewTotalSB = (Storyboard)FindResource("viewTotal_rev");
                viewTotalSB.Begin(this);
                viewTotalFlag = false;          
                
            }
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            decimal CurrentTotal = (decimal)Application.Current.Properties["CurrentTotal"];
            if (CurrentTotal == 0)
            {
                MessageBox.Show("Please order items before sending!");
            }
            else
            {
                Confirmation.Visibility = Visibility.Visible;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            decimal CurrentTotal = (decimal)Application.Current.Properties["CurrentTotal"];
            CurrentTotal = 0.00m;
            CurrentTotal = Math.Round(CurrentTotal, 2);

            Application.Current.Properties["CurrentTotal"] = CurrentTotal;
            Current_Cost.Content = "Current Total: $" + CurrentTotal.ToString();
            gstBox.Text = "+GST (5%): $0.00";
            totalBox.Text = "TOTAL: $0.00";

            Receipt.Items.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)   //nope button
        {
            Confirmation.Visibility = Visibility.Hidden;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)   //feed me button
        {
            var bc = new BrushConverter();
            ((FirstWindow)System.Windows.Application.Current.MainWindow).Current_Cost.Background = (Brush)bc.ConvertFrom("#FF00AC1F");
            ((FirstWindow)System.Windows.Application.Current.MainWindow).Current_Cost.Content = "Order sent!";
            OrderButton.Visibility = Visibility.Hidden;
            CancelButton.Visibility = Visibility.Hidden;
            Confirmation.Visibility = Visibility.Hidden;
            sentCanvas.Visibility = Visibility.Visible;
        }

    }
}
