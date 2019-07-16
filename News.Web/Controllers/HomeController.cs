using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using News.BusinessLayer.Services;
using Microsoft.EntityFrameworkCore;
using News.Web.Data;
using News.Web.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace News.Web.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewBag.RecentArticles = ListRecent(4);
            ViewBag.NewArticle = ListNewArticles(4);
            ViewBag.NewTag = ListTag(15);
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var article = from s in _context.Articles
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                article = article.Where(s => s.Title.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    article = article.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    article = article.OrderBy(s => s.CreatedDate);
                    break;

            }

            int pageSize = 3;
            return View(await PaginatedList<Models.Article>.CreateAsync(article.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        #region Function
        public List<Models.Article> ListRecent(int top)
        {

            return _context.Articles.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public List<Models.Tag> ListTag(int top)
        {
            return _context.Labels.OrderByDescending(x => x.Id).Take(top).ToList();
        }
        public List<Models.Article> ListNewArticles(int top)
        {
            return _context.Articles.OrderByDescending(x => x.CreatedDate).Take(top).ToList();

        }
        public List<string> ListName(string keyword)
        {
            return _context.Articles.Where(x => x.Title.Contains(keyword)).Select(x => x.Title).ToList();
        }
        public List<Models.Article> ListFeatureArticles(int top)
        {
            return _context.Articles.Where(x => x.Highlight != true && x.CreatedDate > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<Models.Article> ListRelatedArticles(long articlesId)
        {
            var product = _context.Articles.Find(articlesId);
            return _context.Articles.Where(x => x.Id != articlesId && x.CategoryId == product.CategoryId).ToList();
        }


        public Models.Article ViewDetail(long id)
        {
            return _context.Articles.Find(id);
        }
        #endregion


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult SendMail(string name, string sub, string msg, string email)
        {
            var mess = new MimeMessage();
            mess.From.Add(new MailboxAddress(email));
            mess.To.Add(new MailboxAddress("uyenphuong1898@gmail.com"));
            mess.Subject = name;
            mess.Body = new TextPart("html")
            {
                Text = "From:" + name + "<br>" + "contact information" + email + "<br>" + "Message: " + msg
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587);
                client.Authenticate("uyenphuong1898@gmail.com", "0967637344");

                client.Send(mess);
                client.Disconnect(false);
            }
            return View("Contact");
        }
        public IActionResult Contact()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public List<Models.Article> ListTravelArticle(int top)
        {
            return _context.Articles.Where(x => x.CategoryId == 1).ToList();
        }
        public IActionResult Travel()
        {
            ViewBag.TravelArticle = ListTravelArticle(6);
            return View();
        }
        public List<Models.Article> ListFoodArticle(int top)
        {
            return _context.Articles.Where(x => x.CategoryId == 2).ToList();
        }
        public IActionResult Food()
        {
            ViewBag.FoodArticle = ListFoodArticle(6);
            return View();
        }

        public List<Models.Article> ListLifeStyleArticle(int top)

        {
            return _context.Articles.Where(x => x.CategoryId == 8).ToList();
        }

        public IActionResult LifeStyle()

        {
            ViewBag.TravelArticle = ListLifeStyleArticle(6);
            return View();
        }
    }
}
