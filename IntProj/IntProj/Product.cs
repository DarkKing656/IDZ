using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntProj
{
    public class Product
    {
        public Product(int productID, string productName, double price)
        {
            ProductID = productID;
            ProductName = productName;
            Price = price;
        }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }
}
