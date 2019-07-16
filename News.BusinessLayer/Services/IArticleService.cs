using News.BusinessLayer.Models;
using News.BusinessLayer.Shared;
using System.Collections.Generic;

namespace News.BusinessLayer.Services
{
    /// <summary>
    /// Defines the extra methods for article service.
    /// </summary>
    /// <seealso cref="IDataService{long, BusinessLayer.Models.Article}"/>
    public interface IArticleService : IDataService<long, Article>
    {
        /// <summary>
        /// Gets articles by title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        IEnumerable<string> GetArticleByTitle(string title);

        /// <summary>
        /// Gets the recent article.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Article> GetRecentArticle();
    }
}
