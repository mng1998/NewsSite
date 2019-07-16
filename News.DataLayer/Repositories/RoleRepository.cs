using News.DataLayer.DAO;
using News.DataLayer.SharedKernel;

namespace News.DataLayer.Repositories
{
    /// <summary>
    /// Provides the methods to work with RoleDAO
    /// </summary>
    /// <seealso cref="GenericRepositoryBase{long, DataLayer.DAO.RoleDAO}"/>
    /// <seealso cref="IRoleRepository"/>
    public class RoleRepository : GenericRepositoryBase<long, RoleDAO>, IRoleRepository
    {
        /// <summary>
        /// Initialize the new instance <seealso cref="RoleRepository"/> class.
        /// </summary>
        /// <param name="dbFactory">The db factory.</param>
        public RoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
