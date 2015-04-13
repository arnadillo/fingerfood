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
    /// Interaction logic for PopMcgeeDesc.xaml
    /// </summary>
    public partial class PopMcgeeDesc : Page
    {
        public PopMcgeeDesc()
        {
            InitializeComponent();

            int isMenu = (int)Application.Current.Properties["counter"];
            isMenu++;
            Application.Current.Properties["counter"] = isMenu;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            TextBlock popname = new TextBlock();
            popname.Text = "PopMcGee";
            popname.FontWeight = FontWeights.ExtraBlack;
            ((FirstWindow)System.Windows.Application.Current.MainWindow).Receipt.Items.Add(popname);

            decimal CurrentTotal = (decimal)Application.Current.Properties["CurrentTotal"];
            if (small.IsChecked == true)
                CurrentTotal += 1.49m;
            else if (medium.IsChecked == true)
            {
                CurrentTotal += 1.99m;

                TextBlock mediumtext = new TextBlock();
                mediumtext.Text = "\tMedium";

                ((FirstWindow)System.Windows.Application.Current.MainWindow).Receipt.Items.Add(mediumtext);
            }
            else if (large.IsChecked == true)
                CurrentTotal += 2.49m;

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
