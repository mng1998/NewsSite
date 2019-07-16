using System;
using System.Collections.Generic;
using System.Text;

namespace News.DataLayer.Const
{
    /// <summary>
    /// Defines the database constant.
    /// </summary>
    public static class DbConst
    {
        /// <summary>
        /// The insert query.
        /// </summary>
        public const string InsertQuery = "INSERT INTO {0} ({1}) VALUES ({2}); SELECT CAST(SCOPE_IDENTITY() AS BIGINT)";

        /// <summary>
        /// The get all query.
        /// </summary>
        public const string GetAllQuery = "SELECT * FROM {0}";

        /// <summary>
        /// The remove query.
        /// </summary>
        public const string RemoveQuery = "DELETE FROM {0} WHERE Id = @Id";

        /// <summary>
        /// The update query.
        /// </summary>
        public const string UpdateQuery = "UPDATE {0} SET {1} WHERE Id = @Id";

        /// <summary>
        /// The create table to delete query.
        /// </summary>
        public const string CreateTableToDeleteQuery = "CREATE TABLE #{0}s({0} BIGINT PRIMARY KEY)";

        /// <summary>
        /// The delete all from table query.
        /// </summary>
        public const string DeleteAllFromTblQuery = @"DELETE FROM myTable WHERE Id IN (SELECT {0} FROM #{0}s";

        /// <summary>
        /// The drop table query.
        /// </summary>
        public const string DropTableQuery = "DROP TABLE #{0}s";

        /// <summary>
        /// The find by identifier query.
        /// </summary>
        public const string FindByIdQuery = "SELECT * from {0} WHERE Id = @Id";

        /// <summary>
        /// The find by user identifier.
        /// </summary>
        public const string FindByUserId = "SELECT * FROM {0} WHERE UserId = @UserId";

        /// <summary>
        /// The edit feild query.
        /// </summary>
        public const string EditFeildQuery = "UPDATE {0} SET {1} WHERE Id = @Id";

        /// <summary>
        /// The search title query.
        /// </summary>
        public const string SearchTitleQuery = "SELECT * FROM {0} WHERE {1} LIKE @value";

        /// <summary>
        /// The recent article.
        /// </summary>
        public const string SearchRecentQuery = "SELECT * FROM {0} WHERE CreatedDate > @CreatedDate";
    }
}
