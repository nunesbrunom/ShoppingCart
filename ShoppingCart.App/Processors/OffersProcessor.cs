using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.App.Models;
using ShoppingCart.App.Helpers;

namespace ShoppingCart.App.Processors
{
    public class OffersProcessor : Processor
    {
        /// <summary>
        /// Verifies if the voucher is appliable to the current products
        /// Verifies if the voucher is valid to the current total value (without gifts)
        /// Calculates the total offer value
        /// </summary>
        /// <param name="basket"></param>
        protected override void Process(Basket basket)
        {
            if (!ValidateProducts(basket))
            {
                basket.Messages.Add($"There are no products in your basket to redeem your offer voucher.");
                return;
            }
            basket.OfferTotal = 0;
            foreach (var item in basket.Offers)
            {
                if (!ValidateCategory(basket, item))
                {
                    basket.Messages.Add($"There are no products in your basket applicable to voucher Voucher {PrintHelpers.PrintReference(item.Reference)}.");
                }
                else if (!ValidateThreshold(basket, item))
                {
                    var thresholdEligibleTotal = basket.Products.Where(x => x.Category != Category.Gift).Sum(x => x.Price);
                    basket.Messages.Add($"You have not reached the spend threshold for voucher {PrintHelpers.PrintReference(item.Reference)}. Spend another £{(item.Threshold - thresholdEligibleTotal + 0.01m)} to receive £{item.Value} discount from your basket total.");
                }
                else
                {
                    var baseQuery = GetBaseQuery(basket, item);
                    if (item.Category != null)
                        baseQuery = baseQuery.Where(x => x.Category == item.Category);
                    var eligbleTotal = baseQuery.Sum(x => x.Price);
                    basket.OfferTotal += eligbleTotal >= item.Value ? item.Value : eligbleTotal;
                }

            }
        }

        public virtual bool ValidateCategory(Basket basket, OfferVoucher voucher)
        {
            var baseQuery = GetBaseQuery(basket, voucher);
            if (voucher.Category != null)
                baseQuery = baseQuery.Where(x => x.Category == voucher.Category);
            return baseQuery.Any();
        }

        public virtual bool ValidateThreshold(Basket basket, OfferVoucher voucher)
        {
            return basket.Products.Where(x => x.Category != Category.Gift).Sum(x => x.Price) > voucher.Threshold;
        }

        private IQueryable<Product> GetBaseQuery(Basket basket, OfferVoucher voucher)
        {
            var baseQuery = basket.Products.Where(x => x.Category != Category.Gift);
            if (voucher.Category != null)
                baseQuery = baseQuery.Where(x => x.Category == voucher.Category);
            return baseQuery.AsQueryable();
        }

        public virtual bool ValidateProducts(Basket basket)
        {
            return basket.Products.Any();
        }
    }
}
