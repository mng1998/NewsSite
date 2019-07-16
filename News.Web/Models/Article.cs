using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Web.Models
{
    public class Article
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Content1 { get; set; }
        public string Content2 { get; set; }
        public string Picture { get; set; }
        public string ImgContent { get; set; }
        public string ImgContent1 { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Link { get; set; }
        public int TotalLike { get; set; }
        public string Summary { get; set; }
        public bool Highlight { get; set; }
        public string Author { get; set; }

        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
