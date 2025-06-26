namespace Services.Implement
{
    using BusinessObject;
    using Repositories.Interface;
    using Services.Interface;
    using System.Collections.Generic;

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void Add(Orders order) => orderRepository.Add(order);

        public void Delete(int id) => orderRepository.Delete(id);

        public List<Orders> GetAll() => orderRepository.GetAll();

        public Orders GetById(int id) => orderRepository.GetById(id);

        public void Update(Orders order) => orderRepository.Update(order);
    }
}