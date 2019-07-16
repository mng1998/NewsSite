using System;
using System.Collections.Generic;
using System.Text;

namespace News.DataLayer.SharedKernel
{
    public interface IGenericRepository<TKey, TEntity>
        where TKey: IComparable
        where TEntity: IAppDao<TKey>
    {
        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Finds by identifier.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="includedProperties">The included properties.</param>
        /// <returns></returns>
        TEntity FindById(TKey key);

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        TKey Add(TEntity entity);

        /// <summary>
        /// Edits the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        void Edit(TEntity entity);

        /// <summary>
        /// Removes by the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Removes by key.
        /// </summary>
        /// <param name="key">The key.</param>
        void Remove(TKey key);

        /// <summary>
        /// Removes multiple entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void Remove(IList<TEntity> entities);

        /// <summary>
        /// Execute stored procedure.
        /// </summary>
        /// <param name="storeName">The store name.</param>
        /// <param name="param">The param.</param>
        void ExecuteStoredProcedure(string storeName, object param = null);
    }
}
