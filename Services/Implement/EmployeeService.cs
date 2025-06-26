namespace Services.Implement
{
    using BusinessObject;
    using Repositories.Implement;
    using Repositories.Interface;
    using Services.Interface;
    using System.Collections.Generic;

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            employeeRepository = new EmployeeRepository();
            this.employeeRepository = employeeRepository;
        }

        public void Add(Employees employee) => employeeRepository.Add(employee);

        public void Delete(int id) => employeeRepository.Delete(id);

        public List<Employees> GetAll() => employeeRepository.GetAll();

        public Employees GetById(int id) => employeeRepository.GetById(id);

        public Employees Login(string username, string password) => employeeRepository.Login(username, password);

        public void Update(Employees employee) => employeeRepository.Update(employee);
    }
}
