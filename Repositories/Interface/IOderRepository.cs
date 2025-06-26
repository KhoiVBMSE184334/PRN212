namespace Repositories.Interface
{
    using BusinessObject;
    using System.Collections.Generic;

    public interface IOrderRepository
    {
        List<Orders> GetAll();
        Orders GetById(int id);
        void Add(Orders order);
        void Update(Orders order);
        void Delete(int id);
    }
}