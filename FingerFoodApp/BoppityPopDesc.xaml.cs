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

            int isMenu = (int)Application.Current.Properties["counter"];
            isMenu++;
            Application.Current.Properties["counter"] = isMenu;
 
        }

        private void Add_To_Order_Click(object sender, RoutedEventArgs e)
        {
            decimal CurrentTotal = (decimal)Application.Current.Properties["CurrentTotal"];
            if (small.IsChecked == true)
                CurrentTotal += 1.49m;
            else if (medium.IsChecked == true)
                CurrentTotal += 1.99m;
            else if (large.IsChecked == true)
                CurrentTotal += 2.49m;

            List<List<string>> currentOrderList = (List<List<string>>)Application.Current.Properties["orderList"];
            currentOrderList[2].Clear();

            bool smallDrink = small.IsChecked.Value;
            bool mediumDrink = medium.IsChecked.Value;
            bool largeDrink = large.IsChecked.Value;
            bool noIce = Ice.IsChecked.Value;

            bool[] verifyChecked = new bool[] { smallDrink, mediumDrink, largeDrink, !noIce };
            string[] customStrings = new string[] { "\tSmall Sized", "\tMedium Sized", "\tLarge Sized", "\tNo Ice" };

            if (small.IsChecked == true)
                currentOrderList[2].Add("\n\u2022 Boppity Pop\t\t\t\t\t $1.49");
            else if (medium.IsChecked == true)
                currentOrderList[2].Add("\n\u2022 Boppity Pop\t\t\t\t\t $1.99");
            else if (large.IsChecked == true)
                currentOrderList[2].Add("\n\u2022 Boppity Pop\t\t\t\t\t $2.49");

            TextBlock orderOutput = new TextBlock();
            orderOutput.FontWeight = FontWeights.Bold;
            orderOutput.Text = currentOrderList[2][0].ToString();
            ((FirstWindow)System.Windows.Application.Current.MainWindow).Receipt.Children.Add(orderOutput);

            for (int i = 0; i < 4; i++)
            {
                if (verifyChecked[i] == true)
                {
                    currentOrderList[2].Add(customStrings[i]);
                    TextBlock customOutput = new TextBlock();
                    customOutput.Text = customStrings[i];
                    ((FirstWindow)System.Windows.Application.Current.MainWindow).Receipt.Children.Add(customOutput);
                    Application.Current.Properties["orderList"] = currentOrderList;

                }

                else
                {
                    continue;
                }
            }

            CurrentTotal = Math.Round(CurrentTotal, 2);

            Application.Current.Properties["CurrentTotal"] = CurrentTotal;
            ((FirstWindow)System.Windows.Application.Current.MainWindow).Current_Cost.Content = "Current Total: $" + CurrentTotal.ToString();

            decimal GST = CurrentTotal * 0.05m;
            GST = Math.Round(GST, 2);

            decimal ActualTotal = CurrentTotal + GST;
            ActualTotal = Math.Round(ActualTotal, 2);

            ((FirstWindow)System.Windows.Application.Current.MainWindow).gstBox.Text = "+GST (5%): $" + GST;
            ((FirstWindow)System.Windows.Application.Current.MainWindow).totalBox.Text = "TOTAL: $" + ActualTotal;

        }
    }
}
