using News.BusinessLayer.Models;
using News.BusinessLayer.Shared;

namespace News.BusinessLayer.Services
{
    /// <summary>
    /// Defines the extra methods for category service.
    /// </summary>
    /// <seealso cref="IDataService{long, BusinessLayer.Models.Category}"/>
    public interface ICategoryService : IDataService<long, Category>
    {
    }
}
