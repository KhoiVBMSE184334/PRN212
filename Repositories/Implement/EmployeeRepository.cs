namespace Repositories.Implement
{
    using BusinessObject;
    using DataAccessObject;
    using Repositories.Interface;
    using System.Collections.Generic;

    public class EmployeeRepository : IEmployeeRepository
    {
        public void Add(Employees employee) => EmployeesDAO.Instance.Add(employee);

        public void Delete(int id) => EmployeesDAO.Instance.Delete(id);

        public List<Employees> GetAll() => EmployeesDAO.Instance.GetAll();

        public Employees GetById(int id) => EmployeesDAO.Instance.GetById(id);

        public Employees Login(string username, string password) => EmployeesDAO.Instance.Login(username, password);

        public void Update(Employees employee) => EmployeesDAO.Instance.Update(employee);
    }
}