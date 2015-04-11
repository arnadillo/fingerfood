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
    /// Interaction logic for OrderScreen.xaml
    /// </summary>
    public partial class OrderScreen : Page
    {
        public OrderScreen()
        {
            InitializeComponent();
            TextBlock penis = new TextBlock();
            penis.Text = "penis";
            orderList.Children.Add(penis);
            TextBlock balls = new TextBlock();
            balls.Text = "balls";
            orderList.Children.Add(balls);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            Confirmation.Visibility = Visibility.Visible;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            decimal CurrentTotal = (decimal)Application.Current.Properties["CurrentTotal"];
            CurrentTotal = 0.00m;
            CurrentTotal = Math.Round(CurrentTotal, 2);

            Application.Current.Properties["CurrentTotal"] = CurrentTotal;
            ((FirstWindow)System.Windows.Application.Current.MainWindow).Current_Cost.Content = "Current Total: $" + CurrentTotal.ToString();
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
