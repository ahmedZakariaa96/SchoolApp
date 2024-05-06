using School.Application.Base.Shared;

namespace School.Application.Base.Wrapper
{
    public class PaginatedRquest
    {

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
        public OrderType? OrderBy { get; set; }

    }


}
