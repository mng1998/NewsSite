using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace News.Web.Controllers
{
    public class ControllerBase : Controller
    {
        protected virtual string SelectedMenu { get; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.SelectedMenu = this.SelectedMenu;
            base.OnActionExecuting(context);
        }
        
    }
}