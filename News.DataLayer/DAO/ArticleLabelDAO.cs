using News.DataLayer.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace News.DataLayer.DAO
{
    /// <summary>
    /// Defines the article label table model.
    /// </summary>
    /// <seealso cref="AppDaoBase{long}"/>
    [Table("ARTICLELABLES")]
    public class ArticleLabelDAO : AppDaoBase<long>
    {
        /// <summary>
        /// Gets or sets the article identifier.
        /// </summary>
        /// <value>
        /// The article identifier.
        /// </value>
        public long ArticleId { get; set; }

        /// <summary>
        /// Gets or sets the label identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long LabelId { get; set; }
    }
}
