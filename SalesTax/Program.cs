using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    class Program
    {
        private static SalesTaxRate salesTaxRate = new SalesTaxRate();
        private static TotalSalesTaxCalculator _totalSalesTaxCalculator;

        static void Main(string[] args)
        {
            _totalSalesTaxCalculator = new TotalSalesTaxCalculator(new List<SalesTaxCalculator> {
                new BasicSalesTaxCalculator(salesTaxRate),
                new ImportDutySalesTaxCalculator(salesTaxRate)});

            PrintReceipt1();
            PrintReceipt2();
            PrintReceipt3();

            Console.ReadKey();
        }

        private static void PrintReceipt1()
        {
            var shoppingBasket = new ShoppingBasket();

            shoppingBasket.Add(new ShoppingBasketItem(new Product("1 16lb bag of Skittles", ProductType.Candy), 16.00m, false, _totalSalesTaxCalculator));
            shoppingBasket.Add(new ShoppingBasketItem(new Product("1 Walkman", ProductType.Other), 99.99m, false, _totalSalesTaxCalculator));
            shoppingBasket.Add(new ShoppingBasketItem(new Product("1 bag of microwave Popcorn", ProductType.Popcorn), 0.99m, false, _totalSalesTaxCalculator));

            Console.WriteLine("Output 1:");
            Console.WriteLine(shoppingBasket.PrintReceipt());
        }

        private static void PrintReceipt2()
        {
            var shoppingBasket = new ShoppingBasket();

            shoppingBasket.Add(new ShoppingBasketItem(new Product("1 imported box of Vanilla-Hazelnut Coffee", ProductType.Coffee), 11.00m, true, _totalSalesTaxCalculator));
            shoppingBasket.Add(new ShoppingBasketItem(new Product("1 imported Vespa", ProductType.Other), 15001.25m, true, _totalSalesTaxCalculator));

            Console.WriteLine("Output 2:");
            Console.WriteLine(shoppingBasket.PrintReceipt());
        }

        private static void PrintReceipt3()
        {
            var shoppingBasket = new ShoppingBasket();

            shoppingBasket.Add(new ShoppingBasketItem(new Product("1 imported crate of Almond Snickers", ProductType.Candy), 75.99m, true, _totalSalesTaxCalculator));
            shoppingBasket.Add(new ShoppingBasketItem(new Product("1 Discman", ProductType.Other), 55.00m, false, _totalSalesTaxCalculator));
            shoppingBasket.Add(new ShoppingBasketItem(new Product("1 imported Bottle of Wine", ProductType.Other), 10.00m, true, _totalSalesTaxCalculator));
            shoppingBasket.Add(new ShoppingBasketItem(new Product("1 300# bag of Fair-Trade Coffee", ProductType.Coffee), 997.99m, false, _totalSalesTaxCalculator));

            Console.WriteLine("Output 3:");
            Console.WriteLine(shoppingBasket.PrintReceipt());
        }
    }
}
