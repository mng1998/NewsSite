using News.BusinessLayer.Models;
using News.BusinessLayer.Shared;
using System.Collections.Generic;

namespace News.BusinessLayer.Services
{
    /// <summary>
    /// Defines the extra methods for user role service.
    /// </summary>
    /// <seealso cref="IDataService{long, BusinessLayer.Models.UserRole}"/>
    public interface IUserRoleService : IDataService<long, UserRole>
    {
        /// <summary>
        /// Reads all role.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Role> ReadAllRole();
    }
}
