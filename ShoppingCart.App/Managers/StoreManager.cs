using ShoppingCart.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.App.Managers
{
    /// <summary>
    /// Simulation of a database
    /// </summary>
    public class StoreManager
    {
        private readonly List<Product> products;
        private readonly List<OfferVoucher> offers;
        private readonly List<GiftVoucher> gifts;

        public StoreManager()
        {
            products = new List<Product>();
            offers = new List<OfferVoucher>();
            gifts = new List<GiftVoucher>();

            InitStore();
        }

        /// <summary>
        /// Used to add base data
        /// </summary>
        private void InitStore()
        {
            products.Add(new Product("Hat 1", 10.50m, Category.Hats));
            products.Add(new Product("Hat 2", 25.00m, Category.Hats));
            products.Add(new Product("Head Light", 3.50m, Category.HeadGear));
            products.Add(new Product("Jumper 1", 54.65m, Category.Clothes));
            products.Add(new Product("Jumper 2", 26.00m, Category.Clothes));
            products.Add(new Product("£30 Gift Voucher", 30.00m, Category.Gift));

            offers.Add(new OfferVoucher(100001, 5.00m, 50.00m, Category.HeadGear));
            offers.Add(new OfferVoucher(100001, 5.00m, 50.00m, null));
            gifts.Add(new GiftVoucher(100321, 5.00m));
        }

        #region Getters
        public Product GetProduct(int index)
        {
            return products.Any() ? products[index] : null;
        }

        public OfferVoucher GetOffer(int index)
        {
            return offers.Any() ? offers[index] : null;
        }

        public GiftVoucher GetGift(int index)
        {
            return gifts.Any() ? gifts[index] : null;
        }
        #endregion Getters
    }
}
