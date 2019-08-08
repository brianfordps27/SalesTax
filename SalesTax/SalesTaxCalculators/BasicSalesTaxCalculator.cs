using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public class BasicSalesTaxCalculator : SalesTaxCalculator
    {
        //product types candy, popcorn, and coffee are exempt from basic sales tax
        public const ProductType ExemptProductTypes = (ProductType.Candy | 
                                                       ProductType.Popcorn | 
                                                       ProductType.Coffee);
        private readonly ISalesTaxRate _salesTaxRate;

        public BasicSalesTaxCalculator(ISalesTaxRate salesTaxRate)
        {
            _salesTaxRate = salesTaxRate;
        }

        public override decimal GetSalesTaxAmount(ShoppingBasketItem item)
        {
            if (ExemptProductTypes.HasFlag(item.Product.Type))
            {
                //product is exempt from basic sales tax
                return 0.0m;
            }

            return RoundUp(item.BasePrice * _salesTaxRate.GetBasicSalesTaxRate());
        }
    }
}
