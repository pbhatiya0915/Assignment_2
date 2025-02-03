using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce_application
{

    public class Products
    {
        public int ProdID { get;  set; }
        public string ProdName { get;  set; }
        public decimal ItemPrice { get;  set; }
        public int StockAmount { get;   set; }

        public Products(int prodID, string prodName, decimal itemPrice, int stockAmount)
        {
            if (prodID < 7 || prodID > 70000)
                throw new ArgumentOutOfRangeException(nameof(prodID), "Product ID must be between 7 and 70000.");

            if (itemPrice < 7 || itemPrice > 7000)
                throw new ArgumentOutOfRangeException(nameof(itemPrice), "Item Price must be between $7 and $7000.");

            if (stockAmount < 7 || stockAmount > 700000)
                throw new ArgumentOutOfRangeException(nameof(stockAmount), "Stock Amount must be between 7 and 700000.");

            ProdID = prodID;
            ProdName = prodName;
            ItemPrice = itemPrice;
            StockAmount = stockAmount;
        }

        public void IncreaseStock(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Increase amount must be greater than zero.");
            StockAmount += amount;
        }

        public void DecreaseStock(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Decrease amount must be greater than zero.");
            if (StockAmount - amount < 0)
                throw new InvalidOperationException("Stock cannot go below zero.");
            StockAmount -= amount;
        }
    }
}


