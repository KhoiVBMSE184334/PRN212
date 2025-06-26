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
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(ProductRepository productRepository)
        {
            productRepository = new ProductRepository();
            this.productRepository = productRepository;
        }

        public void Add(Products product)
        {
            productRepository.Add(product);
        }

        public void Delete(int id)
        {
            productRepository.Delete(id);
        }

        public List<Products> GetAll()
        {
            return productRepository.GetAll();
        }

        public Products GetById(int id)
        {
            return productRepository.GetById(id);
        }

        public List<Products> Search(string keyword)
        {
            return productRepository.Search(keyword);
        }

        public void Update(Products product)
        {
            productRepository.Update(product);
        }
    }
}
