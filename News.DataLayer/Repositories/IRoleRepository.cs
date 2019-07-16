using News.DataLayer.DAO;
using News.DataLayer.SharedKernel;

namespace News.DataLayer.Repositories
{
    /// <summary>
    /// Provides the extra methods for RoleRepository.
    /// </summary>
    /// <seealso cref="IGenericRepository{long, DataLayer.DAO.RoleDAO}"/>
    public interface IRoleRepository : IGenericRepository<long, RoleDAO>
    {
    }
}
