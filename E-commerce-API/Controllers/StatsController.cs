using AutoMapper;
using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos.Category;
using ECommerce.API.Dtos.Product;
using ECommerce.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {

        private IMapper _mapper;
        private IStatsRepository _StatsRepository;
        private readonly IImagesUploader imagesUploader;

        public StatsController(IStatsRepository StatsRepository, IMapper mapper)
        {
            _StatsRepository = StatsRepository;
            _mapper = mapper;
        }


        [HttpGet("SearchItems")]
        public async Task<IActionResult> SearchItems([FromQuery] string? query = "")
        {
            var (ProductsList, CategoriesList) = await this._StatsRepository.getSearchedProductsAndCategories(query);

            var ProductListDto = this._mapper.Map<IEnumerable<ProductItemDto>>(ProductsList);

            var CategoryListDto = this._mapper.Map<IEnumerable<CategoryItemDto>>(CategoriesList);

            return Ok(new
            {
                ProductListDto,
                CategoryListDto
            });

        }


        [HttpGet]
        public async Task<IActionResult> GetStats()
        {
            var StatsDto = await this._StatsRepository.GetStats();

            return Ok(StatsDto);
        }

        [HttpGet("YearlySales")]
        public async Task<IActionResult> GetYearlySales([FromQuery] int year)
        {
            var YearlySalesDto = await this._StatsRepository.GetYearlySales();

            return Ok(YearlySalesDto);
        }

        [HttpGet("TopSellingProduct")]
        public async Task<IActionResult> GetTopSellingProduct()
        {
            var TopSellingProductsDto = await this._StatsRepository.GetTopSellingProducts();

            return Ok(TopSellingProductsDto);
        }

        [HttpGet("TopSellingCategory")]
        public async Task<IActionResult> GetTopSellingCategories()
        {
            var TopSellingCategoriesDto = await this._StatsRepository.GetTopSellingCategories();

            return Ok(TopSellingCategoriesDto);
        }


    }
}
