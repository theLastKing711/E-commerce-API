using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Models
{
    public class Pagination<T> where T : BaseEntity
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public int TotalCount { get; set; }

        public IEnumerable<T> Data { get; set; }
        

        public Pagination(IEnumerable<T> data, int pageNumber, int pageSize,int totalCount)
        {
            this.Data = data;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
        }


        public async static Task<Pagination<T>> GetPaginatedData(IQueryable<T> data, int pageNumber, int pageSize)
        {
            var paginatedList = await data.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            var totalCount = await data.CountAsync();

            var paginatedData = new Pagination<T>(paginatedList, pageNumber, pageSize, totalCount);


            return paginatedData;

        }

    }
}
