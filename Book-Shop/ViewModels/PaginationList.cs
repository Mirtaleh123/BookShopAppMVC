namespace Book_Shop.ViewModels
{
    public sealed class PaginationList<T>
    {
        public List<T> Items { get; }
        public int PageIndex { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }

        public PaginationList(List<T> items, int count, int pageIndex, int pageSize)
        {
            Items = items;
            TotalCount = count;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
    }
}

