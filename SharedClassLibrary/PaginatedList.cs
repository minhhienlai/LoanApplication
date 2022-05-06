
namespace SharedClassLibrary
{
    [Serializable]
    public class PaginatedList<T>  // : List<T>
    {
        public int pageIndex { get; set; }
        public int totalPages { get; set; }
        public int totalCount { get; set; }
       
        public List<T> list { get; set; }
        public PaginatedList() {
        //    this.list = new List<T>();
        }

        private PaginatedList(IEnumerable<T> items, int count, int pageIndex, int pageSize)
        {
            this.pageIndex = pageIndex;
            totalCount = count;
            totalPages = (int)Math.Ceiling(count / (double)pageSize);

            // this.AddRange(items);
            this.list = new List<T>();
            this.list.AddRange(items);
        }

        public bool hasPreviousPage => pageIndex > 1;

        public bool hasNextPage => pageIndex < totalPages;

        public static PaginatedList<T> SliceAndCreate(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            IEnumerable<T> items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
        public static PaginatedList<T> Create(IEnumerable<T> source, int count, int pageIndex, int pageSize)
        {
            return new PaginatedList<T>(source, count, pageIndex, pageSize);
        }

    }
}
