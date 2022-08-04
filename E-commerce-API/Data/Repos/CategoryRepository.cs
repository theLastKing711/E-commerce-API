using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos.Category;
using ECommerce.API.Dtos.Product;
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Data.Repos
{
    public class CategoryRepository : BaseRepo<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }


        public async Task<Pagination<Category>> getCategoriesPaginated(int pageNumber, int pageSize)
        {
            var categoriesModel = await this.GetAll();

            Pagination<Category> paginatedCategoriesModel = await Pagination<Category>.GetPaginatedData(categoriesModel, pageNumber, pageSize);

            return paginatedCategoriesModel;

        }


        public async Task<Pagination<Product>> getCategoryProductsPaginated(int id, int pageNumber, int pageSize)
        {
            var categoryProductsModel = this._context.Products
                                                    .Include(product => product.Category)
                                                    .Select(x => new Product()
                                                    {
                                                        Id = x.Id,
                                                        CreatedAt = x.CreatedAt,
                                                        Name = x.Name,
                                                        CategoryId = x.CategoryId,
                                                        Path = x.Path,
                                                        Price = x.Price,
                                                        Category = new Category()
                                                        {
                                                            Id = x.Category.Id,
                                                            Name = x.Category.Name,
                                                            CreatedAt = x.CreatedAt
                                                        }

                                                    })
                                                    .Where(x => x.CategoryId == id);

            Pagination<Product> paginatedCategoryProducts = await Pagination<Product>.GetPaginatedData(categoryProductsModel, pageNumber, pageSize);


            return paginatedCategoryProducts;

        }


        public async Task<CategoryWithProductsDto> CategoryProducts(int id)
        {
            var categoryWithProductsDto = await this._context.Categories.Include(x => x.Products)
                                    .AsNoTracking()
                                    .Where(x => x.Id == id)
                                    .Select(x => new CategoryWithProductsDto
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Products = x.Products.Select(product => new ProductDto
                                        {
                                            Id = product.Id,
                                            Name = product.Name,
                                            CategoryId = product.CategoryId
                                        })
                                    })
                                    .FirstOrDefaultAsync();

            return categoryWithProductsDto;
        }
    }
}
