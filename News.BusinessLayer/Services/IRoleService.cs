using News.BusinessLayer.Models;
using News.BusinessLayer.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace News.BusinessLayer.Services
{
    /// <summary>
    /// Defines the extra methods for role service.
    /// </summary>
    /// <seealso cref="IDataService{long, BusinessLayer.Models.Role}"/>
    public interface IRoleService : IDataService<long, Role>
    {
    }
}
