using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce_application;
using NUnit.Framework.Legacy;

namespace Test_Project
{

    [TestFixture]
    public class Test_Class
    {
        private Products product;

        [SetUp]
        public void Setup()
        {
            product = new Products(100, "Test Product", 100, 50);
        }


        /*
        * Created by: Pratham Bhatiya
        * These tests are intended to verify that the `Products` class correctly handles Product ID and Product Name validation.  
        * Each test case ensures that valid values are accepted, invalid values are rejected, and boundary conditions are correctly handled.
        *
        * Test cases:
        * 1. `Constructor_ValidLowerBoundaryProdID_ShouldSetProdID` - Verifies that the Product ID is correctly assigned when set to the minimum valid value (7).
        * 2. `Constructor_ValidUpperBoundaryProdID_ShouldSetProdID` - Verifies that the Product ID is correctly assigned when set to the maximum valid value (70000).
        * 3. `Constructor_InvalidProdIDBelowMinimum_ShouldThrowException` - Ensures that an invalid Product ID (below 7) results in an `ArgumentOutOfRangeException`.
        * 4. `Constructor_InvalidProdIDAboveMaximum_ShouldThrowException` - Ensures that an invalid Product ID (above 70000) results in an `ArgumentOutOfRangeException`.
        * 5. `Constructor_ValidProductName_ShouldSetProdName` - Verifies that a valid, non-empty product name is assigned correctly.
        * 6. `Constructor_EmptyProductName_ShouldSetEmptyProdName` - Ensures that an empty product name is handled correctly based on the system’s expected behavior.
        *
        * These test cases were chosen to cover:
        * - **Validation of required attributes** (Product ID, Product Name).
        * - **Boundary Value Analysis** (minimum and maximum limits).
        * - **Proper error handling** for invalid inputs.
        * - **Edge cases** such as an empty product name.
        */


        [Test]
        public void Constructor_ValidLowerBoundaryProdID_ShouldSetProdID()
        {
            // Arrange
            int validProdID = 7;
            string prodName = "TestProduct";
            decimal itemPrice = 100;
            int stockAmount = 10;

            // Act
            var product = new Products(validProdID, prodName, itemPrice, stockAmount);

            // Assert
            Assert.That(product.ProdID, Is.EqualTo(validProdID));
        }


        [Test]
        public void Constructor_ValidUpperBoundaryProdID_ShouldSetProdID()
        {
            // Arrange
            int validProdID = 70000;
            string prodName = "TestProduct";
            decimal itemPrice = 100;
            int stockAmount = 10;

            // Act
            var product = new Products(validProdID, prodName, itemPrice, stockAmount);

            // Assert
            Assert.That(product.ProdID, Is.EqualTo(validProdID));
        }


        [Test]
        public void Constructor_InvalidProdIDBelowMinimum_ShouldThrowException()
        {
            // Arrange
            int invalidProdID = 6;
            string prodName = "TestProduct";
            decimal itemPrice = 100;
            int stockAmount = 10;

            // Act & Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Products(invalidProdID, prodName, itemPrice, stockAmount));

            Assert.That(ex.ParamName, Is.EqualTo("prodID"));
        }



        [Test]
        public void Constructor_InvalidProdIDAboveMaximum_ShouldThrowException()
        {
            // Arrange
            int invalidProdID = 70001;
            string prodName = "TestProduct";
            decimal itemPrice = 100;
            int stockAmount = 10;

            // Act & Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Products(invalidProdID, prodName, itemPrice, stockAmount));

            Assert.That(ex.ParamName, Is.EqualTo("prodID"));
        }


        [Test]
        public void Constructor_ValidProductName_ShouldSetProdName()
        {
            // Arrange
            int prodID = 1000;
            string validProdName = "Laptop";
            decimal itemPrice = 500;
            int stockAmount = 50;

            // Act
            var product = new Products(prodID, validProdName, itemPrice, stockAmount);

            // Assert
            Assert.That(product.ProdName, Is.EqualTo(validProdName));
        }


        [Test]
        public void Constructor_EmptyProductName_ShouldSetEmptyProdName()
        {
            // Arrange
            int prodID = 1000;
            string emptyProdName = "";
            decimal itemPrice = 500;
            int stockAmount = 50;

            // Act
            var product = new Products(prodID, emptyProdName, itemPrice, stockAmount);

            // Assert
            Assert.That(product.ProdName, Is.EqualTo(emptyProdName));
        }

        /*
        * Tirth Patel 
        * Unit tests for the Products class are included in this test class, with a particular focus on the StockAmount and ItemPrice properties. 
        * The provided tests verify that the class operates as directed by testing both valid and invalid scenarios for these properties.
        * 
        * The tests for StockAmount check:
        * 1.When stock is normal, the product will perform as expected if the StockAmount is appropriately set within a valid range (7000).
        * 2.To make sure the system doesn't accept incorrect input, a problem is raised if the StockAmount goes beyond the allowed range (6).
        * 3.To verify that only actual stock values are allowed, a problem is raised when the StockAmount crosses the maximum permitted range (700001).
        * 
        * The tests for ItemPrice check:
        * 1.The product's price is accepted when it goes within the valid range of 500, provided that the ItemPrice has been correctly calculated within that range.
        * 2.Invalid prices are avoided if an problem is raised when the item price drops outside of the allowed range (6).
        * 3.To make sure the system doesn't allow incorrect price values, a problem is raised when the item price above the maximum allowed price of 7001.
        * 
        * These tests were chosen to ensure that the Product class handles both valid and invalid inputs correctly, ensuring robust error handling and input validation.
        */


        [Test]
        public void StockAmount_ValidRange_ShouldPass()
        {
            // Arrange
            int validProductId = 100;
            string validProductName = "Valid";
            decimal validItemPrice = 10;
            int validStockAmount = 7000;

            // Act
            var product = new Products(validProductId, validProductName, validItemPrice, validStockAmount);

            // Assert
            Assert.That(product.StockAmount, Is.EqualTo(validStockAmount));
        }


        [Test]
        public void StockAmount_BelowRange_ShouldThrowException()
        {
            // Arrange
            int validProductId = 100;
            string validProductName = "Invalid";
            decimal validItemPrice = 10;
            int invalidStockAmount = 6;  // Below minimum valid range

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Products(validProductId, validProductName, validItemPrice, invalidStockAmount));
        }


        [Test]
        public void StockAmount_AboveRange_ShouldThrowException()
        {
            // Arrange
            int validProductId = 100;
            string validProductName = "Invalid";
            decimal validItemPrice = 10;
            int invalidStockAmount = 700001;  // Above maximum valid range

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Products(validProductId, validProductName, validItemPrice, invalidStockAmount));
        }



        [Test]
        public void ItemPrice_ValidRange_ShouldPass()
        {
            // Arrange
            int validProductId = 100;
            string validProductName = "Valid";
            decimal validItemPrice = 500;
            int validStockAmount = 10000;

            // Act
            var product = new Products(validProductId, validProductName, validItemPrice, validStockAmount);

            // Assert
            Assert.That(product.ItemPrice, Is.EqualTo(validItemPrice));
        }


        [Test]
        public void ItemPrice_BelowRange_ShouldThrowException()
        {
            // Arrange
            int validProductId = 100;
            string validProductName = "Invalid";
            decimal invalidItemPrice = 6;  // Below minimum valid range
            int validStockAmount = 10;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Products(validProductId, validProductName, invalidItemPrice, validStockAmount));
        }


        [Test]
        public void ItemPrice_AboveRange_ShouldThrowException()
        {
            // Arrange
            int validProductId = 100;
            string validProductName = "Invalid";
            decimal invalidItemPrice = 7001;  // Above maximum valid range
            int validStockAmount = 10;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Products(validProductId, validProductName, invalidItemPrice, validStockAmount));
        }

    }
}
