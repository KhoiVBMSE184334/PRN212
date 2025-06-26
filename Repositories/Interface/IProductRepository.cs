using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IProductRepository
    {
        List<BusinessObject.Products> GetAll();
        BusinessObject.Products GetById(int id);
        void Add(BusinessObject.Products product);
        void Update(BusinessObject.Products product);
        void Delete(int id);
        List<BusinessObject.Products> Search(string keyword);
    }
}
