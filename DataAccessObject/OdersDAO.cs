using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObject
{
    public class OrdersDAO
    {
        private static OrdersDAO instance;
        private static readonly object lockObj = new object();
        private List<Orders> orders;

        private OrdersDAO()
        {
            orders = new List<Orders>
            {
                new Orders { OrderID = 1, CustomerID = 1, EmployeeID = 1, OrderDate = DateTime.Now.AddDays(-5) },
                new Orders { OrderID = 2, CustomerID = 2, EmployeeID = 2, OrderDate = DateTime.Now.AddDays(-2) }
            };
        }

        public static OrdersDAO Instance
        {
            get
            {
                lock (lockObj)
                {
                    return instance ??= new OrdersDAO();
                }
            }
        }

        public List<Orders> GetAll() => orders;

        public Orders GetById(int id) => orders.FirstOrDefault(o => o.OrderID == id);

        public void Add(Orders order)
        {
            if (orders.Any(o => o.OrderID == order.OrderID))
                throw new Exception("Order ID already exists.");
            orders.Add(order);
        }

        public void Update(Orders order)
        {
            var existing = GetById(order.OrderID);
            if (existing != null)
            {
                existing.CustomerID = order.CustomerID;
                existing.EmployeeID = order.EmployeeID;
                existing.OrderDate = order.OrderDate;
            }
            else
            {
                throw new Exception("Order not found.");
            }
        }

        public void Delete(int id)
        {
            var order = GetById(id);
            if (order != null)
                orders.Remove(order);
            else
                throw new Exception("Order not found.");
        }
    }
}
