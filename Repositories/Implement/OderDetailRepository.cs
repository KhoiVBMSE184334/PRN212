namespace Repositories.Implement
{
    using BusinessObject;
    using DataAccessObject;
    using Repositories.Interface;
    using System.Collections.Generic;

    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void Add(OrderDetails detail) => OrderDetailsDAO.Instance.Add(detail);

        public void Delete(int orderId, int productId) => OrderDetailsDAO.Instance.Delete(orderId, productId);

        public List<OrderDetails> GetAll() => OrderDetailsDAO.Instance.GetAll();

        public List<OrderDetails> GetByOrderId(int orderId) => OrderDetailsDAO.Instance.GetByOrderId(orderId);

        public void Update(OrderDetails detail) => OrderDetailsDAO.Instance.Update(detail);
    }
}