using News.DataLayer.DAO;
using News.DataLayer.SharedKernel;
using System.Collections.Generic;

namespace News.DataLayer.Repositories
{
    /// <summary>
    /// Provides the extra methods for UserRoleRepository.
    /// </summary>
    /// <seealso cref="IGenericRepository{long, DataLayer.DAO.UserRoleDAO}"/>
    public interface IUserRoleRepository : IGenericRepository<long, UserRoleDAO>
    {
        /// <summary>
        /// Finds an item by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IEnumerable<UserRoleDAO> FindByUserId(long userId);
    }
}
