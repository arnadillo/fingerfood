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
    /// Interaction logic for FriesDesc.xaml
    /// </summary>
    public partial class FriesDesc : Page
    {
        public FriesDesc()
        {
            InitializeComponent();

            int isMenu = (int)Application.Current.Properties["counter"];
            isMenu++;
            Application.Current.Properties["counter"] = isMenu;
        }

        private void Add_To_Order_Clicked(object sender, RoutedEventArgs e)
        {
            decimal CurrentTotal = (decimal)Application.Current.Properties["CurrentTotal"];
            CurrentTotal += 1.99m;
            CurrentTotal = Math.Round(CurrentTotal, 2);

            List<List<string>> currentOrderList = (List<List<string>>)Application.Current.Properties["orderList"];
            currentOrderList[1].Clear();

            bool addKetchup = add_Ketchup.IsChecked.Value;
            bool addMayo = add_Mayo.IsChecked.Value;
            bool addSalt = add_Salt.IsChecked.Value;
            bool addPepper = add_Pepper.IsChecked.Value;
            bool addParmesanCheese = add_Parmesan_Cheese.IsChecked.Value;

            bool[] verifyChecked = new bool[] { addKetchup, addMayo, addSalt, addPepper, addParmesanCheese };
            string[] customStrings = new string[] { "\tAdd Ketchup", "\tAdd Mayo", "\tExtra Salt", "\tAdd Pepper", "\tAdd Parmesan Cheese" };

            currentOrderList[1].Add("\u2022 Fries");
            TextBlock orderOutput = new TextBlock();
            orderOutput.FontWeight = FontWeights.Bold;
            orderOutput.Text = currentOrderList[1][0].ToString();
            ((FirstWindow)System.Windows.Application.Current.MainWindow).Receipt.Children.Add(orderOutput);

            for (int i = 0; i < 5; i++)
            {
                if (verifyChecked[i] == true)
                {
                    currentOrderList[1].Add(customStrings[i]);
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

            Application.Current.Properties["CurrentTotal"] = CurrentTotal;
            ((FirstWindow)System.Windows.Application.Current.MainWindow).Current_Cost.Content = "Current Total: $" + CurrentTotal.ToString();

            decimal GST = CurrentTotal * 0.15m;
            GST = Math.Round(GST, 2);

            decimal ActualTotal = CurrentTotal + GST;
            ActualTotal = Math.Round(ActualTotal, 2);

            ((FirstWindow)System.Windows.Application.Current.MainWindow).gstBox.Text = "+GST (5%): $" + GST;
            ((FirstWindow)System.Windows.Application.Current.MainWindow).totalBox.Text = "TOTAL: $" + ActualTotal;

        }
    }
}
