using Microsoft.AspNetCore.Identity;

namespace News.Web.ViewModels
{
    public class UserViewModel
    {
        public IdentityUser User { get; set; }

        public string RoleName { get; set; }
    }
}