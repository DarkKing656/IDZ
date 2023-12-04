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
using System.Windows.Shapes;

namespace IntProj
{
    public partial class OrderWindow : Window
    {
        public OrderWindow()
        {
            InitializeComponent();
        }

        public OrderWindow(Product product)
        {
            InitializeComponent();
            Order = new Order();
            Order.Product = product;
            DataContext = Order; // Устанавливаем объект Order в качестве контекста данных для данного окна
        }

        public Order Order { get; private set; } // Создаем свойство Order, чтобы иметь доступ к объекту Order из других частей класса

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // В этом методе вы можете создать новый объект Order и сохранить в него введенные пользователем данные
            Order.Id = GenerateRandomId(); // Предполагая, что у вас есть метод для генерации случайного Id
            Order.Quantity = int.Parse(QuantityTextBox.Text);
            Order.Address = AddressTextBox.Text;
            Order.ContactNumber = ContactNumberTextBox.Text;
            Order.Email = EmailTextBox.Text;
            Order.Comments = CommentsTextBox.Text;
            var orderListWindow = new OrderLIst();
            orderListWindow.AddOrder(Order);
            Close(); // Закрыть окно после сохранения данных
        }

        private int GenerateRandomId()
        {
            // Реализация генерации случайного Id
            Random random = new Random();
            return random.Next(1000, 10000); // Генерация случайного числа от 1000 до 9999
        }
    }
}

