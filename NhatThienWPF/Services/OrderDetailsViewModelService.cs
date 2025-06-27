using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BussinessObject;
using Repositories;
namespace Services
{
    public class OrderDetailsViewModelService
    {
        private OrderDetailsViewModelRepository orderDetailsViewModelRepository;

        public OrderDetailsViewModelService()
        {
            orderDetailsViewModelRepository = new OrderDetailsViewModelRepository();
        }

        public OrderDetailsViewModel GetOrderWithDetails(int orderId)
        {
            var orderEntity = orderDetailsViewModelRepository.GetOrderWithDetails(orderId).FirstOrDefault();

            if (orderEntity == null)
            {
                return null; // Trả về null nếu không tìm thấy đơn hàng
            }

            // 2. Khởi tạo danh sách OrderItemViewModel và tính toán tổng tiền
            List<OrderItemViewModel> orderItems = new List<OrderItemViewModel>();
            decimal grandTotal = 0;

            // Kiểm tra xem OrderDetails có null không trước khi lặp (nếu navigation property có thể null)
            if (orderEntity.OrderDetails != null)
            {
                foreach (var od in orderEntity.OrderDetails)
                {
                    // Tính toán thành tiền cho từng mặt hàng
                    decimal itemTotal = od.Quantity * od.UnitPrice * (1 - (decimal)od.Discount);
                    grandTotal += itemTotal;

                    // Ánh xạ từ OrderDetail Entity sang OrderItemViewModel
                    orderItems.Add(new OrderItemViewModel
                    {
                        ProductId = od.ProductID, // Đảm bảo khớp tên thuộc tính (ProductID vs ProductId)
                        ProductName = od.Product?.ProductName, // Sử dụng ?. để tránh lỗi nếu Product là null
                        Quantity = od.Quantity,
                        UnitPrice = od.UnitPrice,
                        Discount = od.Discount,
                        TotalForItem = itemTotal
                    });
                }
            }

            return new OrderDetailsViewModel
            {
                OrderId = orderEntity.OrderID, // Đảm bảo khớp tên thuộc tính (OrderID vs OrderId)
                OrderDate = orderEntity.OrderDate,
                CompanyName = orderEntity.Customer?.CompanyName, // Hoặc ContactName, sử dụng ?.
                OrderItems = orderItems, // Danh sách OrderItemViewModel đã được tạo ở trên
                GrandTotal = grandTotal // Tổng tiền đã được tính toán ở trên
            };
        }
    }
}
