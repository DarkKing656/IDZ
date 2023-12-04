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
    /// <summary>
    /// Логика взаимодействия для OrderLIst.xaml
    /// </summary>
    public partial class OrderLIst : Window
    {
        public List<Order> Orders { get; set; }
        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }
        public OrderLIst()
        {
            InitializeComponent();
            Orders = new List<Order>();
            DataContext = this;
        }
    }
}
