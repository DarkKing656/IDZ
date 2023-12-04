using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
namespace IntProj
{
   
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow() { 


        InitializeComponent();

        // Загрузка продуктов
        string connectionString = "Data Source=yourdatabase.db;Version=3;";
        Store store = new Store(connectionString);
        this.DataContext = store;  // Установите DataContext представления на экземпляр Store

        // Загрузите продукты
        List<Product> products = store.GetProducts();
        Product newProduct = new Product(357, "Product 3", 300);
        store.AddProduct(newProduct);
    }

    private void MakeOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (productListView.SelectedItem == null)
            {
                MessageBox.Show("Please select a product to make an order.");
                return;
            }

            // Открыть окно "OrderWindow"
            //var orderWindow = new OrderWindow();
           var orderWindow = new OrderWindow((Product)productListView.SelectedItem);
            orderWindow.Show();
           // this.Close();
            // Закрыть текущее окно (если необходимо)
        }
        private void productListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ExitLikeanAdmin_Click(object sender, RoutedEventArgs e)
        {
            var orderListWindow = new OrderLIst();
            orderListWindow.Show();

        }
    }
}