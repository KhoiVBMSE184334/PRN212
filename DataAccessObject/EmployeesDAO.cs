using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObject
{
    public class EmployeesDAO
    {
        private static EmployeesDAO instance;
        private static readonly object lockObj = new object();
        private List<Employees> employees;

        private EmployeesDAO()
        {
            employees = new List<Employees>
            {
                new Employees { EmployeeID = 1, Name = "Alice", UserName = "alice", Password = "123", JobTitle = "Admin" },
                new Employees { EmployeeID = 2, Name = "Bob", UserName = "bob", Password = "456", JobTitle = "Staff" }
            };
        }

        public static EmployeesDAO Instance
        {
            get
            {
                lock (lockObj)
                {
                    return instance ??= new EmployeesDAO();
                }
            }
        }

        public List<Employees> GetAll() => employees;

        public Employees GetById(int id) => employees.FirstOrDefault(e => e.EmployeeID == id);

        public Employees Login(string username, string password)
        {
            return employees.FirstOrDefault(e => e.UserName == username && e.Password == password);
        }

        public void Add(Employees employee)
        {
            if (employees.Any(e => e.EmployeeID == employee.EmployeeID))
                throw new Exception("Employee ID already exists.");
            employees.Add(employee);
        }

        public void Update(Employees employee)
        {
            var existing = GetById(employee.EmployeeID);
            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.UserName = employee.UserName;
                existing.Password = employee.Password;
                existing.JobTitle = employee.JobTitle;
            }
            else
            {
                throw new Exception("Employee not found.");
            }
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
                employees.Remove(employee);
            else
                throw new Exception("Employee not found.");
        }
    }
}