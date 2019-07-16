using News.DataLayer.DAO;
using News.DataLayer.SharedKernel;

namespace News.DataLayer.Repositories
{
    /// <summary>
    /// Provides the extra methods for CommentRepository.
    /// </summary>
    /// <seealso cref="IGenericRepository{long, DataLayer.DAO.CommentDAO}"/>
    public interface ICommentRepository : IGenericRepository<long, CommentDAO>
    {
    }
}
