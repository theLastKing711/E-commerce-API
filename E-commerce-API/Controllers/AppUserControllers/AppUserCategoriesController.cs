using AutoMapper;
using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos.AppUserDtos.Product;
using ECommerce.API.Dtos.Category;
using ECommerce.API.Dtos.Shared;
using ECommerce.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers.AppUserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserCategoriesController : ControllerBase
    {

        IMapper _mapper;

        ICategoryRepository _categoryRepository;

        readonly ILogger _logger;

        public AppUserCategoriesController(ICategoryRepository categoryRepository,
                                             IMapper mapper,
                                             ILoggerFactory logFactory)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logFactory.CreateLogger<AppUserCategoriesController>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery] int pageNumber, [FromQuery] int pageSize, [FromQuery] string query, [FromQuery] string active, [FromQuery] string direction)
        {
            var categories = await _categoryRepository.getCategoriesPaginated(0, 0, query, active, direction);

            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories.Data);

            return Ok(categoriesDto);
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> CategoryProducts(int id, [FromQuery] ProductPagination pagination, [FromQuery] Filter filter)
        {

            var paginatedProductsModel = await _categoryRepository.GetAppUserCategoryProducts(id, filter, pagination);

            var categoryProductsDto = _mapper.Map<IEnumerable<AppUserProductDto>>(paginatedProductsModel.Data);

            _logger.LogError(categoryProductsDto.ToString());


            var paginatedProductsDto = new Pagination<AppUserProductDto>(
                                                                            categoryProductsDto,
                                                                            pagination.PageNumber,
                                                                            pagination.PageSize,
                                                                            paginatedProductsModel.TotalCount
                                                                        );

            return Ok(paginatedProductsDto);

        }


        [HttpGet("{id}/products/bestSeller")]
        public async Task<IActionResult> getTopSellersInCategory(int id)
        {
            var topSellersProductsModel = await _categoryRepository.GetCategoryBestSellers(id);

            var topSellersProductDto = _mapper.Map<IEnumerable<AppUserProductDto>>(topSellersProductsModel);

            return Ok(topSellersProductDto);

        }

    }
}
