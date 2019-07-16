using News.DataLayer.Const;
using News.DataLayer.DAO;
using News.DataLayer.SharedKernel;

namespace News.DataLayer.Repositories
{
    /// <summary>
    /// Provides the methods to work with UserDAO
    /// </summary>
    /// <seealso cref="GenericRepositoryBase{long, DataLayer.DAO.UserDAO}"/>
    /// <seealso cref="IUserRepository"/>
    public class UserRepository : GenericRepositoryBase<long, UserDAO>, IUserRepository
    {
        /// <summary>
        /// Initialize the new instance <seealso cref="UserRepository"/> class.
        /// </summary>
        /// <param name="dbFactory">The db factory.</param>
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        /// <summary>
        /// Removes by key.
        /// </summary>
        /// <param name="key">The key.</param>
        public override void Remove(long key)
        {
            var status = string.Format("Status='{0}'", UserStatus.Deleted);
            var query = string.Format(DbConst.EditFeildQuery, this.tableName, status);
            this.Execute(Kind.Other, query, new { Id = key });
        }
    }
}
