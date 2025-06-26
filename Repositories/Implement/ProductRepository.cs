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
    public class ProductRepository : IProductRepository
    {
        public void Add(Products product)
        {
            ProductsDAO.Instance.Add(product);
        }

        public void Delete(int id)
        {
            ProductsDAO.Instance.Delete(id);
        }

        public List<Products> GetAll()
        {
           return ProductsDAO.Instance.GetAll();
        }

        public Products GetById(int id)
        {
            return ProductsDAO.Instance.GetById(id);
        }

        public List<Products> Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return GetAll();
            }
            return ProductsDAO.Instance.GetAll().Where(p => p.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void Update(Products product)
        {
            var existingProduct = ProductsDAO.Instance.GetById(product.ProductID);
            if (existingProduct == null)
            {
                throw new Exception("Product not found.");
            }
            ProductsDAO.Instance.Update(product);
        }
    }
}
