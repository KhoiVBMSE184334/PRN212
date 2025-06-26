using BusinessObject;
using System.Windows;
using System.Xml.Linq;

namespace VoBaMinhKhoiWPF.Dialogs
{
    public partial class ProductDialog : Window
    {
        public Products Product { get; private set; }

        public ProductDialog(Products existing = null)
        {
            InitializeComponent();

            if (existing != null)
            {
                Product = existing;
                txtName.Text = existing.ProductName;
                txtCategoryID.Text = existing.CategoryID.ToString();
                txtPrice.Text = existing.UnitPrice.ToString();
                txtStock.Text = existing.UnitsInStock.ToString();
            }
            else
            {
                Product = new Products();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Product.ProductName = txtName.Text;
            Product.CategoryID = int.Parse(txtCategoryID.Text);
            Product.UnitPrice = decimal.Parse(txtPrice.Text);
            Product.UnitsInStock = int.Parse(txtStock.Text);
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }

}