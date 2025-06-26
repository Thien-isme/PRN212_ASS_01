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
using BusinessObjects;
using Services;
namespace ThienWPF
{
    /// <summary>
    /// Interaction logic for CustomerScreen.xaml
    /// </summary>
    public partial class CustomerScreen : Window
    {
        private CustomerService customerService = new CustomerService();
        private OrderService orderService = new OrderService();
        private Customer customer;
        public CustomerScreen()
        {
            InitializeComponent();
            this.Close(); // Close the window if no customer is provided
        }

        public CustomerScreen(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
        }

        private void TimOrderHistory_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {

        }

        private void timProfile_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            txtCompanyName.Text = customer.CompanyName;
            txtContactName.Text = customer.ContactName ?? string.Empty;
            txtContactTitle.Text = customer.ContactTitle ?? string.Empty;
            txtAddress.Text = customer.Address ?? string.Empty;
            txtPhone.Text = customer.Phone ?? string.Empty;
        }




        private void SaveProfile_Click(object sender, RoutedEventArgs e)
        {
            Customer customerUpload = new Customer
            {
                CustomerID = this.customer.CustomerID,
                CompanyName = txtCompanyName.Text.Trim(),
                ContactName = txtContactName.Text.Trim(),
                ContactTitle = txtContactTitle.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Phone = txtPhone.Text.Trim()
            };
            if (customerService.UploadProfile(customerUpload))
            {
                MessageBox.Show("Profile updated successfully!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                customer = customerUpload; // Update the local customer object with the new data
            }
            else
            {
                MessageBox.Show("Profile update failed!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void ResetProfile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadOrderHistory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl tabControl)
            {
                TabItem selectedTab = tabControl.SelectedItem as TabItem;

                if (selectedTab != null)
                {
                    if (selectedTab.Header.ToString() == "My Profile")
                    {
                        LoadCustomerProfile();
                    }
                    else if (selectedTab.Header.ToString() == "Order History")
                    {
                        LoadOrderHistory();
                    }
                }
            }
        }

        private void LoadOrderHistory()
        {
            List<Order> orders = orderService.GetOrdersByCustomerId(customer.CustomerID);
           
            dgOrderHistory.ItemsSource = orders;

        }

        private void LoadCustomerProfile()
        {
            txtCompanyName.Text = customer.CompanyName;
            txtContactName.Text = customer.ContactName ?? string.Empty;
            txtContactTitle.Text = customer.ContactTitle ?? string.Empty;
            txtAddress.Text = customer.Address ?? string.Empty;
            txtPhone.Text = customer.Phone ?? string.Empty;
        }
    }
}
