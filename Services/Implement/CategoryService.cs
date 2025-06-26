namespace Services.Implement
{
    using BusinessObject;
    using Repositories.Interface;
    using Services.Interface;
    using System.Collections.Generic;

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repository;

        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public void Add(Categories category) => repository.Add(category);

        public void Delete(int id) => repository.Delete(id);

        public List<Categories> GetAll() => repository.GetAll();

        public Categories GetById(int id) => repository.GetById(id);

        public void Update(Categories category) => repository.Update(category);

        public List<Categories> Search(string keyword) => repository.Search(keyword);
    }
}
