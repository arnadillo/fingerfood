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

        Boolean mealBool = false;
        public FriesDesc()
        {
            InitializeComponent();

            int isMenu = (int)Application.Current.Properties["counter"];
            isMenu++;
            Application.Current.Properties["counter"] = isMenu;
        }

        public FriesDesc(Boolean meal)
        {
            InitializeComponent();

            int isMenu = (int)Application.Current.Properties["counter"];
            isMenu++;
            Application.Current.Properties["counter"] = isMenu;

            mealBool = meal;
        }

        private void Add_To_Order_Clicked(object sender, RoutedEventArgs e)
        {
            if (mealBool == false)
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
                string[] customStrings = new string[] { "\n\tAdd Ketchup", "\n\tAdd Mayo", "\n\tExtra Salt", "\n\tAdd Pepper", "\n\tAdd Parmesan Cheese" };

                Button remove_button = new Button();
                remove_button.Content = "Remove";
                remove_button.Click += Remove_Click;
                remove_button.Width = 50;
                remove_button.Background = Brushes.Red;

                currentOrderList[1].Add("\n\u2022 Fries\t\t\t\t\t $1.99");

                TextBlock orderOutput = new TextBlock();
                orderOutput.FontWeight = FontWeights.Bold;
                orderOutput.Text = currentOrderList[1][0].ToString();


                for (int i = 0; i < 5; i++)
                {
                    if (verifyChecked[i] == true)
                    {
                        currentOrderList[1].Add(customStrings[i]);

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

                Application.Current.Properties["CurrentTotal"] = CurrentTotal;
                ((FirstWindow)System.Windows.Application.Current.MainWindow).Current_Cost.Content = "My Total: $" + CurrentTotal.ToString();

                decimal GST = CurrentTotal * 0.15m;
                GST = Math.Round(GST, 2);

                decimal ActualTotal = CurrentTotal + GST;
                ActualTotal = Math.Round(ActualTotal, 2);

                ((FirstWindow)System.Windows.Application.Current.MainWindow).gstBox.Text = "+GST (5%): $" + GST;
                ((FirstWindow)System.Windows.Application.Current.MainWindow).totalBox.Text = "TOTAL: $" + ActualTotal;
            }
            else if(mealBool == true)
            {
                bool addKetchup = add_Ketchup.IsChecked.Value;
                bool addMayo = add_Mayo.IsChecked.Value;
                bool addSalt = add_Salt.IsChecked.Value;
                bool addPepper = add_Pepper.IsChecked.Value;
                bool addParmesanCheese = add_Parmesan_Cheese.IsChecked.Value;

                bool[] verifyChecked = new bool[] { addKetchup, addMayo, addSalt, addPepper, addParmesanCheese };
                string[] customStrings = new string[] { "\n\tAdd Ketchup", "\n\tAdd Mayo", "\n\tExtra Salt", "\n\tAdd Pepper", "\n\tAdd Parmesan Cheese" };

                decimal mealTotal = (decimal)Application.Current.Properties["mealTotal"];
                mealTotal += 1.99m;
                Application.Current.Properties["mealTotal"] = mealTotal;

                Application.Current.Properties["completeMeal"] += "\n\u2022 Fries\t\t\t\t\t $1.99";

                bool[] verifyChecked1 = new bool[] { addKetchup, addMayo, addSalt, addPepper, addParmesanCheese };
                string[] customStrings1 = new string[] { "\n\tAdd Ketchup", "\n\tAdd Mayo", "\n\tExtra Salt", "\n\tAdd Pepper", "\n\tAdd Parmesan Cheese" };

                for (int i = 0; i < 5; i++)
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

                this.NavigationService.Navigate(new DrinksList(mealBool));

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
            CurrentTotal -= 1.99m;
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
