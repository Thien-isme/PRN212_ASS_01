using BusinessObjects;
using System;
using System.Linq;
using System.Windows;
using DataAccessLayer;
using Services;
namespace ThienWPF
{
    public partial class ProductFormDialog : Window
    {
        private Product _product;
        private readonly LucySalesDbContext dbContext; // Thay YourDbContext bằng tên DbContext của bạn
        private ProductService productService = new ProductService();

        // Constructor mới với tham số optional cho Product
        public ProductFormDialog(Product product = null)
        {
            InitializeComponent();
            dbContext = new LucySalesDbContext(); // Khởi tạo DbContext của bạn ở đây

            _product = product;
            LoadCategories(); // Tải danh mục vào ComboBox

            if (_product != null)
            {
                // Chế độ chỉnh sửa
                lblDialogTitle.Text = "Update Product";
                txtProductID.Text = _product.ProductID.ToString();
                txtProductName.Text = _product.ProductName;
                // Chọn Category trong ComboBox dựa trên CategoryId của sản phẩm
                cbxCategory.SelectedValue = _product.CategoryID;
                txtUnitPrice.Text = _product.UnitPrice.ToString();
                txtUnitsInStock.Text = _product.UnitsInStock.ToString();
                txtQuantityPerUnit.Text = _product.QuantityPerUnit; // Gán giá trị QuantityPerUnit
            }
            else
            {
                // Chế độ thêm mới
                lblDialogTitle.Text = "Add new Product";
                txtProductID.Text = "(No need enter)"; // Hoặc để trống nếu ID tự tăng
            }
        }

        // Phương thức để tải danh sách danh mục vào ComboBox
        private void LoadCategories()
        {
            try
            {
                var categories = dbContext.Categories.ToList();
                cbxCategory.ItemsSource = categories;
                // cbxCategory.DisplayMemberPath = "CategoryName"; // Đã đặt trong XAML
                // cbxCategory.SelectedValuePath = "CategoryId";   // Đã đặt trong XAML
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while loading categories: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validation cơ bản (bạn nên thêm validation đầy đủ hơn)
                if (string.IsNullOrWhiteSpace(txtProductName.Text))
                {
                    MessageBox.Show("Product name must not be empty.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (cbxCategory.SelectedValue == null)
                {
                    MessageBox.Show("Please select a category.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice) || unitPrice < 0)
                {
                    MessageBox.Show("Invalid unit price.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!short.TryParse(txtUnitsInStock.Text, out short unitsInStock) || unitsInStock < 0)
                {
                    MessageBox.Show("Invalid stock quantity.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                if (_product == null)
                {
                    // Thêm mới sản phẩm
                    _product = new Product();
                    _product.ProductName = txtProductName.Text;
                    _product.CategoryID = (int)cbxCategory.SelectedValue; // Lấy CategoryId từ ComboBox
                    _product.UnitPrice = unitPrice;
                    _product.UnitsInStock = unitsInStock;
                    _product.QuantityPerUnit = txtQuantityPerUnit.Text; // Lấy QuantityPerUnit

                    productService.Add(_product);
                }
                else
                {
                    // Cập nhật sản phẩm
                    _product.ProductName = txtProductName.Text;
                    _product.CategoryID = (int)cbxCategory.SelectedValue; // Cập nhật CategoryId
                    _product.UnitPrice = unitPrice;
                    _product.UnitsInStock = unitsInStock;
                    _product.QuantityPerUnit = txtQuantityPerUnit.Text; // Cập nhật QuantityPerUnit

                    productService.Update(_product);
                }

                DialogResult = true; // Báo hiệu thành công và đóng dialog
                this.Close();
            }
            catch (Exception ex)
            {
                // Bạn có thể xử lý các loại Exception cụ thể hơn ở đây
                MessageBox.Show($"An error occurred while saving the product: {ex.Message}\nDetails: {ex.InnerException?.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Báo hiệu hủy bỏ
            this.Close();
        }
    }
}