using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public class ShoppingBasketItem
    {
        public Product Product { get; private set; }
        public decimal BasePrice { get; private set; }
        public bool IsImported { get; private set; }
        private readonly SalesTaxCalculator _salesTaxCalculator;

        public ShoppingBasketItem(Product product, decimal basePrice, bool isImported, SalesTaxCalculator salesTaxCalculator)
        {
            if (product == null || basePrice < 0 || salesTaxCalculator == null)
            {
                throw new ArgumentException("Shopping Basket Item is invalid");
            }

            Product = product;
            BasePrice = basePrice;
            IsImported = isImported;
            _salesTaxCalculator = salesTaxCalculator;
        }

        public decimal GetItemPrice()
        {
            return _salesTaxCalculator.GetPriceWithTaxIncluded(this);
        }

    }
}
