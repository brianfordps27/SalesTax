using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public class SalesTaxRate : ISalesTaxRate
    {
        public decimal GetBasicSalesTaxRate()
        {
            // basic sales tax = 10%
            return 0.1m;
        }

        public decimal GetImportDutySalesTaxRate()
        {
            // import duty sales tax = 5%
            return 0.05m;
        }
    }
}
