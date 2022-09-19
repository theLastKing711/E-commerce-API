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


    }
}
