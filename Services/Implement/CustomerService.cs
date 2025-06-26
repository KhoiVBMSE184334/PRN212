using BusinessObject;
using Repositories.Implement;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implement
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerService(CustomerRepository customerRepository)
        {
            customerRepository = new CustomerRepository();
            this.customerRepository = customerRepository;
        }
        public void Add(Customers customer)
        {
            customerRepository.Add(customer);
        }

        public void Delete(int id)
        {
            var customer = customerRepository.GetById(id);
            if (customer == null) throw new Exception("Customer not found");
            customerRepository.Delete(id);
        }

        public List<Customers> GetAll()
        {
            return customerRepository.GetAll();
        }

        public Customers GetById(int id)
        {
            return customerRepository.GetById(id);
        }

        public List<Customers> Search(string keyword)
        {
            return customerRepository.Search(keyword);
        }

        public void Update(Customers customer)
        {
            customerRepository.Update(customer);
        }
    }
}
