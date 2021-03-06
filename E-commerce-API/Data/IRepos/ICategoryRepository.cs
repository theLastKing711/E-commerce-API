using ECommerce.API.Dtos;
using ECommerce.API.Models;

namespace ECommerce.API.Data.IRepos
{
  public interface ICategoryRepository: IBaseRepo<Category>
  {
    Task<CategoryWithProductsDto> CategoryProducts(int id);

    Task<Pagination<Category>> getCategoriesPaginated(int pageNumber, int pageSize);

    Task<Pagination<Product>> getCategoryProductsPaginated(int id, int pageNumber, int pageSize);

  }
}
