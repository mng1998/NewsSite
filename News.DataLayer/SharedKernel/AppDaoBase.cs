using System;

namespace News.DataLayer.SharedKernel
{
    /// <summary>
    /// Defines the application data access object base.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class AppDaoBase<TKey> : IAppDao<TKey>
        where TKey : IComparable
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public virtual TKey Id { get; set; }
    }
}
