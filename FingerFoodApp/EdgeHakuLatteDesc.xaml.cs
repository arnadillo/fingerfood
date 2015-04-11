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
    /// Interaction logic for EdgeHakuLatteDesc.xaml
    /// </summary>
    public partial class EdgeHakuLatteDesc : Page
    {
        public EdgeHakuLatteDesc()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal CurrentTotal = (decimal)Application.Current.Properties["CurrentTotal"];
            if (small.IsChecked == true)
                CurrentTotal += 3.49m;
            else if (medium.IsChecked == true)
                CurrentTotal += 5.99m;
            else if (large.IsChecked == true)
                CurrentTotal += 7.49m;

            CurrentTotal = Math.Round(CurrentTotal, 2);

            Application.Current.Properties["CurrentTotal"] = CurrentTotal;
            ((FirstWindow)System.Windows.Application.Current.MainWindow).Current_Cost.Content = "Current Total: $" + CurrentTotal.ToString();
        }
    }
}
