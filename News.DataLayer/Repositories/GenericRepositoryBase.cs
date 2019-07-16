using Dapper;
using News.Common.Const;
using News.DataLayer.Const;
using News.DataLayer.SharedKernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace News.DataLayer.Repositories
{
    /// <summary>
    /// Provides shared methods that all repository use.
    /// </summary>
    /// <typeparam name="TKey">The TKey.</typeparam>
    /// <typeparam name="TEntity">The TEntity.</typeparam>
    public abstract class GenericRepositoryBase<TKey, TEntity> : IGenericRepository<TKey, TEntity>
        where TKey : IComparable
        where TEntity : class, IAppDao<TKey>
    {
        #region Constant

        /// <summary>
        /// The table attribute.
        /// </summary>
        private const string TableAttribute = "TableAttribute";

        #endregion

        #region Variables

        /// <summary>
        /// The db factory.
        /// </summary>
        private readonly IDbFactory dbFactory;

        /// <summary>
        /// The table name.
        /// </summary>
        protected readonly string tableName = string.Empty;

        /// <summary>
        /// The identifier column name.
        /// </summary>
        protected readonly string identifierColName = string.Empty;

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize a new instance <seealso cref="GenericRepositoryBase{TKey, TEntity}"/> class.
        /// </summary>
        public GenericRepositoryBase(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            this.tableName = this.GetTableNameMapper(typeof(TEntity));
            this.identifierColName = nameof(AppDaoBase<TKey>.Id);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Adds an entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual TKey Add(TEntity entity)
        {
            var columns = this.GetColumns();
            var strColumns = this.BuildColumns(columns);
            var strParams = this.BuildParameters(columns);
            var query = string.Format(DbConst.InsertQuery, this.tableName, strColumns, strParams);
            return (TKey)this.Execute(Kind.Add, query, entity);
        }

        /// <summary>
        /// Finds entity by identifier.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="includedProperties">The included property.</param>
        /// <returns></returns>
        public virtual TEntity FindById(TKey key)
        {
            var query = string.Format(DbConst.FindByIdQuery, this.tableName);
            return (this.Execute(Kind.Get, query, new { Id = key }) as IEnumerable<TEntity>).First();
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            var query = string.Format(DbConst.GetAllQuery, this.tableName);
            return this.Execute(Kind.GetAll, query, null) as IEnumerable<TEntity>;
        }

        /// <summary>
        /// Removes the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Remove(TEntity entity)
        {
            var id = entity.Id;
            this.Remove(id);
        }

        /// <summary>
        /// Removes entity by key.
        /// </summary>
        /// <param name="key">The key.</param>
        public virtual void Remove(TKey key)
        {
            var query = string.Format(DbConst.RemoveQuery, tableName);
            this.Execute(Kind.Other, query, new { Id = key });
        }

        /// <summary>
        /// Removes all entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <remarks>
        /// https://stackoverflow.com/questions/9946287/correct-method-of-deleting-over-2100-rows-by-id-with-dapper
        /// </remarks>
        public virtual void Remove(IList<TEntity> entities)
        {
            var query = string.Format(DbConst.CreateTableToDeleteQuery, this.identifierColName);
            using (var conection = this.dbFactory.CreateConnection())
            {
                conection.Execute(query);

                this.DeleteFromTbl(conection, entities.Select(n => n.Id));

                query = string.Format(DbConst.DropTableQuery, this.identifierColName);
                conection.Execute(query);
            }
        }

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Edit(TEntity entity)
        {
            var columns = this.GetColumns();
            var stringOfColumns = this.BuildParametersEx(columns);
            var query = string.Format(DbConst.UpdateQuery, tableName, stringOfColumns);
            this.Execute(Kind.Other, query, entity);

        }

        /// <summary>
        /// Executes store procedure.
        /// </summary>
        /// <param name="storeName">The store name.</param>
        /// <param name="param">The param.</param>
        public virtual void ExecuteStoredProcedure(string storeName, object param = null)
        {
            this.Execute(Kind.StoredProcedure, storeName, param);
        }

        /// <summary>
        /// Execute query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="param">The param.</param>
        /// <param name="isGetAll">The is get all.</param>
        /// <returns></returns>
        protected object Execute(Kind kind, string query, object param = null)
        {
            object result;
            using (var connection = this.dbFactory.CreateConnection())
            {
                connection?.Open();

                switch (kind)
                {
                    case Kind.Add:
                        result = connection.Query<TKey>(query, param).Single();
                        break;
                    case Kind.GetAll:
                        result = connection.Query<TEntity>(query);
                        break;
                    case Kind.Get:
                        result = connection.Query<TEntity>(query, param);
                        break;
                    case Kind.Other:
                    case Kind.StoredProcedure:
                    default:
                        result = connection.Execute(query, param);
                        break;
                }
            }

            return result ?? false;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Gets all column's names
        /// </summary>
        /// <returns></returns>
        private IEnumerable<string> GetColumns()
        {
            return typeof(TEntity)
                    .GetProperties()
                    .Where(e => !string.Equals(e.Name, this.identifierColName) && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => e.Name);
        }

        /// <summary>
        /// Builds parameters.
        /// </summary>
        /// <param name="columns">The columns.</param>
        /// <returns></returns>
        private object BuildParameters(IEnumerable<string> columns)
        {
            return string.Join(AppConst.AT_COMMA, columns.Select(e => AppConst.AT_SIGN + e));
        }

        /// <summary>
        /// Builds columns.
        /// </summary>
        /// <param name="columns">The columns.</param>
        /// <returns></returns>
        private string BuildColumns(IEnumerable<string> columns)
        {
            return string.Join(AppConst.AT_COMMA, columns);
        }

        /// <summary>
        /// Builds parameters ex.
        /// </summary>
        /// <param name="columns">The columns.</param>
        /// <returns></returns>
        private string BuildParametersEx(IEnumerable<string> columns)
        {
            return string.Join(AppConst.AT_COMMA, columns.Select(e => $"{e} = @{e}"));
        }

        /// <summary>
        /// Gets table name mapper.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        private string GetTableNameMapper(Type type)
        {
            dynamic tableattr = type.GetCustomAttributes(false).SingleOrDefault(attr => string.Equals(attr.GetType()?.Name, TableAttribute));
            var name = string.Empty;

            if (tableattr != null)
            {
                name = tableattr.Name;
            }

            return name;
        }

        /// <summary>
        /// Deletes from table.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="ids">The list of identifiers.</param>
        /// <param name="colName">The column name.</param>
        private void DeleteFromTbl(SqlConnection connection, IEnumerable<TKey> ids)
        {
            using (var bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.BatchSize = ids.Count();
                bulkCopy.DestinationTableName = string.Format("#{0}s", this.identifierColName);

                var table = new DataTable();
                table.Columns.Add(this.identifierColName, typeof(TKey));
                bulkCopy.ColumnMappings.Add(this.identifierColName, this.identifierColName);

                foreach (var id in ids)
                {
                    table.Rows.Add(id);
                }

                bulkCopy.WriteToServer(table);
            }

            var query = string.Format(DbConst.DeleteAllFromTblQuery, this.identifierColName);
            connection.Execute(query);
        }

        #endregion
    }

    /// <summary>
    /// Defines the enum kind.
    /// </summary>
    public enum Kind
    {
        /// <summary>
        /// The get all.
        /// </summary>
        GetAll = 0,

        /// <summary>
        /// The get.
        /// </summary>
        Get,

        /// <summary>
        /// The add.
        /// </summary>
        Add,

        /// <summary>
        /// The other.
        /// </summary>
        Other,

        /// <summary>
        /// The store procedure.
        /// </summary>
        StoredProcedure
    }
}
