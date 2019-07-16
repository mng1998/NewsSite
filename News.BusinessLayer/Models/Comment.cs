
using System;

namespace News.BusinessLayer.Models
{
    /// <summary>
    /// Define comment.
    /// </summary>
    public class Comment 
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the article identifier.
        /// </summary>
        /// <value>
        /// The article identifier.
        /// </value>
        public long ArticleId { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
