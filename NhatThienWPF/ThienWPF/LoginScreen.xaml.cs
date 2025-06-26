using System.Windows;
using System.Windows.Controls;
using Services;
namespace ThienWPF // Đảm bảo namespace này khớp với namespace dự án của bạn
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
       
        private int role = 0;
        public LoginScreen()
        {
            InitializeComponent();
            btnCustomer_Click(this, null);
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            role = 0; // Đặt vai trò là Customer
            lblUsername.Text = "Enter Phone:"; // Cập nhật nhãn cho tên người dùn
            lblPassword.Visibility = Visibility.Collapsed; // Ẩn nhãn mật khẩu
            txtPassword.Visibility = Visibility.Collapsed; // Ẩn trường mật khẩu
            txtPassword.Password = ""; // Xóa nội dung trường mật khẩu
            txtUsername.Text = ""; // Xóa nội dung trường tên người dùng
            btnCustomer.Background = System.Windows.Media.Brushes.LightBlue; // Đổi màu nền nút Customer
            btnAdmin.Background = System.Windows.Media.Brushes.White; // Đổi màu nền nút Customer
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            role = 1; // Đặt vai trò là Customer
            lblUsername.Text = "Username:"; // Cập nhật nhãn cho tên người dùng
            lblPassword.Text = "Password:"; // Cập nhật nhãn cho mật khẩu
            txtUsername.Text = ""; // Xóa nội dung trường tên người dùng
            txtPassword.Password = ""; // Xóa nội dung trường mật khẩu
            lblPassword.Visibility = Visibility.Visible; // Hiển thị nhãn mật khẩu
            txtPassword.Visibility = Visibility.Visible; // Hiển thị trường mật khẩu
            btnAdmin.Background = System.Windows.Media.Brushes.LightBlue; // Đổi màu nền nút Customer
            btnCustomer.Background = System.Windows.Media.Brushes.White; // Đổi màu nền nút Customer
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password.Trim();
            if (role == 1)
            {
                EmployeeService employeeService = new EmployeeService();
                var employee = employeeService.GetEmployeeByUsernamePassword(username, password);
                if (employee != null)
                {
                    EmployeeScreen employeeScreen = new EmployeeScreen(employee);
                    employeeScreen.Show();
                    this.Close(); // Đóng cửa sổ đăng nhập
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Lỗi đăng nhập", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                }
            else if(role == 0)
            {
                CustomerService customerService = new CustomerService();
                var customer = customerService.GetCustomerByPhone(username);
                if (customer != null)
                {
                    CustomerScreen customerScreen = new CustomerScreen(customer);
                    customerScreen.Show();
                    this.Close(); // Đóng cửa sổ đăng nhập
                }
                else
                {
                    MessageBox.Show("Khách hàng không tồn tại với SDT: " + username, "Lỗi đăng nhập", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}