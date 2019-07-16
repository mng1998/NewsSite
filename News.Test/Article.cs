using Microsoft.VisualStudio.TestTools.UnitTesting;
using News.DataLayer.DAO;
using News.DataLayer.Repositories;
using System;
using System.Linq;

namespace News.Test
{
    [TestClass]
    public class Article : TestBase
    {
        private readonly IArticleRepository articleRepo = new ArticleRepository(dbFactory);

        [TestMethod]
        public void GetAll_Successfully()
        {
            var data = this.articleRepo.GetAll();
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void Add_Successfully()
        {
            var data = new ArticleDAO
            {
               
                CategoryId = 1,
                Title = "Test",
                CreatedDate = DateTime.Now
            };
            var result = this.articleRepo.Add(data);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Update_Successfully()
        {
            var data = this.articleRepo.GetAll().ToList();
            var material = data.Last();
            material.Title = "Unit test has been edited it";
            articleRepo.Edit(material);
        }

        [TestMethod]
        public void Remove_Successfully()
        {
            var data = this.articleRepo.GetAll().ToList();
            var material = data.LastOrDefault();
            this.articleRepo.Remove(material.Id);
        }

        [TestMethod]
        public void Search()
        {
            const string title = "How";
            var data = this.articleRepo.GetByTitle(title);
            Assert.IsNotNull(data);
        }
    }
}
