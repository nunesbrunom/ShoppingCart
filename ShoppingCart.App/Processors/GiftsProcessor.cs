using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.App.Models;

namespace ShoppingCart.App.Processors
{
    public class GiftsProcessor : Processor
    {
        /// <summary>
        /// Calculates the total gift discount
        /// </summary>
        /// <param name="basket"></param>
        protected override void Process(Basket basket)
        {
            basket.GiftTotal = 0;
            if (!ValidateProducts(basket))
            {
                basket.Messages.Add($"There are no products in your basket to redeem your gift voucher.");
                return;
            }

            foreach (var item in basket.Gifts)
            {
                basket.GiftTotal += item.Value;
            }
        }

        public virtual bool ValidateProducts(Basket basket)
        {
            return basket.Products.Any();
        }
    }
}
