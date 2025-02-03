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

        /*
         * Created by: Shubham Savaliya
         * These tests are intended to verify that stock-related activities in the Products class are accurate.
         * Each test case handles edge cases and invalid inputs while verifying a particular scenario when stock is increased or decreased.
         * 
         * Test cases:
         * 1. IncreaseStock_WhenStockIsIncreasedBy10_ShouldUpdateStockCount - Verifies that the stock is correctly updated when stock is increased by a valid amount (10).
         * 2. IncreaseStock_WhenCountIsValid_ShouldIncreaseStockCorrectly - Verifies that stock can be increased to the maximum valid value (700,000) without errors.
         * 3. IncreaseStock_WhenCountIsNegative_ShouldThrowArgumentException - Ensures that attempting to increase stock by zero throws an ArgumentException, indicating that the increase amount must be positive.
         * 4. DecreaseStock_WhenAmountIsOne_ShouldDecreaseStockByOne - Verifies that stock is correctly reduced by a valid amount (10).
         * 5. DecreaseStock_WhenReducingToZero_ShouldSetStockToZero - Verifies that stock is correctly set to zero when the decrease amount is equal to the current stock amount.
         * 6. DecreaseStock_WhenAmountExceedsStock_ShouldThrowInvalidOperationException - Ensures that an attempt to decrease stock below zero throws an InvalidOperationException, preventing invalid stock values.
         *
         * The test cases ensure that the Products class handles various stock operations, validating proper behavior and exception handling.
         * These tests were chosen to cover typical stock updates, edge cases (e.g., reducing stock to zero or exceeding available stock), and invalid inputs.
        */


        // Test case: 1

        [Test]
        public void IncreaseStock_WhenStockIsIncreasedBy10_ShouldUpdateStockCount()
        {
            // Arrange
            int initialStock = product.StockAmount;
            int increaseAmount = 10;

            // Act
            product.IncreaseStock(increaseAmount);

            // Assert
            int expectedStock = initialStock + increaseAmount;
            Assert.That(product.StockAmount, Is.EqualTo(expectedStock));
        }

        // Test case: 2

        [Test]
        public void IncreaseStock_WhenCountIsValid_ShouldIncreaseStockCorrectly()
        {
            // Arrange
            int initialStock = product.StockAmount;

            // Increase to max limit
            int increaseAmount = 700000 - initialStock;

            // Act
            product.IncreaseStock(increaseAmount);

            // Assert
            Assert.That(product.StockAmount, Is.EqualTo(700000));
        }

        // Test case: 3

        [Test]
        public void IncreaseStock_WhenCountIsNegative_ShouldThrowArgumentException()
        {
            // Arrange
            int initialStock = product.StockAmount;
            int increaseAmount = 0;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => product.IncreaseStock(increaseAmount));

            // Assert
            Assert.That(ex.Message, Is.EqualTo("Increase amount must be greater than zero."));
        }

        // Test Case: 4

        [Test]
        public void DecreaseStock_WhenAmountIsOne_ShouldDecreaseStockByOne()
        {
            // Arrange
            int initialStock = product.StockAmount;
            int decreaseAmount = 10;

            // Act
            product.DecreaseStock(decreaseAmount);

            // Assert
            int expectedStock = initialStock - decreaseAmount;
            Assert.That(product.StockAmount, Is.EqualTo(expectedStock));
        }


        // Test Case: 5

        [Test]
        public void DecreaseStock_WhenReducingToZero_ShouldSetStockToZero()
        {
            // Arrange
            int initialStock = product.StockAmount;

            // Reduce stock completely
            int decreaseAmount = initialStock;

            // Act
            product.DecreaseStock(decreaseAmount);

            // Assert
            Assert.That(product.StockAmount, Is.EqualTo(0));
        }

        // Test Case: 6

        [Test]
        public void DecreaseStock_WhenAmountExceedsStock_ShouldThrowInvalidOperationException()
        {
            // Arrange
            // More than available stock
            int excessiveDecreaseAmount = product.StockAmount + 1;

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(excessiveDecreaseAmount));

            // Assert
            Assert.That(ex.Message, Is.EqualTo("Stock cannot go below zero."));
        }
    }
}
