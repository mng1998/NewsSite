using News.DataLayer.DAO;
using News.DataLayer.SharedKernel;

namespace News.DataLayer.Repositories
{
    /// <summary>
    /// Provides the methods to work with LabelDAO
    /// </summary>
    /// <seealso cref="GenericRepositoryBase{long, DataLayer.DAO.LabelDAO}"/>
    /// <seealso cref="ILabelRepository"/>
    public class LabelRepository : GenericRepositoryBase<long, LabelDAO>, ILabelRepository
    {
        /// <summary>
        /// Initialize the new instance <seealso cref="CategoryRepository"/> class.
        /// </summary>
        /// <param name="dbFactory">The db factory.</param>
        public LabelRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
