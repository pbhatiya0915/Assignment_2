namespace Products
{
    public class Class1
    {
        public int ProdID { get; set; }
        public string ProdName { get; set; }
        public decimal ItemPrice { get; set; }
        public int StockAmount { get; set; }

        // Constructor to initialize the Product object
        public Class1(int prodID, string prodName, decimal itemPrice, int stockAmount)
        {
            ProdID = prodID;
            ProdName = prodName;
            ItemPrice = itemPrice;
            StockAmount = stockAmount;
        }

        // Method to increase the stock
        public void IncreaseStock(int amount)
        {
            StockAmount += amount;
        }

        // Method to decrease the stock
        public void DecreaseStock(int amount)
        {
            if (StockAmount >= amount)
            {
                StockAmount -= amount;
            }
            else
            {
                throw new InvalidOperationException("Not enough stock to decrease.");
            }
        }
    }
}

