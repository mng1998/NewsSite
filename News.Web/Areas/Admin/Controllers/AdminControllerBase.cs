using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using News.Utility;

namespace News.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public abstract class AdminControllerBase : Controller
    {
        protected virtual string SelectedMenu { get; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.SelectedMenu = this.SelectedMenu;
            base.OnActionExecuting(context);
        }
    }
}