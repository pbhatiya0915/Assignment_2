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



    }
}
