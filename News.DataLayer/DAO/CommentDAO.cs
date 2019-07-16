using News.DataLayer.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace News.DataLayer.DAO
{
    /// <summary>
    /// Defines the comment table model.
    /// </summary>
    /// <seealso cref="AppDaoBase{long}"/>
    [Table("COMMENTS")]
    public class CommentDAO : AppDaoBase<long>
    {
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
