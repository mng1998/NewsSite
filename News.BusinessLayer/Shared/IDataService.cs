using System;
using System.Collections.Generic;
using System.Text;

namespace News.BusinessLayer.Shared
{
    public interface IDataService<TKey, TModel>
        where TKey : IComparable
        where TModel : class
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        TKey Create(TModel model);

        /// <summary>
        /// Deletes an instance.
        /// </summary>
        /// <param name="key">The key.</param>
        void Delete(TKey key);

        /// <summary>
        /// Reads all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TModel> ReadAll();

        /// <summary>
        /// Reads by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        TModel ReadByKey(TKey key);

        /// <summary>
        /// Updates an instance.
        /// </summary>
        /// <param name="model">The model.</param>
        void Update(TModel model);

    }
}
