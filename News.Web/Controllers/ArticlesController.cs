using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using News.Web.Data;
using News.Web.Models;
using News.Web.ViewModels;

namespace News.Web.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Articles
        public async Task<IActionResult> Index(string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewBag.RecentArticles = ListRecent(4);
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

            var book = from b in _context.Articles
                           select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                book = book.Where(s => s.Title.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    book = book.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    book = book.OrderBy(s => s.CreatedDate);
                    break;               
                default:
                    book = book.OrderBy(s => s.Author);
                    break;
            }

            int pageSize = 4;
            return View(await PaginatedList<Article>.CreateAsync(book.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        #region Function
        public int GetArticleId()
        {
            return 0;
        }
        public List<Models.Article> ListRecent(int top)
        {

            return _context.Articles.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<Models.Article> ListRecentByCategory(int top)
        {

            return _context.Articles.Where(x => x.CategoryId == x.Category.Id).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        #endregion

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            ViewBag.RecentbyCate = ListRecentByCategory(4);
            ViewBag.RecentArticles = ListRecent(6);
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

       
    }
}
