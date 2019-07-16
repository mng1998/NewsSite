using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Web.Models
{
    public class Comment
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ArticleId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public Article Article { get; set; }
    }
}
