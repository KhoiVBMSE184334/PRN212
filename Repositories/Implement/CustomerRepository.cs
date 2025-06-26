using BusinessObject;
using DataAccessObject;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implement
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Add(Customers customer)
        {
            CustomersDAO.Instance.Add(customer);
        }

        public void Delete(int id)
        {
            CustomersDAO.Instance.Delete(id);
        }

        public List<Customers> GetAll()
        {
            return CustomersDAO.Instance.GetAll();
        }

        public Customers GetById(int id)
        {
            return CustomersDAO.Instance.GetById(id);
        }

        public List<Customers> Search(string keyword)
        {
            return CustomersDAO.Instance.Search(keyword);
        }

        public void Update(Customers customer)
        {
            CustomersDAO.Instance.Update(customer);
        }
    }
}
