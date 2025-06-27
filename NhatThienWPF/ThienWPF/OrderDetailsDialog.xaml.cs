using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BusinessObjects;
using BussinessObject;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Services; // Để sử dụng Include

namespace ThienWPF
{
    public partial class OrderDetailsDialog : Window
    {
        private LucySalesDbContext _dbContext = new LucySalesDbContext();
        private OrderDetailsViewModelService orderDetailsViewModelService = new OrderDetailsViewModelService();

        // Constructor nhận OrderId để hiển thị chi tiết
        public OrderDetailsDialog(int orderId)
        {
            InitializeComponent();

            LoadOrderDetails(orderId);
        }

        private void LoadOrderDetails(int orderId)
        {
            try
            {
                // Load Order cùng với Customer, Employee và OrderDetails, Product
                // Sử dụng Include để tải các Navigation Properties
                OrderDetailsViewModel order = orderDetailsViewModelService.GetOrderWithDetails(orderId);

                if (order == null)
                {
                    MessageBox.Show("Order not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                    return;
                }

                // Hiển thị thông tin chung của đơn hàng
                txtOrderId.Text = order.OrderId.ToString();
                txtOrderDate.Text = order.OrderDate.ToString("dd/MM/yyyy HH:mm");
                txtCustomerName.Text = order.CompanyName; 

                // Tạo một List để hiển thị các mục trong DataGrid
                List<OrderItemViewModel> orderItems = new List<OrderItemViewModel>();
                decimal grandTotal = 0;

                foreach (var od in order.OrderItems)
                {
                    // Tính toán thành tiền cho từng mặt hàng
                    decimal itemTotal = od.Quantity * od.UnitPrice * (1 - (decimal)od.Discount);
                    grandTotal += itemTotal;

                    orderItems.Add(new OrderItemViewModel
                    {
                        ProductId = od.ProductId,
                        ProductName = od.ProductName, // Lấy tên sản phẩm từ Navigation Property
                        Quantity = od.Quantity,
                        UnitPrice = od.UnitPrice,
                        Discount = od.Discount,
                        TotalForItem = itemTotal
                    });
                }

                dgOrderItems.ItemsSource = orderItems;
                txtGrandTotal.Text = grandTotal.ToString("C", new System.Globalization.CultureInfo("en-US")); // Định dạng tiền tệ VN

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order details: {ex.Message}\nDetails: {ex.InnerException?.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void DeleteOrderItem_Click(object sender, RoutedEventArgs e)
        {
            // Lấy đối tượng OrderItemViewModel từ dòng đã click
            
            }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    // ViewModel cho từng dòng chi tiết sản phẩm trong đơn hàng
    // Đặt nó trong file OrderDetailsDialog.xaml.cs hoặc trong thư mục ViewModels
    
}