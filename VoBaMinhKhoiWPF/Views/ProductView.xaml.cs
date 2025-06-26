using System.Windows;
using System.Windows.Controls;
using BusinessObject;
using Repositories.Implement;
using Services.Implement;
using VoBaMinhKhoiWPF.Dialogs;
using System.Collections.Generic;

namespace VoBaMinhKhoiWPF.Views
{
    public partial class ProductView : UserControl
    {
        private readonly ProductService service = new(new ProductRepository());
        private List<Products> products;

        public ProductView()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            products = service.GetAll();
            ProductGrid.ItemsSource = products;
        }

      

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ProductDialog();
            if (dialog.ShowDialog() == true)
            {
                service.Add(dialog.Product);
                LoadData();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedItem is Products selected)
            {
                var dialog = new ProductDialog(selected);
                if (dialog.ShowDialog() == true)
                {
                    service.Update(dialog.Product);
                    LoadData();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedItem is Products selected &&
                MessageBox.Show("Are you sure?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                service.Delete(selected.ProductID);
                LoadData();
            }
        }
    }
}
