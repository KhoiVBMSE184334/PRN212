namespace Services.Interface
{
    using BusinessObject;
    using System.Collections.Generic;

    public interface IOrderService
    {
        List<Orders> GetAll();
        Orders GetById(int id);
        void Add(Orders order);
        void Update(Orders order);
        void Delete(int id);
    }
}