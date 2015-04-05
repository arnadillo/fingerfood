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
    /// Interaction logic for BurgersList.xaml
    /// </summary>
    public partial class BurgersList : Page
    {

        DrinksList drinksList = new DrinksList();

        public BurgersList()
        {
            InitializeComponent();
        }

        private void Simple_Simon_Clicked(object sender, RoutedEventArgs e)
        {
            CustomerCart customerCart = new CustomerCart();
            
            Current_Cost.Content = "Current Total : $" + customerCart.currentTotal.ToString();
            //this.NavigationService.Navigate(drinksList);

        }

    }

}
