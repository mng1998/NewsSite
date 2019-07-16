using News.DataLayer.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace News.DataLayer.DAO
{
    /// <summary>
    /// Defines the article table model.
    /// </summary>
    /// <seealso cref="AppDaoBase{long}"/>
    [Table("ARTICLES")]
    public class ArticleDAO : AppDaoBase<long>
    {
        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public long CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the picture.
        /// </summary>
        /// <value>
        /// The picture.
        /// </value>
        ///  public string Content1 { get; set; }
        public string Content2 { get; set; }
        public string ImgContent { get; set; }
        public string ImgContent1 { get; set; }
        public string Picture { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the modified date.
        /// </summary>
        /// <value>
        /// The modified date.
        /// </value>
        /// <remarks>
        /// Allow null.
        /// </remarks>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>
        /// The summary.
        /// </value>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the highlight.
        /// </summary>
        /// <value>
        /// The highlight.
        /// </value>
        public bool Highlight { get; set; }
        public string Author { get; set; }
        public int TotalLike { get; set; }
       
       
       
    }
}
