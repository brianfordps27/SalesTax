using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalesTax.UnitTests
{
    [TestClass]
    public class BasicSalesTaxCalculatorTests
    {
        [TestMethod]
        public void GetSalesTaxAmount_ProductTypeIsOther_ReturnTaxAmt()
        {
            // Arrange
            var salesTaxRate = new SalesTaxRate();
            var basicSalesTaxCalculator = new BasicSalesTaxCalculator(salesTaxRate);
            var item = new ShoppingBasketItem(new Product("Other", ProductType.Other), 1, false, basicSalesTaxCalculator);

            // Act
            var result = basicSalesTaxCalculator.GetSalesTaxAmount(item);

            // Assert
            Assert.AreNotEqual(result, 0);
        }

        [TestMethod]
        public void GetSalesTaxAmount_ProductTypeIsCandy_ReturnZero()
        {
            // Arrange
            var salesTaxRate = new SalesTaxRate();
            var basicSalesTaxCalculator = new BasicSalesTaxCalculator(salesTaxRate);
            var item = new ShoppingBasketItem(new Product("Candy", ProductType.Candy), 1, false, basicSalesTaxCalculator);

            // Act
            var result = basicSalesTaxCalculator.GetSalesTaxAmount(item);
        
            // Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void GetSalesTaxAmount_ProductTypeIsPopcorn_ReturnZero()
        {
            // Arrange
            var salesTaxRate = new SalesTaxRate();
            var basicSalesTaxCalculator = new BasicSalesTaxCalculator(salesTaxRate);
            var item = new ShoppingBasketItem(new Product("Popcorn", ProductType.Popcorn), 1, false, basicSalesTaxCalculator);

            // Act
            var result = basicSalesTaxCalculator.GetSalesTaxAmount(item);

            // Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void GetSalesTaxAmount_ProductTypeIsCoffee_ReturnZero()
        {
            // Arrange
            var salesTaxRate = new SalesTaxRate();
            var basicSalesTaxCalculator = new BasicSalesTaxCalculator(salesTaxRate);
            var item = new ShoppingBasketItem(new Product("Coffee", ProductType.Coffee), 1, false, basicSalesTaxCalculator);

            // Act
            var result = basicSalesTaxCalculator.GetSalesTaxAmount(item);

            // Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void GetPriceWithTaxIncluded_ProductIsExempt_ReturnPrice()
        {
            // Arrange
            var salesTaxRate = new SalesTaxRate();
            var basicSalesTaxCalculator = new BasicSalesTaxCalculator(salesTaxRate);
            var item = new ShoppingBasketItem(new Product("Coffee", ProductType.Coffee), 11.50m, false, basicSalesTaxCalculator);

            // Act
            var result = basicSalesTaxCalculator.GetPriceWithTaxIncluded(item);

            // Assert
            Assert.AreEqual(result, 11.50m);
        }

        [TestMethod]
        public void GetPriceWithTaxIncluded_ProductIsTaxed_ReturnPriceWithTax()
        {
            // Arrange
            var salesTaxRate = new SalesTaxRate();
            var basicSalesTaxCalculator = new BasicSalesTaxCalculator(salesTaxRate);
            var item = new ShoppingBasketItem(new Product("Other", ProductType.Other), 99.99m, false, basicSalesTaxCalculator);

            // Act
            var result = basicSalesTaxCalculator.GetPriceWithTaxIncluded(item);

            // Assert
            Assert.AreEqual(result, 109.99m);
        }
    }
}
