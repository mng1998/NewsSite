using News.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Web.Areas.Admin.Models
{
    public class ListIdentityUser
    {
        public List<UserViewModel> ListUser { get; set; } = new List<UserViewModel>();
    }
}
