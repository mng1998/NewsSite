using News.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Web.Areas.Admin.Models
{
    public class UserInfo : User
    {
        public string Roles { get; set; }
    }
}
