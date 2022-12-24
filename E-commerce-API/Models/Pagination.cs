using ECommerce.API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Models
{
    public class Pagination<T>
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public int TotalCount { get; set; }

        public IEnumerable<T> Data { get; set; }

        public Pagination(IEnumerable<T> data, int pageNumber, int pageSize, int totalCount)
        {
            this.Data = data;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
        }

        public static IEnumerable<T> Paginate(IEnumerable<T> data, int pageNumber, int pageSize)
        {
            return data.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public async static Task<Pagination<T>> GetPaginatedData(IQueryable<T> data, int pageNumber, int pageSize)
        {

            List<T> paginatedList = null;

            var totalCount = await data.CountAsync();


            if (pageNumber != 0 && pageSize != 0)
            {
                paginatedList = await data.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            else
            {
                paginatedList = await data.ToListAsync();
            }


            var paginatedData = new Pagination<T>(paginatedList, pageNumber, pageSize, totalCount);

            return paginatedData;

        }

        public bool isPageSizeDataGreaterThanData(int totalCount, int pageSize, int pageNumber)
        {
            return totalCount > pageSize * pageNumber;
        }

    }
}
