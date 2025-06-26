namespace Repositories.Interface
{
    using BusinessObject;
    using System.Collections.Generic;

    public interface IOrderDetailRepository
    {
        List<OrderDetails> GetAll();
        List<OrderDetails> GetByOrderId(int orderId);
        void Add(OrderDetails detail);
        void Update(OrderDetails detail);
        void Delete(int orderId, int productId);
    }
}