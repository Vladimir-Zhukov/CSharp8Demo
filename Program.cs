using System;

namespace CSharp8Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*IShoppingCart*/ BetterShoppingCart cart = new BetterShoppingCart();
            //cart.CalculateSubTotal();

            //ShoppingCart cart2 = new ShoppingCart();
            //cart2.CalculateSubTotal();

            IndicesAndRagesDemo.Do();
        }
    }
}
