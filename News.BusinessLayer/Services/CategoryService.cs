using System.Collections.Generic;
using AutoMapper;
using News.BusinessLayer.Models;
using News.DataLayer.DAO;
using News.DataLayer.Repositories;

namespace News.BusinessLayer.Services
{
    /// <summary>
    /// Provides the category service methods.
    /// </summary>
    /// <seealso cref="ICategoryService"/>
    public class CategoryService : ICategoryService
    {
        /// <summary>
        /// The category repository.
        /// </summary>
        private readonly ICategoryRepository categoryRepo;

        /// <summary>
        /// Initialize the new instance <seealso cref="CategoryService"/> class.
        /// </summary>
        /// <param name="categoryRepo">The category repository.</param>
        public CategoryService(ICategoryRepository categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public long Create(Category model)
        {
            var data = Mapper.Map<Category, CategoryDAO>(model);
            return this.categoryRepo.Add(data);
        }

        /// <summary>
        /// Deletes an instance.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Delete(long key)
        {
            this.categoryRepo.Remove(key);
        }

        /// <summary>
        /// Reads all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Category> ReadAll()
        {
            var data = this.categoryRepo.GetAll();
            var result = Mapper.Map<IEnumerable<CategoryDAO>, IEnumerable<Category>>(data);
            return result;
        }

        /// <summary>
        /// Reads by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public Category ReadByKey(long key)
        {
            var data = this.categoryRepo.FindById(key);
            var result = Mapper.Map<CategoryDAO, Category>(data);
            return result;
        }

        /// <summary>
        /// Updates an instance.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(Category model)
        {
            var data = Mapper.Map<Category, CategoryDAO>(model);
            this.categoryRepo.Edit(data);
        }
    }
}
