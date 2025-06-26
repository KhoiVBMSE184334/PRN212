using BusinessObject;
using Repositories.Implement;
using Services.Implement;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace VoBaMinhKhoiWPF.Views
{
    public partial class OrderHistoryView : UserControl
    {
        private readonly int customerId;

        private readonly OrderService orderService = new OrderService(new OrderRepository());

        public OrderHistoryView(int customerId)
        {
            InitializeComponent();
            this.customerId = customerId;
            LoadOrderHistory();
        }

        private void LoadOrderHistory()
        {
            var orders = orderService.GetAll()
                            .Where(o => o.CustomerID == customerId)
                            .OrderByDescending(o => o.OrderDate)
                            .ToList();

            OrderHistoryGrid.ItemsSource = orders;
        }
    }
}
