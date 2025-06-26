using BusinessObjects;
using Services;
using System.Windows;


namespace ThienWPF
{
    public partial class CustomerFormDialog : Window
    {
        public Customer EditedCustomer { get; private set; }
        private bool _isNewCustomer;
        private CustomerService customerService = new CustomerService();

        public CustomerFormDialog(Customer customer = null)
        {
            InitializeComponent();
            if (customer == null)
            {
                _isNewCustomer = true;
                EditedCustomer = new Customer();
                lblDialogTitle.Text = "Add new Customer";
                txtCustomerID.IsEnabled = false; // Mã KH tự sinh, không cho nhập
            }
            else
            {
                _isNewCustomer = false;
                EditedCustomer = customer;
                lblDialogTitle.Text = "Update Profile Customer";
                txtCustomerID.IsEnabled = true; // Cho phép hiển thị, nhưng vẫn IsReadOnly trong XAML
                txtCustomerID.Text = EditedCustomer.CustomerID.ToString();
                txtCustomerCompanyName.Text = EditedCustomer.CompanyName ?? string.Empty;
                txtCustomerContactName.Text = EditedCustomer.ContactName ?? string.Empty;
                txtCustomerContactTitle.Text = EditedCustomer.ContactTitle ?? string.Empty;
                txtCustomerAddress.Text = EditedCustomer.Address ?? string.Empty;
                txtCustomerPhone.Text = EditedCustomer.Phone ?? string.Empty;

                customerService.UploadProfile(EditedCustomer);
            }

            DataContext = EditedCustomer; // Gán DataContext để binding 2 chiều

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_isNewCustomer)
            {
                EditedCustomer.CompanyName = txtCustomerCompanyName.Text;
                EditedCustomer.ContactName = txtCustomerContactName.Text;
                EditedCustomer.ContactTitle = txtCustomerContactTitle.Text;
                EditedCustomer.Address = txtCustomerAddress.Text;
                EditedCustomer.Phone = txtCustomerPhone.Text;

                customerService.AddCustomer(EditedCustomer);
            }
            else
            {
                EditedCustomer.CompanyName = txtCustomerCompanyName.Text;
                EditedCustomer.ContactName = txtCustomerContactName.Text;
                EditedCustomer.ContactTitle = txtCustomerContactTitle.Text;
                EditedCustomer.Address = txtCustomerAddress.Text;
                EditedCustomer.Phone = txtCustomerPhone.Text;

                customerService.Update(EditedCustomer);
            }

            // Kiểm tra validation cơ bản
            if (string.IsNullOrWhiteSpace(EditedCustomer.CompanyName) || string.IsNullOrWhiteSpace(EditedCustomer.Phone))
            {
                MessageBox.Show("Company name and phone number must not be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Đánh dấu DialogResult là true để báo cho cửa sổ gọi biết là đã lưu
            DialogResult = true;
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}