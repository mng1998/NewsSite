using News.BusinessLayer.Models;
using News.BusinessLayer.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace News.BusinessLayer.Services
{
    /// <summary>
    /// Defines the extra methods for user service.
    /// </summary>
    /// <seealso cref="IDataService{long, BusinessLayer.Models.User}"/>
    public interface IUserService : IDataService<long, User>
    {
    }
}
