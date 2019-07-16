using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace News.Web.ViewModels
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public long ArticleId { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
