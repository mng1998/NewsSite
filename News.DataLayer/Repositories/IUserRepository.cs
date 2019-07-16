using News.DataLayer.DAO;
using News.DataLayer.SharedKernel;

namespace News.DataLayer.Repositories
{
    /// <summary>
    /// Provides the extra methods for UserRepository.
    /// </summary>
    /// <seealso cref="IGenericRepository{long, DataLayer.DAO.UserDAO}"/>
    public interface IUserRepository : IGenericRepository<long, UserDAO>
    {
    }
}
