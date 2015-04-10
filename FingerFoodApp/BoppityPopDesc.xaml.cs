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
    /// Interaction logic for BoppityPopDesc.xaml
    /// </summary>
    public partial class BoppityPopDesc : Page
    {
        public BoppityPopDesc()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            float CurrentTotal = (float)Application.Current.Properties["CurrentTotal"];
            if (small.IsChecked == true)
                CurrentTotal += 1.50f;
            else if (medium.IsChecked == true)
                CurrentTotal += 2.00f;
            else if (large.IsChecked == true)
                CurrentTotal += 2.50f;
            Application.Current.Properties["CurrentTotal"] = CurrentTotal;
            ((FirstWindow)System.Windows.Application.Current.MainWindow).Current_Cost.Content = "Current Total: $" + CurrentTotal.ToString();
        }
    }
}
