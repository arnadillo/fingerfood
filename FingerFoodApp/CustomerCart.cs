using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerFoodApp
{
    public class CustomerCart
    {
        //public decimal currentTotal = Math.Round(1.99m, 2);
        private static double currentTotal;

        public CustomerCart()
        {
            currentTotal = 0.00;
        }

        public CustomerCart(double total)
        {
            currentTotal = total;
        }

        public void addTotal(double add)
        {
            currentTotal += add;
        }

        public double getTotal()
        {
            return currentTotal;
        }

    }
}
