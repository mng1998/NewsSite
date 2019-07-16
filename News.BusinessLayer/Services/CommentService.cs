using System.Collections.Generic;
using AutoMapper;
using News.BusinessLayer.Models;
using News.DataLayer.DAO;
using News.DataLayer.Repositories;

namespace News.BusinessLayer.Services
{
    public class CommentService : ICommentService
    {
        /// <summary>
        /// The comment repository.
        /// </summary>
        private readonly ICommentRepository commentRepo;

        /// <summary>
        /// Initialize the new instance <seealso cref="CommentService"/> class.
        /// </summary>
        /// <param name="commentRepo">The comment repository.</param>
        public CommentService(ICommentRepository commentRepo)
        {
            this.commentRepo = commentRepo;
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public long Create(Comment model)
        {
            var data = Mapper.Map<Comment, CommentDAO>(model);
            return this.commentRepo.Add(data);
        }

        // <summary>
        /// Deletes an instance.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Delete(long key)
        {
            this.commentRepo.Remove(key);
        }

        /// <summary>
        /// Reads all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Comment> ReadAll()
        {
            var data = this.commentRepo.GetAll();
            var result = Mapper.Map<IEnumerable<CommentDAO>, IEnumerable<Comment>>(data);
            return result;
        }

        /// <summary>
        /// Reads by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public Comment ReadByKey(long key)
        {
            var data = this.commentRepo.FindById(key);
            var result = Mapper.Map<CommentDAO, Comment>(data);
            return result;
        }

        /// <summary>
        /// Updates an instance.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(Comment model)
        {
        }
    }
}
