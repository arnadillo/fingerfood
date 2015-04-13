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
        Boolean mealBool = false;
        public BoppityPopDesc()
        {
            InitializeComponent();

            int isMenu = (int)Application.Current.Properties["counter"];
            isMenu++;
            Application.Current.Properties["counter"] = isMenu;

        }

        public BoppityPopDesc(Boolean meal)
        {
            InitializeComponent();

            int isMenu = (int)Application.Current.Properties["counter"];
            isMenu++;
            Application.Current.Properties["counter"] = isMenu;

            mealBool = meal;
        }

        private void Add_To_Order_Click(object sender, RoutedEventArgs e)
        {
            if (mealBool == false)
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
                string[] customStrings = new string[] { "\n\tSmall Sized", "\n\tMedium Sized", "\n\tLarge Sized", "\n\tNo Ice" };


                Button remove_button = new Button();
                remove_button.Content = "Remove";
                remove_button.Click += Remove_Click;
                remove_button.Width = 50;
                remove_button.Background = Brushes.Red;


                if (small.IsChecked == true)
                    currentOrderList[2].Add("\n\u2022 Boppity Pop\t\t\t\t $1.49");
                else if (medium.IsChecked == true)
                    currentOrderList[2].Add("\n\u2022 Boppity Pop\t\t\t\t $1.99");
                else if (large.IsChecked == true)
                    currentOrderList[2].Add("\n\u2022 Boppity Pop\t\t\t\t $2.49");

                TextBlock orderOutput = new TextBlock();
                orderOutput.FontWeight = FontWeights.Bold;
                orderOutput.Text = currentOrderList[2][0].ToString();


                for (int i = 0; i < 4; i++)
                {
                    if (verifyChecked[i] == true)
                    {
                        currentOrderList[2].Add(customStrings[i]);

                        orderOutput.Text += customStrings[i];

                        Application.Current.Properties["orderList"] = currentOrderList;

                    }

                    else
                    {
                        continue;
                    }
                }

                orderOutput.Text += "\n\n\t\t\t\t\t";
                orderOutput.Inlines.Add(remove_button);
                ((FirstWindow)System.Windows.Application.Current.MainWindow).Receipt.Items.Add(orderOutput);

                CurrentTotal = Math.Round(CurrentTotal, 2);

                Application.Current.Properties["CurrentTotal"] = CurrentTotal;
                ((FirstWindow)System.Windows.Application.Current.MainWindow).Current_Cost.Content = "My Total: $" + CurrentTotal.ToString();

                decimal GST = CurrentTotal * 0.05m;
                GST = Math.Round(GST, 2);

                decimal ActualTotal = CurrentTotal + GST;
                ActualTotal = Math.Round(ActualTotal, 2);

                ((FirstWindow)System.Windows.Application.Current.MainWindow).gstBox.Text = "+GST (5%): $" + GST;
                ((FirstWindow)System.Windows.Application.Current.MainWindow).totalBox.Text = "TOTAL: $" + ActualTotal;
            }
            else if (mealBool == true)
            {
                bool smallDrink = small.IsChecked.Value;
                bool mediumDrink = medium.IsChecked.Value;
                bool largeDrink = large.IsChecked.Value;
                bool noIce = Ice.IsChecked.Value;

                bool[] verifyChecked1 = new bool[] { smallDrink, mediumDrink, largeDrink, !noIce };
                string[] customStrings1 = new string[] { "\n\tSmall Sized", "\n\tMedium Sized", "\n\tLarge Sized", "\n\tNo Ice" };

                decimal mealTotal = (decimal)Application.Current.Properties["mealTotal"];
                if (small.IsChecked == true)
                {
                    mealTotal += 1.49m;
                    Application.Current.Properties["completeMeal"] += "\n\u2022 Boppity Pop\t\t\t\t $1.49";
                }
                else if (medium.IsChecked == true)
                {
                    mealTotal += 1.99m;
                    Application.Current.Properties["completeMeal"] += "\n\u2022 Boppity Pop\t\t\t\t $1.99";
                }
                else if (large.IsChecked == true)
                {
                    mealTotal += 2.49m;
                    Application.Current.Properties["completeMeal"] += "\n\u2022 Boppity Pop\t\t\t\t $1.49";
                }
                Application.Current.Properties["mealTotal"] = mealTotal;

                for (int i = 0; i < 4; i++)
                {
                    if (verifyChecked1[i] == true)
                    {


                        Application.Current.Properties["completeMeal"] += customStrings1[i];

                    }

                    else
                    {
                        continue;
                    }
                }

                Button remove_button = new Button();
                remove_button.Content = "Remove";
                remove_button.Click += Remove_Click_Meal;
                remove_button.Width = 50;
                remove_button.Background = Brushes.Red;

                TextBlock orderOutput = new TextBlock();
                orderOutput.FontWeight = FontWeights.Bold;

                String complete = (String)Application.Current.Properties["completeMeal"];

                orderOutput.Text = complete;

                Decimal discount = mealTotal * 0.15m;
                discount = Math.Round(discount, 2);
                orderOutput.Text += "\n\t\t\t\t15% off -$" + discount.ToString();

                orderOutput.Text += "\n\n\t\t\t\t\t";
                orderOutput.Inlines.Add(remove_button);
                ((FirstWindow)System.Windows.Application.Current.MainWindow).Receipt.Items.Add(orderOutput);

                mealTotal = mealTotal * 0.85m;
                Application.Current.Properties["mealTotal"] = mealTotal;

                decimal CurrentTotal = (decimal)Application.Current.Properties["CurrentTotal"];
                CurrentTotal += mealTotal;
                CurrentTotal = Math.Round(CurrentTotal, 2);

                Application.Current.Properties["CurrentTotal"] = CurrentTotal;

                ((FirstWindow)System.Windows.Application.Current.MainWindow).Current_Cost.Content = "My Total: $" + CurrentTotal.ToString();

                decimal GST = CurrentTotal * 0.05m;
                GST = Math.Round(GST, 2);

                decimal ActualTotal = CurrentTotal + GST;
                ActualTotal = Math.Round(ActualTotal, 2);

                ((FirstWindow)System.Windows.Application.Current.MainWindow).gstBox.Text = "+GST (5%): $" + GST;
                ((FirstWindow)System.Windows.Application.Current.MainWindow).totalBox.Text = "TOTAL: $" + ActualTotal;

                mealBool = false;

                
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            int i = ((FirstWindow)System.Windows.Application.Current.MainWindow).Receipt.Items.IndexOf(((FirstWindow)System.Windows.Application.Current.MainWindow).Receipt.SelectedItem);
            if (i > -1)
            {
                ((FirstWindow)System.Windows.Application.Current.MainWindow).Receipt.Items.RemoveAt(i);
            }
            else
                MessageBox.Show("Please select an item first.");

            decimal CurrentTotal = (decimal)Application.Current.Properties["CurrentTotal"];
            if (small.IsChecked == true)
                CurrentTotal -= 1.49m;
            else if (medium.IsChecked == true)
                CurrentTotal -= 1.99m;
            else if (large.IsChecked == true)
                CurrentTotal -= 2.49m;
            CurrentTotal = Math.Round(CurrentTotal, 2);

            Application.Current.Properties["CurrentTotal"] = CurrentTotal;
            ((FirstWindow)System.Windows.Application.Current.MainWindow).Current_Cost.Content = "My Total: $" + CurrentTotal.ToString();

            decimal GST = CurrentTotal * 0.05m;
            GST = Math.Round(GST, 2);

            decimal ActualTotal = CurrentTotal + GST;
            ActualTotal = Math.Round(ActualTotal, 2);

            ((FirstWindow)System.Windows.Application.Current.MainWindow).gstBox.Text = "+GST (5%): $" + GST;
            ((FirstWindow)System.Windows.Application.Current.MainWindow).totalBox.Text = "TOTAL: $" + ActualTotal;

        }

        private void Remove_Click_Meal(object sender, RoutedEventArgs e)
        {
            int i = ((FirstWindow)System.Windows.Application.Current.MainWindow).Receipt.Items.IndexOf(((FirstWindow)System.Windows.Application.Current.MainWindow).Receipt.SelectedItem);
            if (i > -1)
            {
                ((FirstWindow)System.Windows.Application.Current.MainWindow).Receipt.Items.RemoveAt(i);
            }
            else
                MessageBox.Show("Please select an item first.");

            decimal CurrentTotal = (decimal)Application.Current.Properties["CurrentTotal"];
            decimal mealTotal = (decimal)Application.Current.Properties["mealTotal"];
            CurrentTotal -= mealTotal;

            CurrentTotal = Math.Round(CurrentTotal, 2);

            Application.Current.Properties["CurrentTotal"] = CurrentTotal;
            ((FirstWindow)System.Windows.Application.Current.MainWindow).Current_Cost.Content = "My Total: $" + CurrentTotal.ToString();

            decimal GST = CurrentTotal * 0.05m;
            GST = Math.Round(GST, 2);

            decimal ActualTotal = CurrentTotal + GST;
            ActualTotal = Math.Round(ActualTotal, 2);

            ((FirstWindow)System.Windows.Application.Current.MainWindow).gstBox.Text = "+GST (5%): $" + GST;
            ((FirstWindow)System.Windows.Application.Current.MainWindow).totalBox.Text = "TOTAL: $" + ActualTotal;
        }
    }
}