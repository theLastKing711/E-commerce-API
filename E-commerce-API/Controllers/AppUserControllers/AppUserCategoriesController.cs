using AutoMapper;
using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos.AppUserDtos.Product;
using ECommerce.API.Dtos.Shared;
using ECommerce.API.Helpers.PriceFilterStrategy;
using ECommerce.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers.AppUserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserCategoriesController : ControllerBase
    {

        IMapper _mapper;
        IPriceFilterStrategy _priceFilterStrategy;

        ICategoryRepository _categoryRepository;

        public AppUserCategoriesController(ICategoryRepository categoryRepository, IPriceFilterStrategy priceFilterStrategy, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _priceFilterStrategy = priceFilterStrategy;
            _mapper = mapper;
        }


        [HttpGet("{id}/products")]
        public async Task<IActionResult> CategoryProducts(int id, [FromQuery] ProductPagination pagination,[FromQuery] Filter filter)
        {
            IEnumerable<Product> categoryProductsModel = await _categoryRepository.GetAppUserCategoryProducts(id);

            IEnumerable<AppUserProductDto> categoryProductsDto = _mapper.Map<IEnumerable<AppUserProductDto>>(categoryProductsModel);

            return Ok("laksjdl");

        }

    }
}
