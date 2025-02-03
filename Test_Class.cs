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
