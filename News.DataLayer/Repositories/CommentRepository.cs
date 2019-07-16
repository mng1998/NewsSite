using News.DataLayer.DAO;
using News.DataLayer.SharedKernel;

namespace News.DataLayer.Repositories
{
    /// <summary>
    /// Provides the methods to work with CommentDAO
    /// </summary>
    /// <seealso cref="GenericRepositoryBase{long, DataLayer.DAO.CommentDAO}"/>
    /// <seealso cref="ICommentRepository"/>
    public class CommentRepository : GenericRepositoryBase<long, CommentDAO>, ICommentRepository
    {
        /// <summary>
        /// Initialize the new instance <seealso cref="CommentRepository"/> class.
        /// </summary>
        /// <param name="dbFactory">The db factory.</param>
        public CommentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        /// <summary>
        /// Edits a item.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void Edit(CommentDAO entity)
        {
        }
    }
}
