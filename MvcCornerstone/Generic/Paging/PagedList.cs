using System;
using System.Collections.Generic;

namespace MvcCornerstone.Generic.Paging
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList(IEnumerable<T> source)
        {
            AddRange(source);
            PageIndex = 1;
            PageSize = Count;
            ItemCount = Count;
            PageCount = 1;
        }

        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int itemCount)
        {
            ItemCount = itemCount;
            PageCount = (int)Math.Ceiling((double)itemCount / pageSize);

            PageIndex = pageIndex;
            PageSize = pageSize;

            AddRange(source);
        }

        #region IPagedList<T> Members

        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public int ItemCount { get; private set; }

        public int PageCount { get; private set; }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }

        public bool HasNextPage
        {
            get { return (PageIndex + 1 < PageCount); }
        }

        #endregion IPagedList<T> Members
    }
}
