using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.App.Models
{
    public class Product : IBasketItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public Product()
        {
        }

        public Product(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;            
        }


        public string PrintInfo()
        {
            return $"1 {Name} @ £{Price}";
        }
    }
}
