using AutoMapper;
using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos.AppUserDtos.Product;
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

        public AppUserCategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        [HttpGet("{id}/products")]
        public async Task<IActionResult> CategoryProducts(int id, [FromQuery] ProductPagination pagination,[FromQuery] Filter filter)
        {
            var categoryProductsModel = await _categoryRepository.GetAppUserCategoryProducts(id, filter, pagination);


            //if(categoryProductsModel.Any() && filter.Price.SortType != SortType.All)
            //{
            //    categoryProductsModel = _productPriceFilterContext.FilterProductByPrice(categoryProductsModel, filter.Price);
            //}

            //if (categoryProductsModel.Any() && filter.Stars > 0)
            //{
            //    categoryProductsModel = _productPriceFilterContext.FilterProductByStars(categoryProductsModel, filter.Stars);
            //}

            //var paginatedAndFilterdProducts = await Pagination<Product>.GetPaginatedData(filterdProductsByStars, pagination.PageNumber, pagination.PageSize);

            //IEnumerable<AppUserProductDto> categoryProductsDto = _mapper.Map<IEnumerable<AppUserProductDto>>(categoryProductsModel);


            return Ok(categoryProductsModel);

        }

    }
}
