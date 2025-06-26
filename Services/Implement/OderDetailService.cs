namespace Services.Implement
{
    using BusinessObject;
    using Repositories.Interface;
    using Services.Interface;
    using System.Collections.Generic;

    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository repository;

        public OrderDetailService(IOrderDetailRepository repository)
        {
            this.repository = repository;
        }

        public void Add(OrderDetails detail) => repository.Add(detail);

        public void Delete(int orderId, int productId) => repository.Delete(orderId, productId);

        public List<OrderDetails> GetAll() => repository.GetAll();

        public List<OrderDetails> GetByOrderId(int orderId) => repository.GetByOrderId(orderId);

        public void Update(OrderDetails detail) => repository.Update(detail);
    }
}
