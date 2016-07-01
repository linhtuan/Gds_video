using System;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;

namespace MvcCornerstone.Data.Extend
{
    public static class ObjectQueryHelper
    {
        public static ObjectQuery<T> ToObjectQuery<T>(this IQueryable<T> query) where T : class
        {
            var objectQuery = query as ObjectQuery<T>;
            if (objectQuery != null)
                return objectQuery;

            var dbQuery = query as DbQuery<T>;
            if (dbQuery != null)
            {
                var internalQuery = dbQuery.GetType()
                                           .GetProperty("InternalQuery", BindingFlags.Instance | BindingFlags.NonPublic)
                                           .GetValue(dbQuery, null);

                if (internalQuery != null)
                {
                    objectQuery = internalQuery.GetType()
                                               .GetProperty("ObjectQuery")
                                               .GetValue(internalQuery, null) as ObjectQuery<T>;

                    return objectQuery;
                }
            }

            throw new ArgumentException("IQueryable must be an ObjectQuery or the result of DbQuery");
        }
    }
}
