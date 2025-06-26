using BusinessObject;
using System.Windows;

namespace VoBaMinhKhoiWPF.Dialogs 
{
    public partial class CategoryDialog : Window
    {
        public Categories Category { get; private set; }

        public CategoryDialog(Categories existing = null)
        {
            InitializeComponent();

            if (existing != null)
            {
                Category = existing;
                txtName.Text = existing.CategoryName;
                txtDesc.Text = existing.Description;
            }
            else
            {
                Category = new Categories();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Category.CategoryName = txtName.Text;
            Category.Description = txtDesc.Text;
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
