using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface ICustomerRepository
    {
        List<Customers> GetAll();
        Customers GetById(int id);
        void Add(Customers customer);
        void Update(Customers customer);
        void Delete(int id);
        List<Customers> Search(string keyword);
    }
}
