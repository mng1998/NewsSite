using News.DataLayer.Const;
using News.DataLayer.DAO;
using News.DataLayer.SharedKernel;
using System.Collections.Generic;

namespace News.DataLayer.Repositories
{
    /// <summary>
    /// Provides the methods to work with LabelDAO
    /// </summary>
    /// <seealso cref="GenericRepositoryBase{long, DataLayer.DAO.UserRoleDAO}"/>
    /// <seealso cref="IUserRoleRepository"/>
    public class UserRoleRepository : GenericRepositoryBase<long, UserRoleDAO>, IUserRoleRepository
    {
        /// <summary>
        /// Initialize the new instance <seealso cref="UserRoleRepository"/> class.
        /// </summary>
        /// <param name="dbFactory">The db factory.</param>
        public UserRoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        /// <summary>
        /// Finds an item by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public IEnumerable<UserRoleDAO> FindByUserId(long userId)
        {
            var query = string.Format(DbConst.FindByUserId, this.tableName);
            return this.Execute(Kind.Get, query, new { UserId = userId }) as IEnumerable<UserRoleDAO>;
        }
    }
}
