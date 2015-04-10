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

        double totalDisplay;
        
        DrinksList drinksList = new DrinksList();
        SimpleSimonDesc simpleSimon = new SimpleSimonDesc();
        BangkokSandwichDesc bangkokMeat = new BangkokSandwichDesc();
        CamelBurgerDesc bactrianCamel = new CamelBurgerDesc();
        InvertedBurgerDesc invertedBurger = new InvertedBurgerDesc();
        meatPrismDesc meatPrism = new meatPrismDesc();
        WhoopityDesc whoopity = new WhoopityDesc();
        MountAngusDesc mountAngus = new MountAngusDesc();

        CustomerCart total;


        public BurgersList()
        {
            InitializeComponent();
            ((FirstWindow)System.Windows.Application.Current.MainWindow).navHeader.Visibility = Visibility.Visible;
        }

        public BurgersList(CustomerCart tots)
        {
            InitializeComponent();
            
            totalDisplay = tots.getTotal();
            total = new CustomerCart(totalDisplay);
            Current_Cost.Content = "Current Total: $" + totalDisplay.ToString();
            
        }

        private void Simple_Simon_Clicked(object sender, RoutedEventArgs e)
        {
            //CustomerCart customerCart = new CustomerCart();
            //Window parentWindow = Window.GetWindow(this);
            //object obj = parentWindow.FindName("Back_Button");
            
            
            //Current_Cost.Content = "Current Total : $" + customerCart.currentTotal.ToString();
            this.NavigationService.Navigate(simpleSimon);

        }

        private void bangkok_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(bangkokMeat);
        }

        private void Bactrian_Camel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(bactrianCamel);
        }

        private void Inverted_Burger_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(invertedBurger);
        }

        private void Meat_Prism_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(meatPrism);
        }

        private void Whoopity_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(whoopity);
        }

        private void Mount_Angus_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(mountAngus);
        }



    }

}
