using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.App.Models;
using ShoppingCart.App.Helpers;

namespace ShoppingCart.App.Processors
{
    public class BillProcessor : Processor
    {
        /// <summary>
        /// Calculates the final value
        /// </summary>
        /// <param name="basket"></param>
        protected override void Process(Basket basket)
        {
            basket.Total = 0;
            basket.Total = basket.ProductTotal - basket.GiftTotal - basket.OfferTotal;
            basket.Total = basket.Total < 0 ? 0 : basket.Total;
        }
    }
}
