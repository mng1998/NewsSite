using News.BusinessLayer.Models;
using News.BusinessLayer.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace News.BusinessLayer.Services
{
    /// <summary>
    /// Defines the extra methods for comment service.
    /// </summary>
    /// <seealso cref="IDataService{long, BusinessLayer.Models.Comment}"/>
    public interface ICommentService : IDataService<long, Comment>
    {
    }
}
