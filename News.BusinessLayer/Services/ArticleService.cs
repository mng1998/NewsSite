using AutoMapper;
using News.BusinessLayer.Models;
using News.DataLayer.DAO;
using News.DataLayer.Repositories;
using System.Collections.Generic;

namespace News.BusinessLayer.Services
{
    /// <summary>
    /// Provides the article service methods.
    /// </summary>
    /// <seealso cref="IArticleService"/>
    public class ArticleService : IArticleService
    {
        /// <summary>
        /// The article repository.
        /// </summary>
        private readonly IArticleRepository articleRepo;

        /// <summary>
        /// Initialize the new instance <seealso cref="ArticleService"/> class.
        /// </summary>
        /// <param name="articleRepo">The article repository.</param>
        public ArticleService(IArticleRepository articleRepo)
        {
            this.articleRepo = articleRepo;
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public long Create(Article model)
        {
            var data = Mapper.Map<Article, ArticleDAO>(model);
            return this.articleRepo.Add(data);
        }

        /// <summary>
        /// Deletes an instance.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Delete(long key)
        {
            this.articleRepo.Remove(key);
        }

        /// <summary>
        /// Gets articles by title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public IEnumerable<string> GetArticleByTitle(string title)
        {
            return this.articleRepo.GetByTitle(title);
        }

        /// <summary>
        /// Gets recent article.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Article> GetRecentArticle()
        {
            var result = this.articleRepo.GetRecent();
            if(result == null)
            {
                return new List<Article>() as IEnumerable<Article>;
            }

            return Mapper.Map<IEnumerable<ArticleDAO>, IEnumerable<Article>>(result);
        }

        /// <summary>
        /// Reads all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Article> ReadAll()
        {
            var data = this.articleRepo.GetAll();
            var result = Mapper.Map<IEnumerable<ArticleDAO>, IEnumerable<Article>>(data);
            return result;
        }

        /// <summary>
        /// Reads by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public Article ReadByKey(long key)
        {
            var data = this.articleRepo.FindById(key);
            var result = Mapper.Map<ArticleDAO, Article>(data);
            return result;
        }

        /// <summary>
        /// Updates an instance.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(Article model)
        {
            var data = Mapper.Map<Article, ArticleDAO>(model);
            this.articleRepo.Edit(data);
        }
    }
}
