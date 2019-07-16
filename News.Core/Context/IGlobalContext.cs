using System;
using System.Collections.Generic;
using System.Text;

namespace News.Core.Context
{
    /// <summary>
    /// Defines global context.
    /// </summary>
    public interface IGlobalContext
    {
        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the entity namespace.
        /// </summary>
        /// <value>
        /// The entity namespace.
        /// </value>
        string EntityNamespace { get; set; }

        /// <summary>
        /// Gets or sets the disappear table.
        /// </summary>
        /// <value>
        /// The disappear table.
        /// </value>
        IEnumerable<string> DisappearTable { get; set; }
    }
}
