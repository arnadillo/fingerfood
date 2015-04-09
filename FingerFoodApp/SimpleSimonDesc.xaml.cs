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

        private double price;
        private double displayTotal;
        CustomerCart total;

        public SimpleSimonDesc()
        {
            InitializeComponent();
        }

        public SimpleSimonDesc(CustomerCart tots)
        {
            InitializeComponent();
            displayTotal = tots.getTotal();
            total = new CustomerCart(displayTotal);
            Current_Cost_SimpleSimon.Content = "Current total = $" + displayTotal.ToString();
        }

        private void Add_To_Order_Click(object sender, RoutedEventArgs e)
        {
            //price = Convert.ToDouble(Simple_Simon_Price);
            total.addTotal(1.99);
            Current_Cost_SimpleSimon.Content = "Current total = $" + total.getTotal().ToString();
        }


    }
}
