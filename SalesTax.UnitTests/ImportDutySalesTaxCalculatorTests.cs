using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalesTax.UnitTests
{
    [TestClass]
    public class ImportDutySalesTaxCalculatorTests
    {
        [TestMethod]
        public void GetSalesTaxAmount_ItemIsImported_ReturnTaxAmt()
        {
            // Arrange
            var salesTaxRate = new SalesTaxRate();
            var importDutySalesTaxCalculator = new ImportDutySalesTaxCalculator(salesTaxRate);
            var item = new ShoppingBasketItem(new Product("Candy", ProductType.Candy), 1, true, importDutySalesTaxCalculator);

            // Act
            var result = importDutySalesTaxCalculator.GetSalesTaxAmount(item);

            // Assert
            Assert.AreNotEqual(result, 0);
        }

        [TestMethod]
        public void GetSalesTaxAmount_ItemIsNotImported_ReturnZero()
        {
            // Arrange
            var salesTaxRate = new SalesTaxRate();
            var importDutySalesTaxCalculator = new ImportDutySalesTaxCalculator(salesTaxRate);
            var item = new ShoppingBasketItem(new Product("Candy", ProductType.Candy), 1, false, importDutySalesTaxCalculator);

            // Act
            var result = importDutySalesTaxCalculator.GetSalesTaxAmount(item);

            // Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void GetPriceWithTaxIncluded_ProductIsNotImported_ReturnPrice()
        {
            // Arrange
            var salesTaxRate = new SalesTaxRate();
            var importDutySalesTaxCalculator = new ImportDutySalesTaxCalculator(salesTaxRate);
            var item = new ShoppingBasketItem(new Product("Coffee", ProductType.Coffee), 11.50m, false, importDutySalesTaxCalculator);

            // Act
            var result = importDutySalesTaxCalculator.GetPriceWithTaxIncluded(item);

            // Assert
            Assert.AreEqual(result, 11.50m);
        }

        [TestMethod]
        public void GetPriceWithTaxIncluded_ProductIsImported_ReturnPriceWithTax()
        {
            // Arrange
            var salesTaxRate = new SalesTaxRate();
            var importDutySalesTaxCalculator = new ImportDutySalesTaxCalculator(salesTaxRate);
            var item = new ShoppingBasketItem(new Product("Coffee", ProductType.Coffee), 11.00m, true, importDutySalesTaxCalculator);

            // Act
            var result = importDutySalesTaxCalculator.GetPriceWithTaxIncluded(item);

            // Assert
            Assert.AreEqual(result, 11.55m);
        }
    }
}
