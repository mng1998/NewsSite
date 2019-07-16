using News.DataLayer.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace News.DataLayer.DAO
{
    /// <summary>
    /// Defines the category table model.
    /// </summary>
    /// <seealso cref="AppDaoBase{long}"/>
    [Table("CATEGORIES")]
    public class CategoryDAO : AppDaoBase<long>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; } 
    }
}
