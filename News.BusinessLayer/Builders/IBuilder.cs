using System;
using System.Collections.Generic;
using System.Text;

namespace News.BusinessLayer.Builders
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestination"></typeparam>
    public interface IBuilder<TSource, TDestination>
        where TSource : class
        where TDestination : class
    {
        /// <summary>
        /// Builds an instance.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        TDestination Build(TSource source);

        /// <summary>
        /// Builds back.
        /// </summary>
        /// <param name="destination">The destination.</param>
        /// <returns></returns>
        TSource BuildBack(TDestination destination);
    }
}
