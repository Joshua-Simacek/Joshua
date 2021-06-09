using System;
using System.Collections.Generic;
using System.Linq;

namespace Joshua.PagedList
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public int TotalCount { get; }
        public int PageCount { get; }
        public int PageSize { get; }
        public int CurrentPage { get; }

        /// <param name="source">original collection of data</param>
        /// <param name="page">The current "Page" out of the total amount of pages</param>
        /// <param name="pageSize">If Pagesize is less than 0 the entire result set will be returned</param>
        public PagedList(IQueryable<T> source, int? page, int pageSize = 10)
        {
            TotalCount = source.Count();
            PageCount = pageSize > 0 ? (int)Math.Ceiling((decimal)TotalCount / (decimal)pageSize) : (pageSize < 0 ? 1 : 0);
            PageSize = pageSize;
            CurrentPage = page ?? 1;

            this.AddRange(pageSize < 0 ? source.ToList() : source.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList());
        }

        public PagedList(IEnumerable<T> source, int? page, int pageSize = 10) : this(source.AsQueryable<T>(), page, pageSize) { }

    }
}
