using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    abstract public class SalesTaxCalculator
    {
        public abstract decimal GetSalesTaxAmount(ShoppingBasketItem item);

        public decimal GetPriceWithTaxIncluded(ShoppingBasketItem item)
        {
            return item.BasePrice + GetSalesTaxAmount(item);
        }

        public decimal RoundUp(decimal amount)
        {
            //round up to the nearest .05 (1/20)
            return Math.Ceiling(amount * 20) / 20;
        }
    }
}
