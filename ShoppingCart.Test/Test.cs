using System;
using Xunit;
using ShoppingCart.App.Managers;
using ShoppingCart.App.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace ShoppingCart.Tests
{
    public class Test
    {
        private readonly Basket basket;
        private readonly BasketManager basketManager;
        private readonly StoreManager store;

        public Test()
        {
            basket = new Basket();
            basketManager = new BasketManager();
            store = new StoreManager();
        }

        [Fact]
        public void Basket1_ShouldFinishWithoutMessages()
        {
            Trace.WriteLine("Basket 1");
            basketManager.AddProduct(basket, store.GetProduct(0)); //Hat € 10.50
            basketManager.AddProduct(basket, store.GetProduct(3)); //Jumper € 54.65

            basketManager.AddGift(basket, store.GetGift(0)); // € 5.00 gift

            basketManager.Finish(basket);


            Assert.Equal(60.15m, basket.Total);
            Assert.Equal(0, basket.Messages.Count);
        }

        [Fact]
        public void Basket2_ShouldFinishWithNoProductsAppliableMessage()
        {
            Trace.WriteLine("Basket 2");
            basketManager.AddProduct(basket, store.GetProduct(1)); //Hat £ 25.00
            basketManager.AddProduct(basket, store.GetProduct(4)); //Jumper £2 6.00

            basketManager.AddOffer(basket, store.GetOffer(0)); // € 5.00 offer on Head Gear

            basketManager.Finish(basket);


            Assert.Equal(51.00m, basket.Total);
            Assert.Equal(1, basket.Messages.Count);
            Assert.Contains("no products", basket.Messages[0]);
        }

        [Fact]
        public void Basket3_ShouldFinishWithoutMessages()
        {
            Trace.WriteLine("Basket 3");
            basketManager.AddProduct(basket, store.GetProduct(1)); //Hat £ 25.00
            basketManager.AddProduct(basket, store.GetProduct(4)); //Jumper £ 26.00
            basketManager.AddProduct(basket, store.GetProduct(2)); //Head Light £ 3.50

            basketManager.AddOffer(basket, store.GetOffer(0)); // € 5.00 offer on Head Gear

            basketManager.Finish(basket);


            Assert.Equal(51.00m, basket.Total);
            Assert.Equal(0, basket.Messages.Count);
        }

        [Fact]
        public void Basket4_ShouldFinishWithoutMessages()
        {
            Trace.WriteLine("Basket 4");
            basketManager.AddProduct(basket, store.GetProduct(1)); //Hat £ 25.00
            basketManager.AddProduct(basket, store.GetProduct(4)); //Jumper £26.00

            basketManager.AddGift(basket, store.GetGift(0)); // £5.00 Gift Voucher 
            basketManager.AddOffer(basket, store.GetOffer(1)); // £5.00 off baskets over £50.00

            basketManager.Finish(basket);

            Assert.Equal(41.00m, basket.Total);
            Assert.Equal(0, basket.Messages.Count);
        }

        [Fact]
        public void Basket5_ShouldFinishWithThresholdMessages()
        {
            Trace.WriteLine("Basket 5");
            basketManager.AddProduct(basket, store.GetProduct(1)); //Hat £ 25.00
            basketManager.AddProduct(basket, store.GetProduct(5)); //£30 Gift Voucher 

            basketManager.AddOffer(basket, store.GetOffer(1)); // £5.00 off baskets over £50.00

            basketManager.Finish(basket);

            Assert.Equal(55.00m, basket.Total);
            Assert.Equal(1, basket.Messages.Count);
            Assert.Contains((25.01m).ToString(), basket.Messages[0]);
        }
    }
}
