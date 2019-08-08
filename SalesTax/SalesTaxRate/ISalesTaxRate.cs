using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public interface ISalesTaxRate
    {
        decimal GetBasicSalesTaxRate();
        decimal GetImportDutySalesTaxRate();
    }
}