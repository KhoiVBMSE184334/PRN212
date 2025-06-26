using System.Windows;

namespace VoBaMinhKhoiWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadCustomerView(); // default view
        }

        private void BtnCustomer_Click(object sender, RoutedEventArgs e)
        {
            LoadCustomerView();
        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Views.ProductView();
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Views.OrderView();
        }

        private void BtnCategory_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Views.CategoryView();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }

        private void LoadCustomerView()
        {
            MainContent.Content = new Views.CustomerView();
        }
        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Views.ReportView();
        }

    }
}
