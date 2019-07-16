using News.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Web.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int airticle_count { get; set; }
        public int comments_count { get; set; }
        public int likes_count { get; set; }
    }
}
