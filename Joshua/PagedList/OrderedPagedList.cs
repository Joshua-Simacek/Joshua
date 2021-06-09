using System.Collections.Generic;
using System.Linq;

namespace Joshua.PagedList
{
    public class OrderedPagedList<T> : PagedList<T>, IOrderedPagedList<T>
    {
        public string CurrentSort { get; }
        public Order CurrentOrder { get; }

        public OrderedPagedList(IQueryable<T> source, string orderBy, Order orderDirection = Order.Ascending, int? page = null, int pageSize = 10)
            : base(source.OrderBy(orderBy, orderDirection), page, pageSize)
        {
            CurrentSort = orderBy;
            CurrentOrder = orderDirection;
        }

        public OrderedPagedList(IEnumerable<T> source, string orderBy, Order orderDirection = Order.Ascending, int? page = null, int pageSize = 10)
            : this(source.AsQueryable<T>(), orderBy, orderDirection, page, pageSize) { }
    }
}
