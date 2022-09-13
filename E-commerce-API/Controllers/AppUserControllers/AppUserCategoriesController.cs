using AutoMapper;
using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos.AppUserDtos.Product;
using ECommerce.API.Dtos.Category;
using ECommerce.API.Dtos.Shared;
using ECommerce.API.Helpers.PriceFilterStrategy;
using ECommerce.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Controllers.AppUserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserCategoriesController : ControllerBase
    {

        IMapper _mapper;

        ICategoryRepository _categoryRepository;

        IProductFilterContext _productPriceFilterContext;

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
        public async Task<IActionResult> GetAllCategories([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var categories = await _categoryRepository.getCategoriesPaginated(0, 0);

            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories.Data);

            return Ok(categoriesDto);
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> CategoryProducts(int id, [FromQuery] ProductPagination pagination, [FromQuery] Filter filter)
        {

            _logger.LogInformation(pagination.PageNumber.ToString());
            _logger.LogInformation(pagination.PageSize.ToString());
            _logger.LogInformation(filter.Stars.ToString());


            var paginatedProductsModel = await _categoryRepository.GetAppUserCategoryProducts(id, filter, pagination);

            var categoryProductsDto = _mapper.Map<IEnumerable<AppUserProductDto>>(paginatedProductsModel.Data);

            _logger.LogError(categoryProductsDto.ToString());


            var paginatedProductsDto = new Pagination<AppUserProductDto>(
                                                                            categoryProductsDto,
                                                                            pagination.PageNumber,
                                                                            pagination.PageSize,
                                                                            categoryProductsDto.Count()
                                                                        );


            _logger.LogError(paginatedProductsDto.Data.Count().ToString());

            return Ok(paginatedProductsDto);

        }

    }
}
