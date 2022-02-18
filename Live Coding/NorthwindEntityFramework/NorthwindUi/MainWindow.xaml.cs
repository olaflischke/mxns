using NorthwindDal;
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

namespace NorthwindUi
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NorthwindContext context = new NorthwindContext();

            var q = context.Customers.AsNoTracking().Select(cu => cu.Country).Distinct();

            foreach (string land in q)
            {
                TreeViewItem treeViewItem = new TreeViewItem() { Header = land };
                treeViewItem.Items.Add(new TreeViewItem());

                treeViewItem.Expanded += this.TreeViewItem_Expanded;

                trvCustomers.Items.Add(treeViewItem);
            }
        }

        private void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            NorthwindContext context = new NorthwindContext();

            if (sender is TreeViewItem tviLand)
            {
                tviLand.Items.Clear();

                string land = tviLand.Header.ToString();

                var qCustomersOfCountry = context.Customers.AsNoTracking().Where(cu => cu.Country == land)
                                                            .Select(cu => new { cu.CompanyName, cu.CustomerID });

                foreach (var item in qCustomersOfCountry)
                {
                    TreeViewItem tviCustomer = new TreeViewItem() { Header = item.CompanyName, Tag = item.CustomerID };
                    tviCustomer.Selected += this.TviCustomer_Selected;
                    tviLand.Items.Add(tviCustomer);
                }
            }
        }

        private void TviCustomer_Selected(object sender, RoutedEventArgs e)
        {
            NorthwindContext context = new NorthwindContext();

            if (sender is TreeViewItem tviCustomer)
            {
                string customerId = tviCustomer.Tag.ToString();

                var qOrderThisCustomer = context.Orders.Where(od => od.CustomerID == customerId);

                cbxOrders.ItemsSource = qOrderThisCustomer.ToList();
            }
        }

        private void cbxOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NorthwindContext context = new NorthwindContext();

            if (cbxOrders.SelectedItem is Order order)
            {
                var qOrderInfos = context.Order_Details.Where(od => od.OrderID == order.OrderID)
                                                    .Select(od => new { od.Quantity, od.Product.ProductName, od.UnitPrice, od.Discount });

                dgOrderInfos.ItemsSource = qOrderInfos.ToList();
            }
        }
    }
}
