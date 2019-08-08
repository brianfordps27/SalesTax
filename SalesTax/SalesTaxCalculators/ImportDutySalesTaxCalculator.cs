using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public class ImportDutySalesTaxCalculator : SalesTaxCalculator
    {
        private readonly ISalesTaxRate _salesTaxRate;

        public ImportDutySalesTaxCalculator(ISalesTaxRate salesTaxRate)
        {
            _salesTaxRate = salesTaxRate;
        }

        public override decimal GetSalesTaxAmount(ShoppingBasketItem item)
        {
            //if item is imported return price * import tax, else return 0
            return item.IsImported ? RoundUp(item.BasePrice * _salesTaxRate.GetImportDutySalesTaxRate()) : 0.0m;
        }
    }
}
