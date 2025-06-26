using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObject
{
    public class ProductsDAO
    {
        private static ProductsDAO instance;
        private static readonly object instanceLock = new object();
        private List<Products> products;

        private ProductsDAO()
        {
            products = new List<Products>
            {
                new Products { ProductID = 1, ProductName = "Product A", CategoryID = 1, UnitPrice = 20.5m, UnitsInStock = 100 },
                new Products { ProductID = 2, ProductName = "Product B", CategoryID = 2, UnitPrice = 15.0m, UnitsInStock = 50 }
            };
        }

        public static ProductsDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new ProductsDAO();
                    return instance;
                }
            }
        }

        // Get all products
        public List<Products> GetAll() => products;

        // Get product by ID
        public Products GetById(int id) =>
            products.FirstOrDefault(p => p.ProductID == id);

        // Add new product
        public void Add(Products product)
        {
            if (products.Any(p => p.ProductID == product.ProductID))
                throw new Exception("ProductID already exists.");
            products.Add(product);
        }

        // Update existing product
        public void Update(Products updatedProduct)
        {
            var existing = GetById(updatedProduct.ProductID);
            if (existing != null)
            {
                existing.ProductName = updatedProduct.ProductName;
                existing.CategoryID = updatedProduct.CategoryID;
                existing.UnitPrice = updatedProduct.UnitPrice;
                existing.UnitsInStock = updatedProduct.UnitsInStock;
            }
            else
            {
                throw new Exception("Product not found.");
            }
        }

        // Delete product by ID
        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                products.Remove(product);
            }
            else
            {
                throw new Exception("Product not found.");
            }
        }

        // Search products by name
        public List<Products> Search(string keyword)
        {
            keyword = keyword?.ToLower() ?? "";
            return products
                .Where(p =>
                    !string.IsNullOrEmpty(p.ProductName) &&
                    p.ProductName.ToLower().Contains(keyword)
                )
                .ToList();
        }
    }
}
