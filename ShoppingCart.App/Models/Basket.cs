using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.App.Models
{
    public class Basket
    {
        public List<Product> Products { get; set; }
        public List<OfferVoucher> Offers { get; set; }
        public List<GiftVoucher> Gifts { get; set; }
        public List<string> Messages { get; set; }
        public decimal ProductTotal { get; set; }
        public decimal GiftTotal { get; set; }
        public decimal OfferTotal { get; set; }
        public decimal Total { get; set; }

        public Basket()
        {
            Products = new List<Product>();
            Offers = new List<OfferVoucher>();
            Gifts = new List<GiftVoucher>();
            Messages = new List<string>();
        }
    }
}
