using System.Data.SqlClient;

namespace News.DataLayer.SharedKernel
{
    /// <summary>
    /// Defines database factory.
    /// </summary>
    public interface IDbFactory
    {
        /// <summary>
        /// Create connection to database.
        /// </summary>
        /// <returns></returns>
        SqlConnection CreateConnection();
    }
}
