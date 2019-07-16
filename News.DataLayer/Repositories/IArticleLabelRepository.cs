using News.DataLayer.DAO;
using News.DataLayer.SharedKernel;

namespace News.DataLayer.Repositories
{
    /// <summary>
    /// Provides the extra methods for ArticleLabelRepository.
    /// </summary>
    /// <seealso cref="IGenericRepository{long, DataLayer.DAO.ArticleLabelDAO}"/>
    public interface IArticleLabelRepository : IGenericRepository<long, ArticleLabelDAO>
    {
    }
}
