using ShoppingCart.App.Models;
using ShoppingCart.App.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.App.Managers
{
    /// <summary>
    /// Simulation of a shopping system
    /// </summary>
    public class BasketManager
    {
        private readonly ProductsProcessor _productsProcessor;
        private readonly OffersProcessor _offersProcessor;
        private readonly GiftsProcessor _giftsProcessor;
        private readonly BillProcessor _billProcessor;
        private readonly PrintProcessor _printProcessor;

        public BasketManager()
        {
            _productsProcessor = new ProductsProcessor();
            _offersProcessor = new OffersProcessor();
            _giftsProcessor = new GiftsProcessor();
            _billProcessor = new BillProcessor();
            _printProcessor = new PrintProcessor();
            _productsProcessor.SetSucessor(_offersProcessor);
            _offersProcessor.SetSucessor(_giftsProcessor);
            _giftsProcessor.SetSucessor(_billProcessor);
        }

        #region Product
        public virtual void AddProduct(Basket basket, Product item)
        {
            basket.Products.Add(item);
            _productsProcessor.Execute(basket);
        }

        public virtual void RemoveProduct(Basket basket, Product item)
        {
            basket.Products.Remove(item);
            _productsProcessor.Execute(basket);
        }
        #endregion Product
        #region Gift
        public virtual void AddGift(Basket basket, GiftVoucher item)
        {
            basket.Gifts.Add(item);
            _giftsProcessor.Execute(basket);
        }

        public virtual void RemoveGift(Basket basket, GiftVoucher item)
        {
            basket.Gifts.Remove(item);
            _giftsProcessor.Execute(basket);
        }
        #endregion Gift
        #region Offer
        public virtual void AddOffer(Basket basket, OfferVoucher item)
        {
            basket.Offers.Add(item);
            _offersProcessor.Execute(basket);
        }

        public virtual void RemoveOffer(Basket basket, OfferVoucher item)
        {
            basket.Offers.Remove(item);
            _offersProcessor.Execute(basket);
        }
        #endregion Offer

        /// <summary>
        /// Finish shopping cart and print the bill
        /// </summary>
        /// <param name="basket"></param>
        public virtual void Finish(Basket basket)
        {
            _printProcessor.Execute(basket);
        }
    }
}
