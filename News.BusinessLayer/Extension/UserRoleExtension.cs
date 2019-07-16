using News.BusinessLayer.Models;
using News.DataLayer.DAO;
using System.Collections.Generic;

namespace News.BusinessLayer.Extension
{
    /// <summary>
    /// Provides the external methods for user role class.
    /// </summary>
    public static class UserRoleExtension
    {
        /// <summary>
        /// Check is exist in the list
        /// </summary>
        /// <param name="lst">The list.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsExist(this List<UserRole> lst, UserRoleDAO value)
        {
            foreach (var inner in lst)
            {
                if (long.Equals(inner.User?.Id, value?.Id))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
