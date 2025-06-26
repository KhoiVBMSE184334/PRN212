using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CustomersDAO
    {
        private static CustomersDAO instance;
        private static readonly object instanceLock = new object();
        private List<Customers> customers;

        private CustomersDAO()
        {
            customers = new List<Customers>
            {
                new Customers { CustomerID = 1, CompanyName = "Company A", ContactName = "Alice", ContactTitle = "Manager", Address = "123 Main St", Phone = "123-456-7890" },
                new Customers { CustomerID = 2, CompanyName = "Company B", ContactName = "Bob", ContactTitle = "Director", Address = "456 Elm St", Phone = "987-654-3210" }
            };
        }

        public static CustomersDAO Instance
        {
            get
            {
               lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomersDAO();
                    }
                    return instance;
                }
            }
        }
        // Get all customers
        public List<Customers> GetAll() => customers;

        // Get customer by ID
        public Customers GetById(int id) =>
            customers.FirstOrDefault(c => c.CustomerID == id);

        // Add new customer
        public void Add(Customers customer)
        {
            if (customers.Any(c => c.CustomerID == customer.CustomerID))
                throw new Exception("CustomerID already exists.");
            customers.Add(customer);
        }

        // Update existing customer
        public void Update(Customers updatedCustomer)
        {
            var existing = GetById(updatedCustomer.CustomerID);
            if (existing != null)
            {
                existing.CompanyName = updatedCustomer.CompanyName;
                existing.ContactName = updatedCustomer.ContactName;
                existing.ContactTitle = updatedCustomer.ContactTitle;
                existing.Address = updatedCustomer.Address;
                existing.Phone = updatedCustomer.Phone;
            }
            else
            {
                throw new Exception("Customer not found.");
            }
        }

        // Delete customer by ID
        public void Delete(int id)
        {
            var customer = GetById(id);
            if (customer != null)
            {
                customers.Remove(customer);
            }
            else
            {
                throw new Exception("Customer not found.");
            }
        }

        // Search customers by name or company
        public List<Customers> Search(string keyword)
        {
            return customers
                .Where(c =>
                    (!string.IsNullOrEmpty(c.CompanyName) && c.CompanyName.ToLower().Contains(keyword.ToLower())) ||
                    (!string.IsNullOrEmpty(c.ContactName) && c.ContactName.ToLower().Contains(keyword.ToLower()))
                )
                .ToList();
        }
    }
}
