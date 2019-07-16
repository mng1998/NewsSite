using System;

namespace News.DataLayer.SharedKernel
{
    /// <summary>
    /// Defines the application data access object.
    /// </summary>
    /// <typeparam name="TKey">The TKey.</typeparam>
    public interface IAppDao<TKey>
        where TKey: IComparable
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        TKey Id { get; set; }
    }
}
