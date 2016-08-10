using ShoppingCart.App.Helpers;
using ShoppingCart.App.Managers;
using ShoppingCart.App.Models;
using ShoppingCart.App.Processors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.App
{
    class Program
    {
        static Basket basket;
        static BasketManager basketManager;
        static StoreManager store;

        static void Main(string[] args)
        {
            basket = new Basket();
            basketManager = new BasketManager();
            store = new StoreManager();

            PrintHelpers.IsConsoleOutput = true;

            Basket1();
            ContinuePrompt();

            Basket2();
            ContinuePrompt();

            Basket3();
            ContinuePrompt();
            
            Basket4();
            ContinuePrompt();
            
            Basket5();
            ContinuePrompt();
        }     
        
        private static void ContinuePrompt()
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        private static void Basket1()
        {
            PrintHelpers.WriteLine("Basket 1");
            basket = new Basket();
            basketManager.AddProduct(basket, store.GetProduct(0)); //Hat € 10.50
            basketManager.AddProduct(basket, store.GetProduct(3)); //Jumper € 54.65

            basketManager.AddGift(basket, store.GetGift(0)); // € 5.00 gift

            basketManager.Finish(basket);
        }

        private static void Basket2()
        {
            PrintHelpers.WriteLine("Basket 2");
            basket = new Basket();
            basketManager.AddProduct(basket, store.GetProduct(1)); //Hat £ 25.00
            basketManager.AddProduct(basket, store.GetProduct(4)); //Jumper £2 6.00

            basketManager.AddOffer(basket, store.GetOffer(0)); // € 5.00 offer on Head Gear

            basketManager.Finish(basket);
        }

        private static void Basket3()
        {
            PrintHelpers.WriteLine("Basket 3");
            basket = new Basket();
            basketManager.AddProduct(basket, store.GetProduct(1)); //Hat £ 25.00
            basketManager.AddProduct(basket, store.GetProduct(4)); //Jumper £ 26.00
            basketManager.AddProduct(basket, store.GetProduct(2)); //Head Light £ 3.50

            basketManager.AddOffer(basket, store.GetOffer(0)); // € 5.00 offer on Head Gear

            basketManager.Finish(basket);
        }

        private static void Basket4()
        {
            PrintHelpers.WriteLine("Basket 4");
            basket = new Basket();
            basketManager.AddProduct(basket, store.GetProduct(1)); //Hat £ 25.00
            basketManager.AddProduct(basket, store.GetProduct(4)); //Jumper £26.00

            basketManager.AddGift(basket, store.GetGift(0)); // £5.00 Gift Voucher 
            basketManager.AddOffer(basket, store.GetOffer(1)); // £5.00 off baskets over £50.00

            basketManager.Finish(basket);
        }

       
        private static void Basket5()
        {
            PrintHelpers.WriteLine("Basket 5");
            basket = new Basket();
            basketManager.AddProduct(basket, store.GetProduct(1)); //Hat £ 25.00
            basketManager.AddProduct(basket, store.GetProduct(5)); //£30 Gift Voucher 

            basketManager.AddOffer(basket, store.GetOffer(1)); // £5.00 off baskets over £50.00

            basketManager.Finish(basket);
        }
    }
}
