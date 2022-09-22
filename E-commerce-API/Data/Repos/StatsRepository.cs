using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos;
using ECommerce.API.Dtos.Category;
using ECommerce.API.Dtos.Product;
using ECommerce.API.Dtos.Stats;
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Data.Repos
{
    public class StatsRepository : IStatsRepository
    {

        private DataContext _context;

        public StatsRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<Tuple<List<Product>, List<Category>>> getSearchedProductsAndCategories(string query)
        {

            bool isQueryEmpty = query == null;

            var productsList = await this._context.Products
                                                  .AsNoTracking()
                                                  .Where(x => isQueryEmpty ? false : x.Name.ToLower().Contains(query.ToLower()))
                                                  .ToListAsync();


            var categoriesList = await this._context.Categories
                                                    .AsNoTracking()
                                                    .Where(x => isQueryEmpty ? false : x.Name.ToLower().Contains(query.ToLower()))
                                                    .ToListAsync();


            return Tuple.Create(productsList, categoriesList);

        }


        public async Task<StatsDto> GetStats()
        {


            IEnumerable<YearlySalesDto> YearlySalesDto = await this.GetYearlySales();

            IEnumerable<TopSellerProductDto> TopSellerProductsDto = await this.GetTopSellingProducts();

            IEnumerable<TopSellerCategoryDto> TopSellerCategoryDto = await this.GetTopSellingCategories();

            StatsDto StatsDto = new StatsDto()
            {
                YearlySalesDto = YearlySalesDto,
                TopSellerProductsDto = TopSellerProductsDto,
                TopSellerCategoryDto = TopSellerCategoryDto
            };

            return StatsDto;

        }

        public async Task<IEnumerable<YearlySalesDto>> GetYearlySales()
        {

            int currentYear = DateTime.Now.Year;

            var MonthsList = Enumerable.Range(1, 12);


            var CurrentyYearInvoices = await this._context.InvoicesDetails
                                                .AsNoTracking()
                                                .Include(x => x.Product)
                                                .Where(x => x.CreatedAt.Year == currentYear)
                                                .ToListAsync();

            var CurrentYearSalesDto = MonthsList.GroupJoin(
                    CurrentyYearInvoices,
                    x => x,
                    x => x.CreatedAt.Month,
                    (month, salesGroup) => new YearlySalesDto
                    {
                        Month = month,
                        TotalSales = salesGroup.Sum(x => x.ProductQuantity * x.Product.Price)
                    }
                    )
                    .ToList();

            return CurrentYearSalesDto;

        }

        public async Task<IEnumerable<TopSellerProductDto>> GetTopSellingProducts()
        {

            int currentMonth = DateTime.Now.Month;

            var CurrentMonthSalesDto = await this._context.InvoicesDetails
                                                    .Include(x => x.Product)
                                                    .Where(
                                                        x => x.CreatedAt.Month == currentMonth
                                                    )
                                                    .ToListAsync();

            var TopSellingProductsDto = CurrentMonthSalesDto.GroupBy(x => x.ProductId)
                        .Select(x => new TopSellerProductDto()
                        {
                            Id = x.Key,
                            Name = x.Select(x => x.Product.Name).FirstOrDefault(),
                            Total = x.Sum(y => (int)y.ProductQuantity)
                        })
                        .OrderByDescending(x => x.Total)
                        .Take(3)
                        .ToList();


            return TopSellingProductsDto;

        }

        public async Task<IEnumerable<TopSellerCategoryDto>> GetTopSellingCategories()
        {

            int currentMonth = DateTime.Now.Month;

            var CurrentMonthSalesDto = await this._context.InvoicesDetails
                                                    .Include(x => x.Product)
                                                        .ThenInclude(x => x.Category)
                                                    .Where(
                                                        x => x.CreatedAt.Month == currentMonth
                                                    )
                                                    .ToListAsync();

            var TopSellingProductsDto = CurrentMonthSalesDto.GroupBy(x => x.Product.Category)
                        .Select(x => new TopSellerCategoryDto()
                        {
                            Id = x.Key.Id,
                            Name = x.Select(x => x.Product.Category.Name).FirstOrDefault(),
                            Total = x.Sum(y => (int)y.ProductQuantity)
                        })
                        .OrderByDescending(x => x.Total)
                        .Take(3)
                        .ToList();


            return TopSellingProductsDto;

        }


    }

}
