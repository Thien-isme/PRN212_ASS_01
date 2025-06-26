using System.Windows;
using System.Windows.Controls;

using Services;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.ObjectModel;
using BusinessObjects;
using BussinessObject;

namespace ThienWPF
{
    public partial class EmployeeScreen : Window
    {
        private Employee loggedInEmployee;
        private CustomerService customerService = new CustomerService();
        private ProductService productService = new ProductService();
        private OrderService orderService = new OrderService();
        private OrderReportDtoService orderReportDtoService = new OrderReportDtoService();
        private double lblOrderTotalValue = 0;
        private bool changeTabItem = false;

        private ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        private ObservableCollection<Product> products = new ObservableCollection<Product>();
        private ObservableCollection<TempOrderItem> currentOrderItems = new ObservableCollection<TempOrderItem>();
        private ObservableCollection<Order> existingOrders = new ObservableCollection<Order>();

        public class TempOrderItem : OrderDetail
        {
            public string ProductName { get; set; }
            public string CategoryName { get; set; }
            public decimal LineTotal => UnitPrice * Quantity * (decimal)(1 - Discount);
        }

        public EmployeeScreen()
        {
            InitializeComponent();
            // Lógica khởi tạo mặc định (ví dụ: thông báo lỗi)
        }

        public EmployeeScreen(Employee employee)
        {
            InitializeComponent();
            // Lógica khởi tạo với thông tin nhân viên đăng nhập
            loggedInEmployee = employee;

            if (loggedInEmployee != null)
            {
                lblWelcomeMessage.Text = $"Welcome, {loggedInEmployee.Name} ({loggedInEmployee.JobTitle})!";

                // Gán ItemsSource cho DataGrid và ComboBox khi khởi tạo
                dgCustomers.ItemsSource = customers;
                dgProducts.ItemsSource = products;
                dgCurrentOrderItems.ItemsSource = currentOrderItems;
                dgExistingOrders.ItemsSource = existingOrders;
                
                // Khởi tạo ngày cho DatePicker (có thể bỏ qua nếu bạn không muốn tải báo cáo ngay)
                //dpEndDate.SelectedDate = DateTime.Today;
                //dpStartDate.SelectedDate = DateTime.Today.AddMonths(-1);

                // Tải dữ liệu ban đầu cho tab mặc định (ví dụ: Quản lý Khách hàng)
                // Các hàm LoadCustomers(), LoadProducts(), LoadOrderCreationDropdowns(), LoadExistingOrders()
                // sẽ được gọi bên trong MainTabControl_SelectionChanged khi tab tương ứng được chọn lần đầu.
            }
            else
            {
                MessageBox.Show("No employee information was provided.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                this.Close();
            }
        }

        // --- Event handler cho TabControl SelectionChanged ---
        private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl tabControl && e.AddedItems.Count > 0)
            {
                TabItem selectedTab = tabControl.SelectedItem as TabItem;

                if (selectedTab != null)
                {
                    switch (selectedTab.Header.ToString())
                    {
                        case "Customer Management":
                            dgCustomers.SelectedItem = null; // Bỏ chọn hàng đã chọn trong DataGrid khách hàng
                            LoadCustomers(); // Tải dữ liệu khách hàng
                            break;
                        case "Product Management":
                            LoadProducts(); // Tải dữ liệu sản phẩm
                            dgProducts.SelectedItem = null; // Bỏ chọn hàng đã chọn trong DataGrid sản phẩm
                            break;
                        case "Create Order":
                            LoadOrderCreationDropdowns(); // Tải dữ liệu cho các dropdown tạo đơn hàng
                            currentOrderItems.Clear(); // Xóa các mục trong đơn hàng hiện tại
                            lblOrderTotalValue = 0;
                            CalculateOrderTotal(); // Tính toán lại tổng tiền đơn hàng
                            break;
                        case "Ordered Management":
                            LoadExistingOrders(); // Tải các đơn hàng hiện có
                            break;
                        case "Report":
                            changeTabItem = true;
                            BtnGenerateReport_Click(this, new RoutedEventArgs()); // Kích hoạt nút tạo báo cáo để tải báo cáo

                            break;
                    }
                }
            }
        }

        // --- Quản lý Khách hàng ---
        private void LoadCustomers()
        {
            // Logic sẽ được viết ở đây
            //customerService.GetAllCustomers();
            dgCustomers.ItemsSource = customerService.GetAllCustomers();


        }

        private void DgCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Logic sẽ được viết ở đây
        }

        private void TxtCustomerSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Logic sẽ được viết ở đây
            txtPlaceholder.Visibility = string.IsNullOrWhiteSpace(txtCustomerSearch.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void BtnCustomerSearch_Click(object sender, RoutedEventArgs e)
        {
            // Logic sẽ được viết ở đây
            
                string companyName = txtCustomerSearch.Text;
                companyName = companyName.Length == 0 ? "" : companyName;
                List<Customer> listCustomer = customerService.SearchByCompanyName(companyName);
                if (listCustomer.Count > 0)
                {
                    dgCustomers.ItemsSource = listCustomer;
                }
                
            

        }

        private void BtnCustomerRefresh_Click(object sender, RoutedEventArgs e)
        {
            // Logic sẽ được viết ở đây
            LoadCustomers();
            txtCustomerSearch.Text = "";
        }

        private void BtnCustomerAdd_Click(object sender, RoutedEventArgs e)
        {
            // Logic sẽ được viết ở đây
            CustomerFormDialog customerForm = new CustomerFormDialog();
            bool? result = customerForm.ShowDialog();
            if(result == true)
            {
                LoadCustomers();
            }
        }

        private void BtnCustomerUpdate_Click(object sender, RoutedEventArgs e)
        {
            // Logic sẽ được viết ở đây
            if(dgCustomers.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer to update.", "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);

                return;
            }
            Customer selectedCustomer = dgCustomers.SelectedItem as Customer;
            CustomerFormDialog customerForm = new CustomerFormDialog(selectedCustomer);
            bool? result = customerForm.ShowDialog();
            if (result == true)
            {
                LoadCustomers();
            }
        }

        private void BtnCustomerDelete_Click(object sender, RoutedEventArgs e)
        {
            // Logic sẽ được viết ở đây
            if (dgCustomers.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer to delete.", "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Customer selectedCustomer = dgCustomers.SelectedItem as Customer;

            if (selectedCustomer == null)
            {
                MessageBox.Show("The selected customer could not be found.", "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete the customer \"{selectedCustomer.CompanyName}\"?",
                "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return; // User chose not to delete
            }
            customerService.Delete(selectedCustomer);
            LoadCustomers();
        }

        // --- Quản lý Sản phẩm ---
        private void LoadProducts()
        {
            // Logic sẽ được viết ở đây
            dgProducts.ItemsSource = productService.GetAllProducts();
        }

        private void DgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Logic sẽ được viết ở đây
        }

        private void TxtProductSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Logic sẽ được viết ở đây
            txtProductSearchPlaceholder.Visibility = string.IsNullOrWhiteSpace(txtProductSearch.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void BtnProductSearch_Click(object sender, RoutedEventArgs e)
        {
            // Logic sẽ được viết ở đây
            string productName = txtProductSearch.Text;
            productName = productName.Length == 0 ? "" : productName;
            List<Product> listProducts = productService.SearchByProductName(productName);
            if (listProducts.Count > 0)
            {
                dgProducts.ItemsSource = listProducts;
            }
        }

        private void BtnProductRefresh_Click(object sender, RoutedEventArgs e)
        {
            // Logic sẽ được viết ở đây
            LoadProducts();
            txtProductSearch.Text = "";

        }

        private void BtnProductAdd_Click(object sender, RoutedEventArgs e)
        {
            // Logic sẽ được viết ở đây
            ProductFormDialog productForm = new ProductFormDialog();
            bool? result = productForm.ShowDialog(); // chờ đến khi form đóng

            if (result == true)
            {
                LoadProducts(); // chỉ gọi khi thêm sản phẩm thành công
            }

        }

        private void BtnProductUpdate_Click(object sender, RoutedEventArgs e)
        {
            // Logic sẽ được viết ở đây
            if (dgProducts.SelectedItem == null)
            {
                MessageBox.Show("Please select a product to update.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Product selectedProduct = dgProducts.SelectedItem as Product;
            ProductFormDialog productForm = new ProductFormDialog(selectedProduct);
            bool? result = productForm.ShowDialog(); // chờ đến khi form đóng

            if (result == true)
            {
                LoadProducts(); // chỉ gọi khi thêm sản phẩm thành công
            }
        }

        private void BtnProductDelete_Click(object sender, RoutedEventArgs e)
        {
            // Logic sẽ được viết ở đây
            Product product = dgProducts.SelectedItem as Product;
            if (product == null)
            {
                MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete the product \"{product.ProductName}\"?",
                "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return; // User chose not to delete
            }


            productService.Delete(product);
            LoadProducts();
        }

        // --- Tạo Đơn hàng ---
        private void LoadOrderCreationDropdowns()
        {
            // Logic sẽ được viết ở đây
            List<Customer> customers = customerService.GetAllCustomers();
            cbCustomers.ItemsSource = customers;
            List<Product> products = productService.GetAllProducts();
            cbProducts.ItemsSource = products;
            //foreach(Customer customer in customers)
            //{
            //    cbCustomers.Items.Add(customer.CompanyName);
            //}
        }

        private void CalculateOrderTotal()
        {
            // Logic sẽ được viết ở đây
        }

        private void CbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Logic sẽ được viết ở đây
        }

        private void CbProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Logic sẽ được viết ở đây
        }

        private void TxtOrderItemQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Logic sẽ được viết ở đây
        }

        private void TxtOrderItemDiscount_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Logic sẽ được viết ở đây
        }

        private void BtnAddProductToOrder_Click(object sender, RoutedEventArgs e)
        {
            // Logic sẽ được viết ở đây
            Product product = cbProducts.SelectedItem as Product;
            if (product == null)
            {
                MessageBox.Show("Please select a product before adding it to the order.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtOrderItemQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int quantityToBuy = quantity;

            if (!decimal.TryParse(txtOrderItemDiscount.Text, out decimal discount) || discount < 0 || discount > 100)
            {
                MessageBox.Show("Please enter a valid discount percentage (0–100).", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int soLuongMua = quantity;

            TempOrderItem tempOrderItem = new TempOrderItem()
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                CategoryName = product.Category?.CategoryName ?? "No category",
                UnitPrice = product.UnitPrice ?? 0,
                Quantity = (short)soLuongMua,
                Discount = (float)discount/100,

            };
            currentOrderItems.Add(tempOrderItem);
            cbProducts.SelectedItem = null;
            txtOrderItemQuantity.Text = "1";
            txtOrderItemDiscount.Text = "0";
            lblOrderTotalValue = Math.Round(lblOrderTotalValue, 2) + Math.Round((double)tempOrderItem.LineTotal, 2);
            lblOrderTotal.Text = Math.Round(lblOrderTotalValue, 2).ToString();
        }

        private void BtnRemoveOrderItem_Click(object sender, RoutedEventArgs e)
        {
            // Logic sẽ được viết ở đây
            Button button = sender as Button;
            int productID = (int)button.Tag;
            TempOrderItem itemToRemove = currentOrderItems.FirstOrDefault(item => item.ProductID == productID);
            if (itemToRemove != null)
            {
                lblOrderTotalValue -= Math.Round((double)itemToRemove.LineTotal, 2);
                lblOrderTotal.Text = Math.Round(lblOrderTotalValue, 2).ToString();
                currentOrderItems.Remove(itemToRemove);
            }
        }

        private void BtnPlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            // 1. Kiểm tra các điều kiện tiên quyết
            if (cbCustomers.SelectedValue == null)
            {
                MessageBox.Show("Please select a customer.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (currentOrderItems.Count == 0)
            {
                MessageBox.Show("The order is empty. Please add products.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            // Lấy thông tin khách hàng và nhân viên
            int customerID = int.Parse(cbCustomers.SelectedValue.ToString());
            // Giả sử bạn có biến _loggedInEmployee được gán khi đăng nhập
            // Nếu loggedInEmployee có thể null, bạn cần xử lý ở đây
            if (loggedInEmployee == null)
            {
                MessageBox.Show("Logged-in employee information not found. Please log in again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int employeeID = loggedInEmployee.EmployeeID; //

            // 2. Tạo đối tượng Order
            Order newOrder = new Order()
            {
                OrderID = orderService.CreateOrderID(),
                CustomerID = customerID,
                EmployeeID = employeeID, // Gán EmployeeID từ nhân viên đã đăng nhập
                OrderDate = DateTime.Today,
                // Các thuộc tính khác của Order như RequiredDate, ShippedDate, ShipAddress, ShipCity, ...
                // có thể được điền từ các trường UI hoặc giá trị mặc định.
                // Ví dụ: ShipAddress = "Địa chỉ mặc định" hoặc từ một TextBox
            };

            try
            {
                // 3. Thêm Order vào DbContext và lưu để lấy OrderID
                orderService.AddOrder(newOrder); // Phương thức AddOrder sẽ thêm order và gọi SaveChanges

                // Sau khi AddOrder, newOrder.OrderID sẽ có giá trị tự động được tạo từ DB
                int newOrderID = newOrder.OrderID;

                // 4. Tạo và thêm các đối tượng OrderDetail
                foreach (var tempItem in currentOrderItems)
                {
                    OrderDetail orderDetail = new OrderDetail()
                    {
                        OrderID = newOrderID,
                        ProductID = tempItem.ProductID,
                        UnitPrice = tempItem.UnitPrice,
                        Quantity = tempItem.Quantity,
                        Discount = tempItem.Discount // Discount đã là thập phân (0.0 - 1.0)
                    };
                    orderService.AddOrderDetail(orderDetail); // Phương thức AddOrderDetail
                }

                // 5. Cập nhật tồn kho sản phẩm (nếu cần)
                foreach (var tempItem in currentOrderItems)
                {
                    productService.UpdateProductStock(tempItem.ProductID, tempItem.Quantity); // Phương thức giảm số lượng tồn kho
                }


                MessageBox.Show("Order placed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


                // 6. Xóa danh sách tạm thời và cập nhật UI
                currentOrderItems.Clear(); // Xóa tất cả các mục khỏi ObservableCollection
                dgCurrentOrderItems.ItemsSource = currentOrderItems; // Cập nhật lại DataGrid (nếu cần thiết, OC tự động làm)
                CalculateOrderTotal(); // Đặt lại tổng tiền về 0
                cbCustomers.SelectedItem = null; // Bỏ chọn khách hàng
                cbProducts.SelectedItem = null; // Bỏ chọn sản phẩm
                txtOrderItemQuantity.Text = "1"; // Đặt lại số lượng
                txtOrderItemDiscount.Text = "0"; // Đặt lại giảm giá
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while placing the order: {ex.Message}\nDetails: {ex.InnerException?.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        // --- Xem Đơn hàng ---
        private void LoadExistingOrders()
        {
            // Logic sẽ được viết ở đây
            existingOrders = new ObservableCollection<Order>(orderService.GetAllOrdered());
            dgExistingOrders.ItemsSource = existingOrders;

        }
        private void DgExistingOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Logic sẽ được viết ở đây
        }

        private void BtnViewOrderDetails_Click(object sender, RoutedEventArgs e)
        {
            // Logic sẽ được viết ở đây
        }

        // --- Báo cáo ---
        private void BtnGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            // Logic sẽ được viết ở đây
            DateTime fromDate;
            DateTime toDate;
            if (changeTabItem == true)
            {
                fromDate = new DateTime(2024, 1, 1);
                toDate = new DateTime(2025, 12, 12);
                changeTabItem = false;
            }
            else
            {
                fromDate = dpStartDate.SelectedDate ?? DateTime.MinValue;
                toDate = dpEndDate.SelectedDate ?? DateTime.MaxValue;
            }



                List<OrderReportDTO> list = orderReportDtoService.getReportFormTo(fromDate, toDate);

            dgReports.ItemsSource = list;
        }

       

    }
}