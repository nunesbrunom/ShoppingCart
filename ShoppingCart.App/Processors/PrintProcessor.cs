using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.App.Models;
using System.Diagnostics;

namespace ShoppingCart.App.Processors
{
    public class PrintProcessor : Processor
    {
        /// <summary>
        /// Outputs the bill to the debug console
        /// </summary>
        /// <param name="basket"></param>
        protected override void Process(Basket basket)
        {
            
            foreach (var item in basket.Products)
            {
                PrintItemInfo(item);
            }

            if (basket.Gifts.Any())
                PrintTerminator();

            foreach (var item in basket.Gifts)
            {
                PrintItemInfo(item);
            }

            if (basket.Offers.Any())
                PrintTerminator();

            foreach (var item in basket.Offers)
            {
                PrintItemInfo(item);                
            }

            PrintTerminator();
            Trace.WriteLine($"Total: £{basket.Total}");

            if (basket.Messages.Any())
            {
                PrintTerminator();
                foreach (var item in basket.Messages)
                {
                   Trace.WriteLine($"Message: {item}");
                }
            }
        }
    }
}
