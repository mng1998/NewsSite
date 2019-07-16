using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using News.BusinessLayer.Services;
using News.Utility;

namespace News.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminControllerBase
    {
        protected override string SelectedMenu => "Article";

        private readonly IArticleService service;

        public HomeController(IArticleService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View(service.ReadAll());
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            return View();
        }

        public IActionResult Post()
        {
            return View();
        }
        public IActionResult Widget()
        {
            return View(service.ReadAll());
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Chart()
        {
            return View();
        }
    }
}