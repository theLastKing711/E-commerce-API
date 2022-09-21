using ECommerce.API.Dtos.Product;
using ECommerce.API.Models;

namespace ECommerce.API.Data.IRepos
{
    public interface IProductRepository : IBaseRepo<Product>
    {
        Task<Product> AddProduct(Product product);

        Task<Pagination<Product>> GetAllProducts(int pageNumber, int pageSize);

        Task<Product> GetProductById(int id);

        Task<Product> UpdateProduct(Product product);

        Task<Product> AddReview(int id, Review review);

        Task<bool> DeleteReview(int reviewId);

        Task<Review> UpdateReview(int id, Review review);

        Task<Discount> AddDiscount(int id, Discount discount);

        Task<bool> DeleteDiscount(int discountId);

        Task<IEnumerable<TopSellerProductDto>> GetTopSellers();


        #region appUser

        Task<Product> getAppUserProductById(int id);

        Task<IEnumerable<Product>> getProductsUsingIds(List<int> ids);

        #endregion appUser


    }
}
