using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Web.ViewModels
{
    public class ArticleViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Link { get; set; }
        public string Summary { get; set; }
        public bool Highlight { get; set; }
        public string Author { get; set; }

    }
}
