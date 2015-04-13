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
    /// Interaction logic for choco_sundae.xaml
    /// </summary>
    public partial class ChocoSundaeDesc : Page
    {
        public ChocoSundaeDesc()
        {
            InitializeComponent();

            int isMenu = (int)Application.Current.Properties["counter"];
            isMenu++;
            Application.Current.Properties["counter"] = isMenu;
        }

        private void Add_To_Order_Click(object sender, RoutedEventArgs e)
        {
            decimal CurrentTotal = (decimal)Application.Current.Properties["CurrentTotal"];
            CurrentTotal += 2.49m;
            CurrentTotal = Math.Round(CurrentTotal, 2);

            List<List<string>> currentOrderList = (List<List<string>>)Application.Current.Properties["orderList"];
            currentOrderList[3].Clear();

            // Customization Check for Chocolate Sundae
            bool addPeanuts = add_Peanuts.IsChecked.Value;
            bool addMarashinoCherry = add_Marashino_Cherry.IsChecked.Value;
            bool addExtraChocolate = add_Extra_Chocolate.IsChecked.Value;
            bool addChocolateShavings = add_Chocolate_Shavings.IsChecked.Value;

            bool[] verifyChecked = new bool[] {addPeanuts, addMarashinoCherry, addExtraChocolate, addChocolateShavings};
            string[] customStrings = new string[] { "\n\tAdd Peanuts", "\n\tAdd Cherry", "\n\tExtra Chocolate", "\n\tAdd Chocolate Shavings"};

            Button remove_button = new Button();
            remove_button.Content = "Remove";
            remove_button.Click += Remove_Click;
            remove_button.Width = 50;
            remove_button.Background = Brushes.Red;

            currentOrderList[3].Add("\n\u2022 Choco Sundae\t\t\t\t $2.49");

            TextBlock orderOutput = new TextBlock();
            orderOutput.FontWeight = FontWeights.Bold;
            orderOutput.Text = currentOrderList[3][0].ToString();

            for (int i = 0; i < 4; i++)
            {
                if (verifyChecked[i] == true)
                {
                    currentOrderList[3].Add(customStrings[i]);

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

            decimal GST = CurrentTotal * 0.05m;
            GST = Math.Round(GST, 2);

            decimal ActualTotal = CurrentTotal + GST;
            ActualTotal = Math.Round(ActualTotal, 2);

            ((FirstWindow)System.Windows.Application.Current.MainWindow).gstBox.Text = "+GST (5%): $" + GST;
            ((FirstWindow)System.Windows.Application.Current.MainWindow).totalBox.Text = "TOTAL: $" + ActualTotal;

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
    }
}
