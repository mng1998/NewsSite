using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace News.Utility
{
    public class General
    {
        /// <summary>
        /// Gets classes by namespace.
        /// </summary>
        /// <param name="namespace">The namespace.</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetClasses(string @namespace)
        {
            return  AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(t => t.GetTypes())
                       .Where(t => t.IsClass && string.Equals(t.Namespace, @namespace));
        }
    }
}
