using System.Windows;
using System.Windows.Controls;
using BusinessObject;
using Repositories.Implement;
using Services.Implement;
using VoBaMinhKhoiWPF.Dialogs;
using System.Collections.Generic;

namespace VoBaMinhKhoiWPF.Views
{
    public partial class CategoryView : UserControl
    {
        private readonly CategoryService service = new(new CategoryRepository());
        private List<Categories> categories;

        public CategoryView()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            categories = service.GetAll();
            CategoryGrid.ItemsSource = categories;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CategoryDialog();
            if (dialog.ShowDialog() == true)
            {
                service.Add(dialog.Category);
                LoadData();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryGrid.SelectedItem is Categories selected)
            {
                var dialog = new CategoryDialog(selected);
                if (dialog.ShowDialog() == true)
                {
                    service.Update(dialog.Category);
                    LoadData();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryGrid.SelectedItem is Categories selected &&
                MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                service.Delete(selected.CategoryID);
                LoadData();
            }
        }
    }
}
