namespace Repositories.Implement
{
    using BusinessObject;
    using DataAccessObject;
    using Repositories.Interface;
    using System.Collections.Generic;

    public class CategoryRepository : ICategoryRepository
    {
        public void Add(Categories category) => CategoriesDAO.Instance.Add(category);

        public void Delete(int id) => CategoriesDAO.Instance.Delete(id);

        public List<Categories> GetAll() => CategoriesDAO.Instance.GetAll();

        public Categories GetById(int id) => CategoriesDAO.Instance.GetById(id);

        public void Update(Categories category) => CategoriesDAO.Instance.Update(category);

        public List<Categories> Search(string keyword) => CategoriesDAO.Instance.Search(keyword);
    }
}
