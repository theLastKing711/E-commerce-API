using ECommerce.API.Dtos.Discount;
using ECommerce.API.Dtos.Shared;
using ECommerce.API.Models;

namespace ECommerce.API.Data.IRepos
{
    public interface IDiscountRepository : IBaseRepo<Discount>
    {


        Task<Discount> AddDiscount(Discount discount);

        Task<Discount> UpdateDiscount(Discount Discount);

        Task<Pagination<Discount>> getDiscountsPaginated(int pageNumber, int pageSize, string query, string active, string direction);

        Task<bool> DeleteDiscounts(List<int> ids);

        Task<string> CheckIfDiscountDuplicated(int productId, DateTime startDate, DateTime endDate);

    }
}
