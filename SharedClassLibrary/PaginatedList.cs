﻿
namespace SharedClassLibrary
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public PaginatedList() { }

        public PaginatedList(IEnumerable<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public static PaginatedList<T> Create(IList<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            IEnumerable<T> items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}