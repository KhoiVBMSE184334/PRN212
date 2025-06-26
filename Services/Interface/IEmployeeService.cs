namespace Services.Interface
{
    using BusinessObject;
    using System.Collections.Generic;

    public interface IEmployeeService
    {
        List<Employees> GetAll();
        Employees GetById(int id);
        Employees Login(string username, string password);
        void Add(Employees employee);
        void Update(Employees employee);
        void Delete(int id);
    }
}