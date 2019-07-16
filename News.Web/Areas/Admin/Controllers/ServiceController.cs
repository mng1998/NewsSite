using Microsoft.AspNetCore.Mvc;
using News.Core.Context;
using News.DataLayer.DAO;
using News.Utility;
using System.Linq;

namespace News.Web.Areas.Admin.Controllers
{
    public class ServiceController : AdminControllerBase
    {
        [HttpGet]
        public JsonResult GetEntities()
        {
            var data = General.GetClasses(GlobalContext.Instance.EntityNamespace);
            var result = data.Select(n => n.Name).Where(m=> !GlobalContext.Instance.DisappearTable.Contains(m));
            return Json(new { Success = true, table = result });
        }
    }
}
