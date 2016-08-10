using ShoppingCart.App.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.App.Models
{
    public class OfferVoucher : Voucher, IBasketItem
    {

        public decimal Threshold { get; set; }
        public string Category { get; set; }

        public OfferVoucher(int reference, decimal value, decimal threshold, string category) 
            : base(reference, value)
        {
            Threshold = threshold;
            Category = category;
        }

        public override string PrintInfo()
        {
            return $"1 x £{Value} off {Category} in baskets over £{Threshold} Offer Voucher {PrintHelpers.PrintReference(Reference)} applied";
        }  
    }
}
