using BusinessObject;
using System.Windows;

namespace VoBaMinhKhoiWPF.Dialogs
{
    public partial class CustomerDialog : Window
    {
        public Customers Customer { get; private set; }

        public CustomerDialog(Customers existing = null)
        {
            InitializeComponent();

            if (existing != null)
            {
                Customer = existing;
                txtName.Text = existing.ContactName;
                txtCompany.Text = existing.CompanyName;
                txtPhone.Text = existing.Phone;
            }
            else
            {
                Customer = new Customers();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Customer.ContactName = txtName.Text;
            Customer.CompanyName = txtCompany.Text;
            Customer.Phone = txtPhone.Text;
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

    }
}