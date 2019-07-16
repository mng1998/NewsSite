using News.DataLayer.DAO;
using News.DataLayer.SharedKernel;
using System.Collections.Generic;

namespace News.DataLayer.Repositories
{
    /// <summary>
    /// Provides the extra methods for ArticleRepository.
    /// </summary>
    /// <seealso cref="IGenericRepository{long, DataLayer.DAO.ArticleDAO}"/>
    public interface IArticleRepository:IGenericRepository<long, ArticleDAO>
    {
        /// <summary>
        /// Gets an article by title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        IEnumerable<string> GetByTitle(string title);

        /// <summary>
        /// Gets recent article.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ArticleDAO> GetRecent();
    }
}
