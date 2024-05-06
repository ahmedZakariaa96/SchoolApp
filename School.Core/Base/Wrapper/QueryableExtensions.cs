using Microsoft.EntityFrameworkCore;

namespace School.Application.Base.Wrapper
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize)
            where T : class
        {
            if (source == null)
            {
                return new PaginatedResult<T>(new List<T>(), pageNumber, pageSize, 0);
            }

            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : pageSize;

            int totalCount = await source.CountAsync();
            if (totalCount == 0) return new PaginatedResult<T>(new List<T>(), pageNumber, pageSize, totalCount);

            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedResult<T>(items, pageNumber, pageSize, totalCount);
        }


    }


}
