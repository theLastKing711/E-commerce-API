using ECommerce.API.Data.IRepos;
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Data.Repos
{
  public class ProductRepository : BaseRepo<Product>, IProductRepository
  {

        public ProductRepository(DataContext context) : base(context)
        {
        }

        public async Task<Product> AddProduct(Product product)
        {
            var productModel = await this.Add(product);

            var productWithCategory = await this._context.Products.Include(x => x.Category)
                                                        .Where(x => x.Id == productModel.Id)
                                                        .FirstOrDefaultAsync();

            return productWithCategory;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var productWithCategory = await this._context.Products.Include(x => x.Category)
                                                        .Where(x => x.Id == product.Id)
                                                        .FirstOrDefaultAsync();

            productWithCategory.Path = product.Path ?? productWithCategory.Path;

            await this._context.SaveChangesAsync();

            var updatedProduct= await this._context.Products.Include(x => x.Category)
                                                        .Where(x => x.Id == product.Id)
                                                        .FirstOrDefaultAsync();

            return updatedProduct;
        }

        public async Task<Pagination<Product>> GetAllProducts(int pageNumber, int pageSize)
        {
            var productsModel =  this._context.Products
                                    .Include(product => product.Category)
                                    .OrderByDescending(x => x.CreatedAt);

            Pagination<Product> paginatedCategoriesModel = await Pagination<Product>.GetPaginatedData(productsModel, pageNumber, pageSize);


            return paginatedCategoriesModel;

        }

        public async Task<Product> GetProductById(int id)
        {
            var productModel = await this._context.Products.AsNoTracking()
                                                            .Include(product => product.Category)
                                                           .Where(e => e.Id == id)
                                                           .Select(x => new Product()
                                                           {
                                                               Id = x.Id,
                                                               Name = x.Name,
                                                               CategoryId = x.CategoryId,
                                                               Path = x.Path,
                                                               Price = x.Price,
                                                               CreatedAt = x.CreatedAt,
                                                               Category = new Category()
                                                               {
                                                                   Id = x.Category.Id,
                                                                   Name = x.Category.Name,
                                                                   CreatedAt = x.Category.CreatedAt,
                                                               }
                                                           })
                                                           .FirstOrDefaultAsync();

            return productModel;

        }

    }


}
