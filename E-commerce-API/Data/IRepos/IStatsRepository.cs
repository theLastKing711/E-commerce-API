using ECommerce.API.Dtos;
using ECommerce.API.Dtos.Category;
using ECommerce.API.Dtos.Product;
using ECommerce.API.Dtos.Stats;
using ECommerce.API.Models;

public interface IStatsRepository
{
    Task<Tuple<List<Product>, List<Category>>> getSearchedProductsAndCategories(string query);

    Task<StatsDto> GetStats();

    Task<IEnumerable<YearlySalesDto>> GetYearlySales();

    Task<IEnumerable<TopSellerProductDto>> GetTopSellingProducts();

    Task<IEnumerable<TopSellerCategoryDto>> GetTopSellingCategories();


}