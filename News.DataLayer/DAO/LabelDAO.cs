using News.DataLayer.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace News.DataLayer.DAO
{
    /// <summary>
    /// Defines the label table model.
    /// </summary>
    /// <seealso cref="AppDaoBase{long}"/>
    [Table("LABELS")]
    public class LabelDAO : AppDaoBase<long>
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
        /// The value.
        /// </value>
        public string Description { get; set; }
    }
}
