using News.DataLayer.DAO;
using News.DataLayer.SharedKernel;

namespace News.DataLayer.Repositories
{
    /// <summary>
    /// Provides the methods to work with CategoryDAO
    /// </summary>
    /// <seealso cref="GenericRepositoryBase{long, DataLayer.DAO.CategoryDAO}"/>
    /// <seealso cref="ICategoryRepository"/>
    public class CategoryRepository : GenericRepositoryBase<long, CategoryDAO>, ICategoryRepository
    {
        /// <summary>
        /// Initialize the new instance <seealso cref="CategoryRepository"/> class.
        /// </summary>
        /// <param name="dbFactory">The db factory.</param>
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
