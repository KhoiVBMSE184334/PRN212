using BusinessObject;
using Repositories.Implement;
using Services.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace VoBaMinhKhoiWPF.Views
{
    public partial class ReportView : UserControl
    {
        private OrderService orderService = new OrderService(new OrderRepository());
        private OrderDetailService orderDetailService = new OrderDetailService(new OrderDetailRepository());

        public ReportView()
        {
            InitializeComponent();
            LoadReportData();
        }

        private void LoadReportData()
        {
            var orders = orderService.GetAll()
                .OrderByDescending(o => o.OrderDate)
                .ToList();

            var reportData = orders.Select(order =>
            {
                var details = orderDetailService.GetByOrderId(order.OrderID);
                int totalItems = details.Sum(d => d.Quantity);

                return new
                {
                    OrderID = order.OrderID,
                    OrderDate = order.OrderDate.ToString("yyyy-MM-dd"),
                    CustomerID = order.CustomerID,
                    TotalItems = totalItems
                };
            }).ToList();

            ReportGrid.ItemsSource = reportData;
        }
    }
}
