using News.DataLayer.Const;
using News.DataLayer.DAO;
using News.DataLayer.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace News.DataLayer.Repositories
{
    /// <summary>
    /// Provides the methods to work with ArticleDAO
    /// </summary>
    /// <seealso cref="GenericRepositoryBase{long, DataLayer.DAO.ArticleDAO}"/>
    /// <seealso cref="IArticleRepository"/>
    public class ArticleRepository : GenericRepositoryBase<long, ArticleDAO>, IArticleRepository
    {
        /// <summary>
        /// The min date.
        /// </summary>
        private const int MIN= -10;

        /// <summary>
        /// Initialize the new instance <seealso cref="ArticleRepository"/> class.
        /// </summary>
        /// <param name="dbFactory">The db factory.</param>
        public ArticleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        /// <summary>
        /// Gets an article by title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public IEnumerable<string> GetByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return new List<string>() as IEnumerable<string>;
            }

            var query = string.Format(DbConst.SearchTitleQuery, this.tableName, nameof(ArticleDAO.Title));
            var result = this.Execute(Kind.Get, query, new { value = $"%{title}%" });
            return (result as IEnumerable<ArticleDAO>)?.Select(n => n.Title);
        }

        /// <summary>
        /// Gets recent article.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ArticleDAO> GetRecent()
        {
            var query = string.Format(DbConst.SearchRecentQuery, this.tableName);
            var result = this.Execute(Kind.Get, query, new { CreatedDate = DateTime.Now.AddDays(MIN) }) as IEnumerable<ArticleDAO>;
            return result;
        }
    }
}
