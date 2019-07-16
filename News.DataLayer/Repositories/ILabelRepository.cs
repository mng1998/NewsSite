using News.DataLayer.DAO;
using News.DataLayer.SharedKernel;

namespace News.DataLayer.Repositories
{
    /// <summary>
    /// Provides the extra methods for LabelRepository.
    /// </summary>
    /// <seealso cref="IGenericRepository{long, DataLayer.DAO.LabelDAO}"/>
    public interface ILabelRepository : IGenericRepository<long, LabelDAO>
    {
    }
}
