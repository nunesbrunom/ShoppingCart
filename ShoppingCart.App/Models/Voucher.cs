using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.App.Models
{
    public abstract class Voucher : IBasketItem
    {
        public decimal Value { get; set; }
        public int Reference { get; set; }

        public Voucher()
        {
        }

        public Voucher(int reference, decimal value)
        {
            Reference = reference;
            Value = value;
        }

        public abstract string PrintInfo();
    }
}
