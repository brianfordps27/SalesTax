using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalesTax.UnitTests
{
    [TestClass]
    public class TotalSalesTaxCalculatorTests
    {
        [TestMethod]
        public void GetSalesTaxAmount_ItemIsExemptAndNotImported_ReturnZero()
        {
            // Arrange
            var salesTaxRate = new SalesTaxRate();
            var totalSalesTaxCalculator = new TotalSalesTaxCalculator(new List<SalesTaxCalculator> {
                new BasicSalesTaxCalculator(salesTaxRate),
                new ImportDutySalesTaxCalculator(salesTaxRate)});

            var item = new ShoppingBasketItem(new Product("Candy", ProductType.Candy), 16.00m, false, totalSalesTaxCalculator);

            // Act
            var result = totalSalesTaxCalculator.GetSalesTaxAmount(item);

            // Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void GetSalesTaxAmount_ItemIsExemptAndImported_ReturnImportTax()
        {
            // Arrange
            var salesTaxRate = new SalesTaxRate();
            var totalSalesTaxCalculator = new TotalSalesTaxCalculator(new List<SalesTaxCalculator> {
                new BasicSalesTaxCalculator(salesTaxRate),
                new ImportDutySalesTaxCalculator(salesTaxRate)});

            var item = new ShoppingBasketItem(new Product("Candy", ProductType.Candy), 75.99m, true, totalSalesTaxCalculator);

            // Act
            var result = totalSalesTaxCalculator.GetSalesTaxAmount(item);

            // Assert
            Assert.AreEqual(result, 3.80m);
        }

        [TestMethod]
        public void GetSalesTaxAmount_ItemIsTaxedAndNotImported_ReturnBasicTax()
        {
            // Arrange
            var salesTaxRate = new SalesTaxRate();
            var totalSalesTaxCalculator = new TotalSalesTaxCalculator(new List<SalesTaxCalculator> {
                new BasicSalesTaxCalculator(salesTaxRate),
                new ImportDutySalesTaxCalculator(salesTaxRate)});

            var item = new ShoppingBasketItem(new Product("Other", ProductType.Other), 55.00m, false, totalSalesTaxCalculator);

            // Act
            var result = totalSalesTaxCalculator.GetSalesTaxAmount(item);

            // Assert
            Assert.AreEqual(result, 5.50m);
        }

        [TestMethod]
        public void GetSalesTaxAmount_ItemIsTaxedAndImported_ReturnBasicAndImportTax()
        {
            // Arrange
            var salesTaxRate = new SalesTaxRate();
            var totalSalesTaxCalculator = new TotalSalesTaxCalculator(new List<SalesTaxCalculator> {
                new BasicSalesTaxCalculator(salesTaxRate),
                new ImportDutySalesTaxCalculator(salesTaxRate)});

            var item = new ShoppingBasketItem(new Product("Other", ProductType.Other), 15001.25m, true, totalSalesTaxCalculator);

            // Act
            var result = totalSalesTaxCalculator.GetSalesTaxAmount(item);

            // Assert
            Assert.AreEqual(result, 2250.25m);
        }

        [TestMethod]
        public void GetPriceWithTaxIncluded_ItemIsExemptAndNotImported_ReturnPrice()
        {
            // Arrange
            var salesTaxRate = new SalesTaxRate();
            var totalSalesTaxCalculator = new TotalSalesTaxCalculator(new List<SalesTaxCalculator> {
                new BasicSalesTaxCalculator(salesTaxRate),
                new ImportDutySalesTaxCalculator(salesTaxRate)});

            var item = new ShoppingBasketItem(new Product("Candy", ProductType.Candy), 16.00m, false, totalSalesTaxCalculator);

            // Act
            var result = totalSalesTaxCalculator.GetPriceWithTaxIncluded(item);

            // Assert
            Assert.AreEqual(result, 16.00m);
        }

        [TestMethod]
        public void GetPriceWithTaxIncluded_ItemIsExemptAndImported_ReturnPriceWithImportTax()
        {
            // Arrange
            var salesTaxRate = new SalesTaxRate();
            var totalSalesTaxCalculator = new TotalSalesTaxCalculator(new List<SalesTaxCalculator> {
                new BasicSalesTaxCalculator(salesTaxRate),
                new ImportDutySalesTaxCalculator(salesTaxRate)});

            var item = new ShoppingBasketItem(new Product("Candy", ProductType.Candy), 75.99m, true, totalSalesTaxCalculator);

            // Act
            var result = totalSalesTaxCalculator.GetPriceWithTaxIncluded(item);

            // Assert
            Assert.AreEqual(result, 79.79m);
        }

        [TestMethod]
        public void GetPriceWithTaxIncluded_ItemIsTaxedAndNotImported_ReturnPriceWithBasicTax()
        {
            // Arrange
            var salesTaxRate = new SalesTaxRate();
            var totalSalesTaxCalculator = new TotalSalesTaxCalculator(new List<SalesTaxCalculator> {
                new BasicSalesTaxCalculator(salesTaxRate),
                new ImportDutySalesTaxCalculator(salesTaxRate)});

            var item = new ShoppingBasketItem(new Product("Other", ProductType.Other), 55.00m, false, totalSalesTaxCalculator);

            // Act
            var result = totalSalesTaxCalculator.GetPriceWithTaxIncluded(item);

            // Assert
            Assert.AreEqual(result, 60.50m);
        }

        [TestMethod]
        public void GetPriceWithTaxIncluded_ItemIsTaxedAndImported_ReturnPriceWithBasicAndImportTax()
        {
            // Arrange
            var salesTaxRate = new SalesTaxRate();
            var totalSalesTaxCalculator = new TotalSalesTaxCalculator(new List<SalesTaxCalculator> {
                new BasicSalesTaxCalculator(salesTaxRate),
                new ImportDutySalesTaxCalculator(salesTaxRate)});

            var item = new ShoppingBasketItem(new Product("Other", ProductType.Other), 15001.25m, true, totalSalesTaxCalculator);

            // Act
            var result = totalSalesTaxCalculator.GetPriceWithTaxIncluded(item);

            // Assert
            Assert.AreEqual(result, 17251.50m);
        }
    }
}
