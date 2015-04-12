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
    /// Interaction logic for SimpleSimonDesc.xaml
    /// </summary>
    public partial class SimpleSimonDesc : Page
    {

        public SimpleSimonDesc()
        {
            InitializeComponent();

            int isMenu = (int)Application.Current.Properties["counter"];
            isMenu++;
            Application.Current.Properties["counter"] = isMenu;

        }

        private void Add_To_Order_Click(object sender, RoutedEventArgs e)
        {
            decimal CurrentTotal = (decimal)Application.Current.Properties["CurrentTotal"];
            CurrentTotal += 1.99m;
            CurrentTotal = Math.Round(CurrentTotal, 2);

            List<List<string>> currentOrderList = (List<List<string>>)Application.Current.Properties["orderList"];
            currentOrderList[0].Clear();

            Application.Current.Properties["CurrentTotal"] = CurrentTotal;
            ((FirstWindow)System.Windows.Application.Current.MainWindow).Current_Cost.Content = "Current Total: $" + CurrentTotal.ToString();

            // Customization Check for Simple Simon
            bool addCheddarCheese = add_Cheddar_Cheese.IsChecked.Value;
            bool addKetchup = add_Ketchup.IsChecked.Value;
            bool addMayo = add_Mayo.IsChecked.Value;
            bool addMustard = add_Mustard.IsChecked.Value;
            bool addRelish = add_Relish.IsChecked.Value;
            bool addBacon = add_Bacon.IsChecked.Value;
            bool addLettuce = add_Lettuce.IsChecked.Value;
            bool addTomatoes = add_Tomatoes.IsChecked.Value;

            bool[] verifyChecked = new bool[] { addCheddarCheese, addKetchup, addMayo, addMustard, addRelish, addBacon, addLettuce, addTomatoes };
            string[] customStrings = new string[] { "\tAdd Cheese", "\tAdd Ketchup", "\tAdd Mayo", "\tAdd Mustard", "\tAdd Relish", "\tAdd Bacon", "\tAdd Lettuce", "\tAdd Tomatoes" };

            currentOrderList[0].Add("\u2022 Simple Simon");
            TextBlock orderOutput = new TextBlock();
            orderOutput.FontWeight = FontWeights.Bold;
            orderOutput.Text = currentOrderList[0][0].ToString();
            ((FirstWindow)System.Windows.Application.Current.MainWindow).Receipt.Children.Add(orderOutput);

            for (int i = 0; i < 8; i++)
            {
                if (verifyChecked[i] == true)
                {
                    currentOrderList[0].Add(customStrings[i]);
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

            decimal GST = CurrentTotal * 0.05m;
            GST = Math.Round(GST, 2);

            decimal ActualTotal = CurrentTotal + GST;
            ActualTotal = Math.Round(ActualTotal, 2);

            ((FirstWindow)System.Windows.Application.Current.MainWindow).gstBox.Text = "+GST (5%): $" + GST;
            ((FirstWindow)System.Windows.Application.Current.MainWindow).totalBox.Text = "TOTAL: $" + ActualTotal;


        }


    }
}
