using BusinessObject;
using System.Windows;

namespace VoBaMinhKhoiWPF.Views
{
    public partial class ProfileDialog : Window
    {
        public Customers UpdatedCustomer { get; private set; }

        public ProfileDialog(Customers currentCustomer)
        {
            InitializeComponent();

            // Gán dữ liệu lên các ô nhập
            UpdatedCustomer = new Customers
            {
                CustomerID = currentCustomer.CustomerID,
                CompanyName = currentCustomer.CompanyName,
                ContactName = currentCustomer.ContactName,
                ContactTitle = currentCustomer.ContactTitle,
                Address = currentCustomer.Address,
                Phone = currentCustomer.Phone
            };

            // Hiển thị dữ liệu
            txtName.Text = UpdatedCustomer.ContactName;
            txtTitle.Text = UpdatedCustomer.ContactTitle;
            txtAddress.Text = UpdatedCustomer.Address;
            txtPhone.Text = UpdatedCustomer.Phone;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            UpdatedCustomer.ContactName = txtName.Text;
            UpdatedCustomer.ContactTitle = txtTitle.Text;
            UpdatedCustomer.Address = txtAddress.Text;
            UpdatedCustomer.Phone = txtPhone.Text;

            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
