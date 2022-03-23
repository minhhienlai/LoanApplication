﻿
namespace SharedClassLibrary
{
    public class PaginatedList<T>// : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }
       
        public List<T> List { get; private set; }
        public PaginatedList() { }

        public PaginatedList(IEnumerable<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalCount = count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            // this.AddRange(items);
            this.List = new List<T>();
            this.List.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public static PaginatedList<T> SliceAndCreate(IList<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            IEnumerable<T> items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
        public static PaginatedList<T> Create(IList<T> source, int count, int pageIndex, int pageSize)
        {
            return new PaginatedList<T>(source, count, pageIndex, pageSize);
        }

    }
}
