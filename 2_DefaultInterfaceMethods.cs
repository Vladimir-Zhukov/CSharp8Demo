using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8Demo
{
    // https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/default-interface-methods-versions
    // вся соль этих методов в том, чтобы добавлять их пост фактум, когда вашим интерфейсом уже пользуются
    public interface IShoppingCart
    {
        /*
        public static void SetDefaultName(string name)
        {
            defaultName = name;
        }
        public static string defaultName = "default";
        */

        void CalculateTotal();
        void CalculateSubTotal()
        {
            Console.Write("Default CalculateSubTotal");
        }
    }

    public interface IBetterShoppingCart : IShoppingCart
    {
        void CalculateSubTotal()
        {
            Console.Write("Better CalculateSubTotal");
        }
    }

    public class ShoppingCart : IShoppingCart, IBetterShoppingCart
    {
        public void CalculateTotal()
        {
            Console.Write("CalculateTotal");
        }
    }

    public class BetterShoppingCart : IShoppingCart
    {
        public BetterShoppingCart()
        {
            //IShoppingCart.SetDefaultName("new name");
        }

        public void CalculateSubTotal()
        {
            Console.Write("Better CalculateSubTotal");
        }

        public void CalculateTotal()
        {
            Console.Write("Better CalculateTotal");
        }
    }
}
