using System;
using System.Collections.Generic;

namespace News.Core.Context
{
    /// <summary>
    /// Provides shared configuration.
    /// </summary>
    /// <seealso cref="Dictionary{string, object}"/>
    /// <seealso cref="IGlobalContext"/>
    public class GlobalContext : Dictionary<string, object>, IGlobalContext
    {
        /// <summary>
        /// The instance.
        /// </summary>
        private static readonly Lazy<GlobalContext> instance = new Lazy<GlobalContext>(() => new GlobalContext(), true);

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static GlobalContext Instance => instance.Value;

        /// <summary>
        /// Initialize new instance of <seealso cref="GlobalContext"/> class.
        /// </summary>
        private GlobalContext()
        {
        }

        /// <summary>
        /// The connection string key.
        /// </summary>
        private const string ConnectionStringKey = nameof(ConnectionStringKey);

        /// <summary>
        /// The entity namespace key.
        /// </summary>
        private const string EntityNamespaceKey = nameof(EntityNamespaceKey);

        /// <summary>
        /// The dont show key.
        /// </summary>
        private const string DisappearTableKey = nameof(DisappearTableKey);

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        public string ConnectionString
        {
            get
            {
                return Convert.ToString(this[ConnectionStringKey]);
            }
            set
            {
                this[ConnectionStringKey] = value;
            }
        }

        /// <summary>
        /// Gets or sets the entity namespace.
        /// </summary>
        /// <value>
        /// The entity namespace.
        /// </value>
        public string EntityNamespace
        {
            get { return Convert.ToString(this[EntityNamespaceKey]); }
            set
            {
                this[EntityNamespaceKey] = value;
            }
        }

        /// <summary>
        /// Gets or sets the disappear table.
        /// </summary>
        /// <value>
        /// The disappear table.
        /// </value>
        public IEnumerable<string> DisappearTable
        {
            get { return this[DisappearTableKey] as IEnumerable<string>; }
            set { this[DisappearTableKey] = value; }
        }
    }
}
