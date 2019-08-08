using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public class Product
    {
        public string Name { get; private set; }
        public ProductType Type { get; private set; }
        
        public Product(string name, ProductType type)
        {
            Name = name;
            Type = type;
        }
    }

    public enum ProductType
    {
        Candy = 1,
        Popcorn = 2,
        Coffee = 4,
        Other = 8
    }
}
