using AutoMapper;
using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos.AppUserDtos.Product;
using ECommerce.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers.AppUserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserProductsController : ControllerBase
    {

        IMapper _mapper;

        IProductRepository _productRepository;

        readonly ILogger _logger;

        public AppUserProductsController(IProductRepository productRepository,
                                             IMapper mapper,
                                             ILoggerFactory logFactory)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logFactory.CreateLogger<AppUserCategoriesController>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            Product productModel = await this._productRepository.getAppUserProductById(id);

            AppUserProductDto productDto = _mapper.Map<AppUserProductDto>(productModel);

            return Ok(productDto);

        }

        [HttpPost("getUsingIds")]
        public async Task<IActionResult> getProductsUsingIds(List<int> ids)
        {
            var productsModel = await _productRepository.getProductsUsingIds(ids);

            _logger.LogCritical(productsModel.Count().ToString());

            var productsDto = _mapper.Map<IEnumerable<AppUserProductDto>>(productsModel);

            return Ok(productsDto);


        }

        [HttpGet("{id}/reviewStats")]
        public async Task<IActionResult> reviewStats(int id)
        {
            var productReviewStatsDto = await this._productRepository.getProductReviewsDetails(id);

            return Ok(productReviewStatsDto);

        }


    }
}
