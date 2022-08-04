using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos.Product;
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
            var productModel = await this._context.Products
                                                    .Include(x => x.Category)
                                                    .Include(x => x.Reviews)
                                                    .Where(x => x.Id == product.Id)
                                                    // .Select(x => new Product()
                                                    // {
                                                    //     Id = x.Id,
                                                    //     Name = product.Name,
                                                    //     IsPopular = product.IsPopular,
                                                    //     Price = product.Price,
                                                    //     CategoryId = product.CategoryId,
                                                    //     Path = product.Path ?? x.Path,
                                                    // })
                                                    .FirstOrDefaultAsync();

            productModel.Name = product.Name;
            productModel.Price = product.Price;
            productModel.Path = product.Path ?? productModel.Path;
            productModel.IsPopular = product.IsPopular;
            productModel.Reviews = product.Reviews;




            await this._context.SaveChangesAsync();

            var updatedProduct = await this._context.Products.Include(x => x.Category)
                                                        .Where(x => x.Id == product.Id)
                                                        .FirstOrDefaultAsync();

            return updatedProduct;
        }

        public async Task<Pagination<Product>> GetAllProducts(int pageNumber, int pageSize)
        {
            var productsModel = this._context.Products
                                    .Include(product => product.Category)
                                    .Include(Product => Product.Reviews)
                                        .ThenInclude(review => review.Customer)
                                    .Include(Product => Product.Discounts)
                                    .OrderByDescending(x => x.CreatedAt);

            Pagination<Product> paginatedCategoriesModel = await Pagination<Product>.GetPaginatedData(productsModel, pageNumber, pageSize);


            return paginatedCategoriesModel;

        }

        public async Task<Product> GetProductById(int id)
        {
            var productModel = await this._context.Products.AsNoTracking()
                                                            .Include(product => product.Category)
                                                            .Include(product => product.Reviews)
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
                                                               },
                                                               IsPopular = x.IsPopular
                                                           })
                                                           .FirstOrDefaultAsync();

            return productModel;

        }

        public async Task<Product> AddReview(int id, Review review)
        {


            // ProductModel.Reviews.Append(review);

            var customerReviewModel = await this._context.Reviews
                                                    .AsNoTracking()
                                                    .Where(e => e.ProductId == id && e.CustomerId == review.CustomerId)
                                                    .FirstOrDefaultAsync();

            if (customerReviewModel != null)
            {
                return null;
            }


            await this._context.Reviews.AddAsync(review);

            await _context.SaveChangesAsync();


            var ProductModel = await this._context.Products
                                                 .Where(x => x.Id == id)
                                                 .Include(x => x.Reviews)
                                                    .ThenInclude(x => x.Customer)
                                                 .Include(x => x.Discounts)
                                                 .Include(x => x.InvoicesDetails)
                                                 .FirstOrDefaultAsync();



            return ProductModel;

        }


        public async Task<bool> DeleteReview(int reviewId)
        {
            var reviewModel = await this._context.Reviews
                                                        .Where(x => x.Id == reviewId)
                                                        .FirstOrDefaultAsync();

            this._context.Reviews.Remove(reviewModel);

            await this._context.SaveChangesAsync();

            return true;

        }

        public async Task<Review> UpdateReview(int id, Review review)
        {
            var reviewModel = await this._context.Reviews
                                                    .Where(x => x.Id == id)
                                                    .FirstOrDefaultAsync();

            reviewModel.Body = review.Body;
            reviewModel.Rating = review.Rating;

            await this._context.SaveChangesAsync();

            return reviewModel;
        }


        public async Task<Discount> AddDiscount(int id, Discount discount)
        {


            var productModel = await this._context.Products
                                                    .AsNoTracking()
                                                    .Include(product => product.Discounts)
                                                    .Where(e => e.Id == id)
                                                    .FirstOrDefaultAsync();



            foreach (Discount d in productModel.Discounts)
            {
                if (
                    d.StartDate <= discount.StartDate && d.EndDate >= discount.StartDate
                    ||
                    d.StartDate <= discount.EndDate && d.EndDate >= discount.EndDate
                    ||
                    (
                        discount.StartDate <= d.StartDate
                            &&
                        discount.EndDate >= d.EndDate
                    )
                )
                {
                    return null;
                }
            }

            await this._context.Discounts.AddAsync(discount);

            await _context.SaveChangesAsync();


            return discount;

        }

        public async Task<bool> DeleteDiscount(int discountId)
        {
            var discountModel = await this._context.Discounts
                                                        .Where(x => x.Id == discountId)
                                                        .FirstOrDefaultAsync();

            this._context.Discounts.Remove(discountModel);

            await this._context.SaveChangesAsync();

            return true;

        }


        public async Task<IEnumerable<TopSellerProductDto>> GetTopSellers()
        {
            int thisMonth = DateTime.Now.Month;
            int thisYear = DateTime.Now.Year;

            var CurrentMonthProducts = await this._context.InvoicesDetails
                                          .Include(x => x.Product)
                                          .Where(x => thisMonth == x.CreatedAt.Month && thisYear == x.CreatedAt.Year)
                                          .ToListAsync();


            var TopSellersProducts = CurrentMonthProducts
                                            .GroupBy(x => new { x.ProductId })
                                            .Select(x => new TopSellerProductDto()
                                            {
                                                Id = x.Key.ProductId,
                                                Name = x.Select(x => x.Product.Name).FirstOrDefault(),
                                                Total = x.Sum(y => (y.Product.Price * y.ProdcutQuantity))
                                            })
                                            .OrderByDescending(x => x.Total)
                                            .Take(3)
                                            .ToList();


            return TopSellersProducts;


        }



    }

}
