namespace School.Application.Base.Wrapper
{
    public class PaginatedResult<T>
    {
        public List<T> Data { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => PageSize < TotalPages;

        public PaginatedResult()
        {

        }
        public PaginatedResult(List<T> Data, int CurrentPage, int PageSize, int TotalCount)
        {
            this.Data = Data;
            this.CurrentPage = CurrentPage;
            this.PageSize = PageSize;
            this.TotalCount = TotalCount;
            this.TotalPages = (int)(Math.Ceiling(TotalCount / (double)PageSize));
        }

    }
}
