﻿using System;
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
        //CustomerCart total;

       // FirstWindow update = new FirstWindow();

        public SimpleSimonDesc()
        {
            InitializeComponent();
            Application.Current.Properties["isList"] = false;
        }

        private void Add_To_Order_Click(object sender, RoutedEventArgs e)
        {
            float CurrentTotal = (float)Application.Current.Properties["CurrentTotal"];
            CurrentTotal += 1.99f;
            Application.Current.Properties["CurrentTotal"] = CurrentTotal;
            ((FirstWindow)System.Windows.Application.Current.MainWindow).Current_Cost.Content = "Current Total: $" + CurrentTotal.ToString();
        }


    }
}
