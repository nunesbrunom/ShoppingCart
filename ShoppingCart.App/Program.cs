using ShoppingCart.App.Managers;
using ShoppingCart.App.Models;
using ShoppingCart.App.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.App
{
    class Program
    {

        static void Main(string[] args)
        {
            Basket basket = new Basket();
            BasketManager basketManager = new BasketManager();

            var store = new StoreManager();

            basketManager.AddProduct(basket, store.GetProduct(0));
            basketManager.AddProduct(basket, store.GetProduct(2));
            basketManager.AddProduct(basket, store.GetProduct(1));

            basketManager.AddOffer(basket, store.GetOffer(0));
            basketManager.AddGift(basket, store.GetGift(0));

            Console.ReadLine();
        }
    }
}
