namespace Repositories.Implement
{
    using BusinessObject;
    using DataAccessObject;
    using Repositories.Interface;
    using System.Collections.Generic;

    public class OrderRepository : IOrderRepository
    {
        public void Add(Orders order) => OrdersDAO.Instance.Add(order);

        public void Delete(int id) => OrdersDAO.Instance.Delete(id);

        public List<Orders> GetAll() => OrdersDAO.Instance.GetAll();

        public Orders GetById(int id) => OrdersDAO.Instance.GetById(id);

        public void Update(Orders order) => OrdersDAO.Instance.Update(order);
    }
}