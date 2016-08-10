using ShoppingCart.App.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.App.Models
{
    public class GiftVoucher : Voucher
    {
        public GiftVoucher(int reference, decimal value)
            : base(reference, value)
        {

        }

        public override string PrintInfo()
        {
            return $"1 x £{Value} Gift Voucher {PrintHelpers.PrintReference(Reference)} applied";
        }
    }
}
