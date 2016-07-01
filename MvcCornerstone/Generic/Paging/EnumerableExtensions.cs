using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcCornerstone.Generic.Paging
{
    public static class EnumerableExtensions
    {
        public static IPagedList<T> ToPagedQueryable<T>(this IQueryable<T> enumerable, int pageIndex, int pageSize, int itemCount)
        {
            var query = enumerable.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return query.ToPaged(pageIndex - 1, pageSize, itemCount);
        }

        public static IPagedList<T> ToPagedEnumerable<T>(this IEnumerable<T> enumerable, int pageIndex, int pageSize, int itemCount)
        {
            var query = enumerable.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return query.ToPaged(pageIndex - 1, pageSize, itemCount);
        }

        public static IPagedList<T> ToPaged<T>(this IEnumerable<T> enumerable, int pageIndex, int pageSize, int itemCount)
        {
            return new PagedList<T>(enumerable, pageIndex - 1, pageSize, itemCount);
        }
    }
}
