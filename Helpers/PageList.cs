using System;
using System.Collections.Generic;
using System.Linq;

namespace Water_Bill.Helpers
{
    public class PageList<T>:List<T>
    {
        public int CurrentPage { get; set; }

        public int TotalPage { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public PageList(IEnumerable<T> items, int pageNumber, int pageSize, int count )
        {
            AddRange(items);
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalCount = count;
            TotalPage = (int) Math.Ceiling(TotalCount / (double) pageSize);
        }

        public static PageList<T> GetPage(IEnumerable<T> source, int pageNum, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip( (pageNum - 1) * pageSize).Take(pageSize);

            return new PageList<T>(items, pageNum, pageSize, count);
        }
    }
}
