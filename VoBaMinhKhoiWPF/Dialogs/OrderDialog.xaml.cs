using BusinessObject;
using System.Windows;

namespace VoBaMinhKhoiWPF.Dialogs
{
    public partial class OrderDialog : Window
    {
        public Orders Order { get; private set; }

        public OrderDialog(Orders existing = null)
        {
            InitializeComponent();

            if (existing != null)
            {
                Order = existing;
                txtCustomerID.Text = existing.CustomerID.ToString();
                txtEmployeeID.Text = existing.EmployeeID.ToString();
                dpOrderDate.SelectedDate = existing.OrderDate;
            }
            else
            {
                Order = new Orders();
                dpOrderDate.SelectedDate = System.DateTime.Now;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Order.CustomerID = int.Parse(txtCustomerID.Text);
            Order.EmployeeID = int.Parse(txtEmployeeID.Text);
            Order.OrderDate = dpOrderDate.SelectedDate ?? System.DateTime.Now;
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}