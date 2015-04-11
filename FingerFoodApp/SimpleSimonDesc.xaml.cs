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

        //CustomerCart total;

       // FirstWindow update = new FirstWindow();

        public SimpleSimonDesc()
        {
            InitializeComponent();
            Application.Current.Properties["isList"] = false;
        }

        private void Add_To_Order_Click(object sender, RoutedEventArgs e)
        {
            decimal CurrentTotal = (decimal)Application.Current.Properties["CurrentTotal"];
            CurrentTotal += 1.99m;
            CurrentTotal = Math.Round(CurrentTotal, 2);

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

            List<List<string>> currentOrderList = (List<List<string>>)Application.Current.Properties["orderList"];
            if (addCheddarCheese && addKetchup)
            {
                currentOrderList[0].Add("Add Cheese");
                currentOrderList[0].Add("Add Ketchup");
                Application.Current.Properties["orderList"] = currentOrderList;

                //MessageBox.Show("Add cheese");
            }

            else if (addKetchup){
                currentOrderList[0].Add("Add Ketchup");
                Application.Current.Properties["orderList"] = currentOrderList;
                //MessageBox.Show("Add Ketchup");
            }


            else if (addCheddarCheese){
                currentOrderList[0].Add("Add Cheese");
                Application.Current.Properties["orderList"] = currentOrderList;
            }


            else
            {
                currentOrderList[0].Clear();
                Application.Current.Properties["orderList"] = currentOrderList;
                //MessageBox.Show("I don't know");
            }


            //List<List<string>> currentOrderList = (List<List<string>>)Application.Current.Properties["orderList"];

            //for (int i = 0; i < 2; i++ )
            //{
            //    MessageBox.Show(currentOrderList[0][i].ToString());
            //}
            if (currentOrderList[0].Count == 0)
            {
                MessageBox.Show("No Customizations");
            }

            else
            {
                MessageBox.Show(currentOrderList[0][0].ToString());
            }
        }


    }
}
