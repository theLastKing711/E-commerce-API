using ECommerce.API.Dtos.Category;
using ECommerce.API.Dtos.Shared;
using ECommerce.API.Models;

namespace ECommerce.API.Data.IRepos
{
    public interface ICategoryRepository : IBaseRepo<Category>
    {
        Task<CategoryWithProductsDto> CategoryProducts(int id);

        Task<Category> UpdateCategory(Category category);

        Task<Pagination<Category>> getCategoriesPaginated(int pageNumber, int pageSize);

        Task<Pagination<Product>> getCategoryProductsPaginated(int id, int pageNumber, int pageSize);

        Task<Pagination<Product>> GetAppUserCategoryProducts(int id, Filter filter, ProductPagination pagination);

        Task<IEnumerable<Product>> GetCategoryBestSellers(int id);

    }
}
