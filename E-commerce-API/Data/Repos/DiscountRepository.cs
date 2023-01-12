using ECommerce.API.Data.IRepos;
using ECommerce.API.Helpers.PriceFilterStrategy;
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;
namespace ECommerce.API.Data.Repos
{
    public class DiscountRepository : BaseRepo<Discount>, IDiscountRepository
    {

        IProductFilterContext productPriceFilterContext;

        ILogger logger;

        public DiscountRepository(DataContext context, IProductFilterContext productPriceFilterContext, ILoggerFactory logFactory) : base(context)
        {
            this.productPriceFilterContext = productPriceFilterContext;
            logger = logFactory.CreateLogger<DiscountRepository>();
        }

        public async Task<Discount> UpdateDiscount(Discount Discount)
        {
            var DiscountModel = await this._context.Discounts
                                                   .Where(x => x.Id == Discount.Id)
                                                   .FirstOrDefaultAsync();


            DiscountModel.Value = Discount.Value;
            DiscountModel.ProductId = Discount.ProductId;

            await this._context.SaveChangesAsync();

            var updatedDiscount = await this._context.Discounts
                                                    .Where(x => x.Id == Discount.Id)
                                                    .FirstOrDefaultAsync();

            return updatedDiscount;
        }

        public async Task<Pagination<Discount>> getDiscountsPaginated(int pageNumber, int pageSize, string query, string active, string direction)
        {


            var DiscountsModel = this._context.Discounts
                                               .Where(x => query == "-1" || (x.Value.ToString().Contains(query) || x.Id.ToString().Contains(query)));

            IOrderedQueryable<Discount>? orderedDiscountsModel;

            if (active != "-1" && direction != "-1")
            {

                switch (active)
                {
                    case "id":
                        orderedDiscountsModel = direction == "asc" ? DiscountsModel.OrderBy(x => x.Id) : DiscountsModel.OrderByDescending(x => x.Id);

                        break;

                    case "Value":
                        orderedDiscountsModel = direction == "asc" ? DiscountsModel.OrderBy(x => x.Value) : DiscountsModel.OrderByDescending(x => x.Value);
                        break;

                    case "createdAt":
                        orderedDiscountsModel = direction == "asc" ? DiscountsModel.OrderBy(x => x.CreatedAt) : DiscountsModel.OrderByDescending(x => x.CreatedAt);
                        break;

                    default:
                        orderedDiscountsModel = DiscountsModel.OrderByDescending(x => x.CreatedAt);
                        break;
                }
            }
            else
            {
                orderedDiscountsModel = DiscountsModel.OrderByDescending(x => x.CreatedAt);
            }



            Pagination<Discount> paginatedDiscountsModel = await Pagination<Discount>.GetPaginatedData(orderedDiscountsModel, pageNumber, pageSize);

            return paginatedDiscountsModel;

        }

        public async Task<bool> DeleteDiscounts(List<int> ids)
        {

            var DiscountsModel = await this._context.Discounts.Where(x => ids.Contains(x.Id))
                                                                .ToListAsync();

            this._context.Discounts.RemoveRange(DiscountsModel);

            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<Discount> AddDiscount(Discount discount)
        {


            var productModel = await this._context.Products
                                                    .AsNoTracking()
                                                    .Include(product => product.Discounts)
                                                    .Where(e => e.Id == discount.ProductId)
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

        public async Task<string> CheckIfDiscountDuplicated(int ProductId, DateTime startDate, DateTime endDate)
        {

            var productModel = await this._context.Products
                                                    .AsNoTracking()
                                                    .Include(product => product.Discounts)
                                                    .Where(e => e.Id == ProductId)
                                                    .FirstOrDefaultAsync();

            this.logger.LogCritical(productModel.Name.ToString());

            var isDiscountDuplicated = "";

            // foreach (Discount d in productModel?.Discounts)
            // {
            //     this.logger.LogCritical("first");

            //     if (
            //         d.StartDate <= startDate && d.EndDate >= startDate
            //         ||
            //         d.StartDate <= endDate && d.EndDate >= endDate
            //         ||
            //         (
            //             startDate <= d.StartDate
            //                 &&
            //             endDate >= d.EndDate
            //         )
            //     )
            //     {
            //         isDiscountDuplicated = $"discount already exist within date range ${d.StartDate}-${d.EndDate}";
            //         break;
            //     }
            // }

            return isDiscountDuplicated;

        }
    }
}


