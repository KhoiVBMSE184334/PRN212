namespace Repositories.Interface
{
    using BusinessObject;
    using System.Collections.Generic;

    public interface ICategoryRepository
    {
        List<Categories> GetAll();
        Categories GetById(int id);
        void Add(Categories category);
        void Update(Categories category);
        void Delete(int id);
        List<Categories> Search(string keyword);
    }
}