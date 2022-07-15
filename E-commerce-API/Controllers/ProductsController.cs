using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos;
using ECommerce.API.Helpers;
using ECommerce.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    IProductRepository _productsRepository;
        private readonly IImagesUploader imagesUploader;

    public ProductsController(IProductRepository productRepository, IImagesUploader imagesUploader)
    {
        _productsRepository = productRepository;
        this.imagesUploader = imagesUploader;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {

      var PaginatedProductsModel = await _productsRepository.GetAllProducts(pageNumber, pageSize);

            var productsDto = PaginatedProductsModel.Data.Select(x => new ProductDto()
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                Name = x.Name,
                Path = x.Path,
                Price = x.Price,
                CategoryDto = new CategoryDto()
                {
                    Id = x.Category.Id,
                    Name = x.Category.Name,
                }
            });

            var paginatedProductsDto = new Pagination<ProductDto>(
                productsDto,
                PaginatedProductsModel.PageNumber, 
                PaginatedProductsModel.PageSize, 
                PaginatedProductsModel.TotalCount
                )
            {
                Data = PaginatedProductsModel.Data.Select(x => new ProductDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Path = x.Path,
                    Price = x.Price,
                    CategoryId = x.CategoryId,
                    CategoryDto = new CategoryDto()
                    {
                        Id = x.Category.Id,
                        Name = x.Category.Name,
                    }
                })
            };

      return Ok(paginatedProductsDto);

    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {

        var productModel = await _productsRepository.GetProductById(id);

        return Ok(productModel);

    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromForm] AddProductDto productDto)
    {
        var productImagePath = imagesUploader.UploadImage(productDto.Image);

        var productModel = new Product
        {
            Id = 0,
            Name = productDto.Name,
            CategoryId = productDto.CategoryId,
            Price = productDto.Price,
            Path = productImagePath
        };

        var newProductModel = await _productsRepository.Add(productModel);

        var newProductDto = new ProductDto()
        {
            Id = newProductModel.Id,
            Name = newProductModel.Name,
            Price = newProductModel.Price,
            Path = newProductModel.Path,
            CategoryId = newProductModel.CategoryId,
            CategoryDto = new CategoryDto()
            {
                Id = newProductModel.Id,
                Name = newProductModel.Name,
            }
        };


        return Ok(newProductDto);

    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct([FromForm] AddProductDto productDto, int id)
    {

       string productImagePath = null;

      if(productDto.Image != null) 
        {
          productImagePath = imagesUploader.UploadImage(productDto.Image);
        }

        var productModel = new Product()
        {
            Id = productDto.Id,
            Name = productDto.Name,
            Path = productImagePath,
            CategoryId = productDto.CategoryId,
            Price = productDto.Price
        };


        var updatedProduct = await _productsRepository.UpdateProduct(productModel);


      productModel = new Product()
      {
        Id = updatedProduct.Id,
        Name = updatedProduct.Name,
        Path = productImagePath,
        CategoryId = updatedProduct.CategoryId,
        Category = new Category()
        {
            Id = updatedProduct.Id,
            Name = updatedProduct.Name,
            CreatedAt = updatedProduct.CreatedAt
        },
        Price = updatedProduct.Price
      };


      return Ok(productModel);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
      await _productsRepository.Remove(id);

      return Ok(true);

    }
  }
}
