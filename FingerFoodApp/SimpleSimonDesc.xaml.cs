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
            string[] customStrings = new string[] { "\n\tAdd Cheese", "\n\tAdd Ketchup", "\n\tAdd Mayo", "\n\tAdd Mustard", "\n\tAdd Relish", "\n\tAdd Bacon", "\n\tAdd Lettuce", "\n\tAdd Tomatoes" };

            Button remove_button = new Button();
            remove_button.Content = "Remove";
            remove_button.Click += Remove_Click;
            remove_button.Width = 50;
            remove_button.Background = Brushes.Red;

            currentOrderList[0].Add("\n\u2022 Simple Simon\t\t\t\t $1.99");
            TextBlock orderOutput = new TextBlock();
            orderOutput.FontWeight = FontWeights.Bold;
            orderOutput.Text = currentOrderList[0][0].ToString();

            //((FirstWindow)System.Windows.Application.Current.MainWindow).Receipt.Items.Add(orderOutput);

            TextBlock customOutput = new TextBlock();
            for (int i = 0; i < 8; i++)
            {
                if (verifyChecked[i] == true)
                {
                    currentOrderList[0].Add(customStrings[i]);

                    orderOutput.Text += customStrings[i];
                    //((FirstWindow)System.Windows.Application.Current.MainWindow).Receipt.Items.Add(customOutput);
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

            decimal GST = CurrentTotal * 0.05m;
            GST = Math.Round(GST, 2);

            decimal ActualTotal = CurrentTotal + GST;
            ActualTotal = Math.Round(ActualTotal, 2);

            ((FirstWindow)System.Windows.Application.Current.MainWindow).gstBox.Text = "+GST (5%): $" + GST;
            ((FirstWindow)System.Windows.Application.Current.MainWindow).totalBox.Text = "TOTAL: $" + ActualTotal;


        }

        private void MakeAMeal_Click(object sender, RoutedEventArgs e)
        {
            TextBlock testbox = new TextBlock();
            Button remove = new Button();
            remove.Content = "x";
            remove.Click += Remove_Click;
            remove.Height = 20;
            remove.Width = 15;



            ((FirstWindow)System.Windows.Application.Current.MainWindow).Receipt.Items.Add(remove);
            //((FirstWindow)System.Windows.Application.Current.MainWindow).Receipt.Children.Add(remove);

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