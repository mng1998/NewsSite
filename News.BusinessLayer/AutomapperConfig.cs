using AutoMapper;
using News.BusinessLayer.Models;
using News.DataLayer.DAO;

namespace News.BusinessLayer
{
    /// <summary>
    /// Configuration the automapper.
    /// </summary>
    public class AutomapperConfig
    {
        /// <summary>
        /// Initializes
        /// </summary>
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, CategoryDAO>();
                cfg.CreateMap<Comment, CommentDAO>();
                cfg.CreateMap<Article, ArticleDAO>();
                cfg.CreateMap<Role, RoleDAO>();
                cfg.CreateMap<User, UserDAO>();
            });
        }
    }
}
