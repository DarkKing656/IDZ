using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace IntProj
{
    public class Store : INotifyPropertyChanged
    {
        private string _connectionString;
        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public Store(string connectionString)
        {
            _connectionString = connectionString;
            LoadProducts();
        }

        private void LoadProducts()
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Products";
                var command = new SQLiteCommand(query, connection);
                var reader = command.ExecuteReader();
                var products = new ObservableCollection<Product>();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        ProductName = reader["ProductName"].ToString(),
                        Price = Convert.ToDouble(reader["Price"])
                    });
                }
                Products = products;
            }
        }
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            // Здесь добавьте код для получения списка продуктов из базы данных с использованием _connectionString

            return products;
        }
        public void AddProduct(Product product)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Products (ProductID, ProductName, Price) VALUES (@ProductID, @ProductName, @Price)";
                var command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", product.ProductID);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.ExecuteNonQuery();
            }
            LoadProducts(); // Refresh the Products collection after adding a new product
        }

        // Other methods for updating and deleting products from the database can be added here

        // Implement INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    



    public void CreateOrder(Order order)
        {
            // Logic to save the order in the database.
        }
    }
}
