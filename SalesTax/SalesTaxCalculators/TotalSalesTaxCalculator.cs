using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public class TotalSalesTaxCalculator : SalesTaxCalculator
    {
        private readonly IEnumerable<SalesTaxCalculator> _salesTaxCalculators;

        public TotalSalesTaxCalculator(IEnumerable<SalesTaxCalculator> salesTaxCalculators)
        {
            _salesTaxCalculators = salesTaxCalculators;
        }

        public override decimal GetSalesTaxAmount(ShoppingBasketItem item)
        {
            return  _salesTaxCalculators.Sum(x => x.GetSalesTaxAmount(item));
        }
    }
}
