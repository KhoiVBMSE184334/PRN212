using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObject
{
    public class OrderDetailsDAO
    {
        private static OrderDetailsDAO instance;
        private static readonly object lockObj = new object();
        private List<OrderDetails> orderDetails;

        private OrderDetailsDAO()
        {
            orderDetails = new List<OrderDetails>
            {
                new OrderDetails { OrderID = 1, ProductID = 1, UnitPrice = 20.5m, Quantity = 2, Discount = 0.1f },
                new OrderDetails { OrderID = 1, ProductID = 2, UnitPrice = 15.0m, Quantity = 1, Discount = 0 }
            };
        }

        public static OrderDetailsDAO Instance
        {
            get
            {
                lock (lockObj)
                {
                    return instance ??= new OrderDetailsDAO();
                }
            }
        }

        public List<OrderDetails> GetAll() => orderDetails;

        public List<OrderDetails> GetByOrderId(int orderId) =>
            orderDetails.Where(od => od.OrderID == orderId).ToList();

        public void Add(OrderDetails detail)
        {
            if (orderDetails.Any(od => od.OrderID == detail.OrderID && od.ProductID == detail.ProductID))
                throw new Exception("Order detail already exists for this product in the order.");
            orderDetails.Add(detail);
        }

        public void Update(OrderDetails detail)
        {
            var existing = orderDetails.FirstOrDefault(od => od.OrderID == detail.OrderID && od.ProductID == detail.ProductID);
            if (existing != null)
            {
                existing.UnitPrice = detail.UnitPrice;
                existing.Quantity = detail.Quantity;
                existing.Discount = detail.Discount;
            }
            else
            {
                throw new Exception("Order detail not found.");
            }
        }

        public void Delete(int orderId, int productId)
        {
            var detail = orderDetails.FirstOrDefault(od => od.OrderID == orderId && od.ProductID == productId);
            if (detail != null)
                orderDetails.Remove(detail);
            else
                throw new Exception("Order detail not found.");
        }
    }
}