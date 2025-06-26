using System.Windows;
using System.Windows.Controls;
using BusinessObject;
using Repositories.Implement;
using Services.Implement;
using VoBaMinhKhoiWPF.Dialogs;
using System.Collections.Generic;
using System.Linq;

namespace VoBaMinhKhoiWPF.Views
{
    public partial class CustomerView : UserControl
    {
        private readonly CustomerService customerService = new(new CustomerRepository());
        private List<Customers> customers;

        public CustomerView()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            customers = customerService.GetAll();
            CustomerGrid.ItemsSource = customers;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CustomerDialog();
            if (dialog.ShowDialog() == true)
            {
                customerService.Add(dialog.Customer);
                LoadData();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerGrid.SelectedItem is Customers selected)
            {
                var dialog = new CustomerDialog(selected);
                if (dialog.ShowDialog() == true)
                {
                    customerService.Update(dialog.Customer);
                    LoadData();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerGrid.SelectedItem is Customers selected &&
                MessageBox.Show("Are you sure?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                customerService.Delete(selected.CustomerID);
                LoadData();
            }
        }
    }
}