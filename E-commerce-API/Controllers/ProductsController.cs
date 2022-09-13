using AutoMapper;
using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos.Category;
using ECommerce.API.Dtos.Discount;
using ECommerce.API.Dtos.Identity.AppUser;
using ECommerce.API.Dtos.Product;
using ECommerce.API.Dtos.Review;
using ECommerce.API.Helpers;
using ECommerce.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductRepository _productsRepository;
        private readonly IImagesUploader imagesUploader;

        private IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IImagesUploader imagesUploader, IMapper mapper)
        {
            _productsRepository = productRepository;
            this.imagesUploader = imagesUploader;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {

            var PaginatedProductsModel = await _productsRepository.GetAllProducts(pageNumber, pageSize);

            var productsDto = this._mapper.Map<IEnumerable<ProductDto>>(PaginatedProductsModel.Data);

            var paginatedProductsDto = new Pagination<ProductDto>(
                productsDto,
                PaginatedProductsModel.PageNumber,
                PaginatedProductsModel.PageSize,
                PaginatedProductsModel.TotalCount
            );

            paginatedProductsDto.Data = paginatedProductsDto.Data.Select(x => new ProductDto()
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                IsBestSeller = x.IsBestSeller,
                Path = x.Path,
                Price = x.Price,
                Name = x.Name,
                Reviews = x.Reviews.Select(y => new ReviewDto()
                {
                    Id = y.Id,
                    AppUserId = y.AppUserId,
                    Body = y.Body,
                    Rating = y.Rating,
                    ProductId = y.ProductId,
                    CreatedAt = y.CreatedAt,
                    AppUser = this._mapper.Map<AppUserDto>(y.AppUser)
                }),
                Discounts = x.Discounts.Select(y => new DiscountDto()
                {
                    Id = y.Id,
                    CreatedAt = y.CreatedAt,
                    EndDate = y.EndDate,
                    ProductId = y.ProductId,
                    StartDate = y.StartDate,
                    Value = y.Value
                })
            });

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
                Category = new CategoryDto()
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

            if (productDto.Image != null)
            {
                productImagePath = imagesUploader.UploadImage(productDto.Image);
            }

            var productModel = this._mapper.Map<Product>(productDto);

            // var productModel = new Product()
            // {
            //     Id = productDto.Id,
            //     Name = productDto.Name,
            //     Path = productImagePath,
            //     CategoryId = productDto.CategoryId,
            //     Price = productDto.Price,
            //     IsBestSeller = productDto.IsBestSeller
            // };


            var updatedProductModel = await _productsRepository.UpdateProduct(productModel);


            var ProductDto = new ProductDto()
            {
                Id = updatedProductModel.Id,
                Name = updatedProductModel.Name,
                Path = productImagePath,
                CategoryId = updatedProductModel.CategoryId,
                Category = new CategoryDto()
                {
                    Id = updatedProductModel.Id,
                    Name = updatedProductModel.Name,
                    CreatedAt = updatedProductModel.CreatedAt
                },
                Price = updatedProductModel.Price
            };

            // var ProductDto = this._mapper.Map<Product>(updatedProductModel);

            return Ok(ProductDto);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productsRepository.Remove(id);

            return Ok(true);

        }

        [HttpGet("TopSellers")]
        public async Task<IActionResult> TopSellers()
        {

            var TopSellerProductsDto = await this._productsRepository.GetTopSellers();

            return Ok(TopSellerProductsDto);

        }


        [HttpPost("{id}/Review")]
        public async Task<IActionResult> ReviewPost(int id, AddReviewDto reviewDto)
        {

            var reviewModel = this._mapper.Map<Review>(reviewDto);

            var reviewedPostModel = await _productsRepository.AddReview(id, reviewModel);


            if (reviewedPostModel == null)
            {
                // var error = new {
                //     "error": "your already reviews this product"
                // };

                // return BadRequest(error);

                return BadRequest("You Already Reviewed this product");
            }

            var reviewedPostDto = new ProductDto()
            {
                Id = reviewedPostModel.Id,
                CategoryId = reviewedPostModel.CategoryId,
                IsBestSeller = reviewedPostModel.IsBestSeller,
                Path = reviewedPostModel.Path,
                Price = reviewedPostModel.Price,
                Name = reviewedPostModel.Name,
                Reviews = reviewedPostModel.Reviews.Select(x => new ReviewDto()
                {
                    Id = x.Id,
                    AppUserId = x.AppUserId,
                    Body = x.Body,
                    Rating = x.Rating,
                    ProductId = x.ProductId,
                    CreatedAt = x.CreatedAt,
                    AppUser = this._mapper.Map<AppUserDto>(x.AppUser)
                })
            };

            return Ok(reviewedPostDto);

        }


        [HttpDelete("Reviews/{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {

            var reviewedPostModel = await _productsRepository.DeleteReview(id);

            return Ok();

        }

        [HttpPut("Reviews/{id}")]
        public async Task<IActionResult> UpdateReview(int id, AddReviewDto reviewDto)
        {
            var reviewModel = this._mapper.Map<Review>(reviewDto);

            var updatedReviewModel = await this._productsRepository.UpdateReview(id, reviewModel);

            var ResponseReviewDto = this._mapper.Map<ReviewDto>(updatedReviewModel);

            return Ok(ResponseReviewDto);

        }

        [HttpPost("{id}/Discounts")]
        public async Task<IActionResult> AddDiscount(int id, AddDiscountDto discountDto)
        {
            if (discountDto.StartDate <= DateTime.Now || discountDto.EndDate <= DateTime.Now)
            {
                return BadRequest("Can't add discount date before this date");
            }

            var discountModel = this._mapper.Map<Discount>(discountDto);

            var updateDiscountModel = await this._productsRepository.AddDiscount(id, discountModel);

            if (updateDiscountModel == null)
            {
                return BadRequest("Can't add discount, there is already discount in given dates");
            }

            var ResponseDiscountDto = this._mapper.Map<DiscountDto>(updateDiscountModel);

            return Ok(ResponseDiscountDto);

        }

        [HttpDelete("Discounts/{id}")]
        public async Task<IActionResult> DeleteDiscount(int id)
        {

            var DiscountedPostModel = await _productsRepository.DeleteDiscount(id);

            return Ok(DiscountedPostModel);

        }




    }
}
