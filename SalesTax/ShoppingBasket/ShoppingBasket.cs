using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public class ShoppingBasket
    {
        private readonly IList<ShoppingBasketItem> shoppingBasketItems = new List<ShoppingBasketItem>();

        public void Add(ShoppingBasketItem item)
        {
            if (item != null)
            {
                shoppingBasketItems.Add(item);
            }
        }

        public string PrintReceipt()
        {
            var receipt = new StringBuilder();
            var totalPrice = 0.0m;
            var totalBasePrice = shoppingBasketItems.Sum(x => x.BasePrice);

            foreach (var shoppingBasketItem in shoppingBasketItems)
            {
                var price = shoppingBasketItem.GetItemPrice();
                totalPrice += price;
                receipt.AppendLine(String.Format("{0}: {1}", shoppingBasketItem.Product.Name, price.ToString("#,##0.00")));
            }

            receipt.AppendLine(String.Format("Sales Taxes: {0}", (totalPrice - totalBasePrice).ToString("#,##0.00")));
            receipt.AppendLine(String.Format("Total: {0}", totalPrice.ToString("#,##0.00")));

            return receipt.ToString();
        }
    }
}
