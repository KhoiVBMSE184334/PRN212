using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObject
{
    public class CategoriesDAO
    {
        private static CategoriesDAO instance;
        private static readonly object lockObj = new object();
        private List<Categories> categories;

        private CategoriesDAO()
        {
            categories = new List<Categories>
            {
                new Categories { CategoryID = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas" },
                new Categories { CategoryID = 2, CategoryName = "Snacks", Description = "Chips, cookies, crackers" }
            };
        }

        public static CategoriesDAO Instance
        {
            get
            {
                lock (lockObj)
                {
                    return instance ??= new CategoriesDAO();
                }
            }
        }

        public List<Categories> GetAll() => categories;

        public Categories GetById(int id) => categories.FirstOrDefault(c => c.CategoryID == id);

        public void Add(Categories category)
        {
            if (categories.Any(c => c.CategoryID == category.CategoryID))
                throw new Exception("Category ID already exists.");
            categories.Add(category);
        }

        public void Update(Categories category)
        {
            var existing = GetById(category.CategoryID);
            if (existing != null)
            {
                existing.CategoryName = category.CategoryName;
                existing.Description = category.Description;
            }
            else
            {
                throw new Exception("Category not found.");
            }
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category != null)
                categories.Remove(category);
            else
                throw new Exception("Category not found.");
        }

        public List<Categories> Search(string keyword)
        {
            keyword = keyword?.ToLower() ?? "";
            return categories
                .Where(c => !string.IsNullOrEmpty(c.CategoryName) && c.CategoryName.ToLower().Contains(keyword))
                .ToList();
        }
    }
}