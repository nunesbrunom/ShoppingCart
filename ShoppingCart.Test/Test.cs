using System;
using Xunit;
using ShoppingCart.App.Managers;
using ShoppingCart.App.Models;
using System.Collections.Generic;
using System.Diagnostics;
using ShoppingCart.App.Helpers;

namespace ShoppingCart.Tests
{
    public class Test
    {
        private readonly Basket _basket;
        private readonly BasketManager _basketManager;
        private readonly StoreManager _store;

        public Test()
        {
            _basket = new Basket();
            _basketManager = new BasketManager();
            _store = new StoreManager();
        }

        [Fact]
        public void Basket1_ShouldFinishWithoutMessages()
        {
            PrintHelpers.WriteLine("Basket 1");
            _basketManager.AddProduct(_basket, _store.GetProduct(0)); //Hat € 10.50
            _basketManager.AddProduct(_basket, _store.GetProduct(3)); //Jumper € 54.65

            _basketManager.AddGift(_basket, _store.GetGift(0)); // € 5.00 gift

            _basketManager.Finish(_basket);


            Assert.Equal(60.15m, _basket.Total);
            Assert.Equal(0, _basket.Messages.Count);
        }

        [Fact]
        public void Basket2_ShouldFinishWithNoProductsAppliableMessage()
        {
            PrintHelpers.WriteLine("Basket 2");
            _basketManager.AddProduct(_basket, _store.GetProduct(1)); //Hat £ 25.00
            _basketManager.AddProduct(_basket, _store.GetProduct(4)); //Jumper £2 6.00

            _basketManager.AddOffer(_basket, _store.GetOffer(0)); // € 5.00 offer on Head Gear

            _basketManager.Finish(_basket);


            Assert.Equal(51.00m, _basket.Total);
            Assert.Equal(1, _basket.Messages.Count);
            Assert.Contains("no products", _basket.Messages[0]);
        }

        [Fact]
        public void Basket3_ShouldFinishWithoutMessages()
        {
            PrintHelpers.WriteLine("Basket 3");
            _basketManager.AddProduct(_basket, _store.GetProduct(1)); //Hat £ 25.00
            _basketManager.AddProduct(_basket, _store.GetProduct(4)); //Jumper £ 26.00
            _basketManager.AddProduct(_basket, _store.GetProduct(2)); //Head Light £ 3.50

            _basketManager.AddOffer(_basket, _store.GetOffer(0)); // € 5.00 offer on Head Gear

            _basketManager.Finish(_basket);


            Assert.Equal(51.00m, _basket.Total);
            Assert.Equal(0, _basket.Messages.Count);
        }

        [Fact]
        public void Basket4_ShouldFinishWithoutMessages()
        {
            PrintHelpers.WriteLine("Basket 4");
            _basketManager.AddProduct(_basket, _store.GetProduct(1)); //Hat £ 25.00
            _basketManager.AddProduct(_basket, _store.GetProduct(4)); //Jumper £26.00

            _basketManager.AddGift(_basket, _store.GetGift(0)); // £5.00 Gift Voucher 
            _basketManager.AddOffer(_basket, _store.GetOffer(1)); // £5.00 off baskets over £50.00

            _basketManager.Finish(_basket);

            Assert.Equal(41.00m, _basket.Total);
            Assert.Equal(0, _basket.Messages.Count);
        }

        [Fact]
        public void Basket5_ShouldFinishWithThresholdMessages()
        {
            PrintHelpers.WriteLine("Basket 5");
            _basketManager.AddProduct(_basket, _store.GetProduct(1)); //Hat £ 25.00
            _basketManager.AddProduct(_basket, _store.GetProduct(5)); //£30 Gift Voucher 

            _basketManager.AddOffer(_basket, _store.GetOffer(1)); // £5.00 off baskets over £50.00

            _basketManager.Finish(_basket);

            Assert.Equal(55.00m, _basket.Total);
            Assert.Equal(1, _basket.Messages.Count);
            Assert.Contains((25.01m).ToString(), _basket.Messages[0]);
        }
    }
}
