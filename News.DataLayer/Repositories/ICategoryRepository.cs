using News.DataLayer.DAO;
using News.DataLayer.SharedKernel;

namespace News.DataLayer.Repositories
{
    /// <summary>
    /// Provides the extra methods for CategoryRepository.
    /// </summary>
    /// <seealso cref="IGenericRepository{long, DataLayer.DAO.CategoryDAO}"/>
    public interface ICategoryRepository: IGenericRepository<long, CategoryDAO>
    {
    }
}
