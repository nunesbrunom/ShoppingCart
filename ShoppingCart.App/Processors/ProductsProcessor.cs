using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.App.Models;

namespace ShoppingCart.App.Processors
{
    public class ProductsProcessor : Processor
    {
        /// <summary>
        /// Calculates the total price of the products without gifts and offers
        /// </summary>
        /// <param name="basket"></param>
        protected override void Process(Basket basket)
        {
            basket.ProductTotal = 0;
            foreach (var item in basket.Products)
            {
                basket.ProductTotal += item.Price;
            }
        }        
                
    }
}
