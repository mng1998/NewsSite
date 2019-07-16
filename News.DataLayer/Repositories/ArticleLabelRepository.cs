using News.DataLayer.DAO;
using News.DataLayer.SharedKernel;

namespace News.DataLayer.Repositories
{
    /// <summary>
    /// Provides the methods to work with ArticleLabelDAO
    /// </summary>
    /// <seealso cref="GenericRepositoryBase{long, DataLayer.DAO.ArticleLabelDAO}"/>
    /// <seealso cref="IArticleLabelRepository"/>
    public class ArticleLabelRepository : GenericRepositoryBase<long, ArticleLabelDAO>, IArticleLabelRepository
    {
        /// <summary>
        /// Initialize the new instance <seealso cref="ArticleLabelRepository"/> class.
        /// </summary>
        /// <param name="dbFactory">The db factory.</param>
        public ArticleLabelRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
