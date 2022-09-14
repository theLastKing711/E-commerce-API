using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos.AppUserDtos.Product;
using ECommerce.API.Dtos.Category;
using ECommerce.API.Dtos.Product;
using ECommerce.API.Dtos.Shared;
using ECommerce.API.Helpers.PriceFilterStrategy;
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Data.Repos
{
    public class CategoryRepository : BaseRepo<Category>, ICategoryRepository
    {

        IProductFilterContext productPriceFilterContext;

        public CategoryRepository(DataContext context, IProductFilterContext productPriceFilterContext) : base(context)
        {
            this.productPriceFilterContext = productPriceFilterContext;
        }


        public async Task<Category> UpdateCategory(Category category)
        {
            var categoryModel = await this._context.Products
                                                    .Where(x => x.Id == category.Id)
                                                    // .Select(x => new Product()
                                                    // {
                                                    //     Id = x.Id,
                                                    //     Name = product.Name,
                                                    //     IsBestSeller = product.IsBestSeller,
                                                    //     Price = product.Price,
                                                    //     CategoryId = product.CategoryId,
                                                    //     Path = product.Path ?? x.Path,
                                                    // })
                                                    .FirstOrDefaultAsync();

            categoryModel.Name = category.Name;
            categoryModel.Path = category.Path ?? categoryModel.Path;

            await this._context.SaveChangesAsync();

            var updatedCategory = await this._context.Categories
                                                    .Where(x => x.Id == category.Id)
                                                    .FirstOrDefaultAsync();

            return updatedCategory;
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
                                                            CreatedAt = x.CreatedAt,
                                                            Path = x.Path
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
                                            CategoryId = product.CategoryId,
                                            Path = x.Path
                                        })
                                    })
                                    .FirstOrDefaultAsync();

            return categoryWithProductsDto;
        }



        #region appUser

        private IEnumerable<Product> FilterProductsByStars(IEnumerable<Product> products, int? stars)
        {
            return products
                .Where(x => x.Reviews.Any())
                .Where(x => x.Reviews.Average(x => x.Rating) >= stars);
        }

        public async Task<Pagination<Product>> GetAppUserCategoryProducts(int id, Filter filter, ProductPagination pagination)
        {
            var productsModel = await this._context.Products
                                             .Include(x => x.Reviews)
                                             .AsNoTracking()
                                             .Where(x => x.CategoryId == id)
                                             .ToListAsync();

            IEnumerable<Product> productsModelFilterd = productsModel;

            if (filter.Stars != -1)
            {
                productsModelFilterd = this.FilterProductsByStars(productsModel, filter.Stars);
            }

            if (productsModelFilterd.Any() && filter.Price.SortType != SortType.All)
            {
                productsModelFilterd = productPriceFilterContext.FilterProductByPrice(productsModelFilterd, filter.Price);
            }

            Pagination<Product> paginatedCategoryProducts = new Pagination<Product>(productsModelFilterd,
                                                                                     pagination.PageNumber,
                                                                                      pagination.PageSize,
                                                                                     productsModelFilterd.Count()
                                                                                    );

            return paginatedCategoryProducts;
        }

        public async Task<IEnumerable<Product>> GetCategoryBestSellers(int id)
        {
            var productsModel = await this._context.Products
                                             .Include(x => x.Reviews)
                                             .AsNoTracking()
                                             .Where(x => x.CategoryId == id)
                                             .Where(x => x.IsBestSeller == true)
                                             .Select(x => new Product
                                             {
                                                 Id = x.Id,
                                                 CategoryId = x.CategoryId,
                                                 Name = x.Name,
                                                 Price = x.Price,
                                                 Path = x.Path,
                                                 IsBestSeller = x.IsBestSeller,
                                                 Reviews = x.Reviews.Select(x => new Review
                                                 {
                                                     Id = x.Id,
                                                     Body = x.Body,
                                                     Rating = x.Rating,
                                                     ProductId = x.ProductId,
                                                     CreatedAt = x.CreatedAt,
                                                     AppUserId = x.AppUserId,

                                                 })
                                             })
                                             .ToListAsync();

            return productsModel;
        }


        #endregion appUser
    }
}


