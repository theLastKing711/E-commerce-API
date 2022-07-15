using ECommerce.API.Models;

namespace ECommerce.API.Data.IRepos
{
  public interface IProductRepository : IBaseRepo<Product>
  {
        Task<Product> AddProduct(Product product);

        Task<Pagination<Product>> GetAllProducts(int pageNumber, int pageSize);

        Task<Product> GetProductById(int id);


        Task<Product> UpdateProduct(Product product);

  }
}
