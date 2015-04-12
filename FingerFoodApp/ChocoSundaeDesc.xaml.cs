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
            string[] customStrings = new string[] { "\tAdd Peanuts", "\tAdd Cherry", "\tExtra Chocolate", "\tAdd Chocolate Shavings"};

            currentOrderList[3].Add("\u2022 Choco Sundae");
            TextBlock orderOutput = new TextBlock();
            orderOutput.FontWeight = FontWeights.Bold;
            orderOutput.Text = currentOrderList[3][0].ToString();
            ((FirstWindow)System.Windows.Application.Current.MainWindow).Receipt.Children.Add(orderOutput);

            for (int i = 0; i < 4; i++)
            {
                if (verifyChecked[i] == true)
                {
                    currentOrderList[3].Add(customStrings[i]);
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

            decimal GST = CurrentTotal * 0.05m;
            GST = Math.Round(GST, 2);

            decimal ActualTotal = CurrentTotal + GST;
            ActualTotal = Math.Round(ActualTotal, 2);

            ((FirstWindow)System.Windows.Application.Current.MainWindow).gstBox.Text = "+GST (5%): $" + GST;
            ((FirstWindow)System.Windows.Application.Current.MainWindow).totalBox.Text = "TOTAL: $" + ActualTotal;

        }
    }
}
