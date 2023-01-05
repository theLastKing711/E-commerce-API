using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos.Category;
using ECommerce.API.Dtos.Product;
using ECommerce.API.Helpers;
using ECommerce.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Authorize(Roles = "Admin, SalesManager")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        ICategoryRepository _categoryRepository;
        private readonly IImagesUploader _imagesUploader;

        public CategoriesController(ICategoryRepository categoryRepository, IImagesUploader imageUploader)
        {
            _categoryRepository = categoryRepository;
            _imagesUploader = imageUploader;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery] int pageNumber, [FromQuery] int pageSize, [FromQuery] string query, [FromQuery] string active, [FromQuery] string direction)
        {
            var categories = await _categoryRepository.getCategoriesPaginated(pageNumber, pageSize, query, active, direction);

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {

            var categoryModel = await _categoryRepository.GetById(id);

            var categoriesDto = new Category()
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
            };

            return Ok(categoriesDto);

        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromForm] AddCategoryDto categoryDto)
        {


            // if (categoryDto.Image != null)
            // {
            // var categoryImageUrl = this._imagesUploader.UploadImage(categoryDto.Image);
            // }

            var categoryModel = new Category
            {
                Id = 0,
                Name = categoryDto.Name,
                Path = ""
            };

            var newCategoryDto = await _categoryRepository.Add(categoryModel);

            return Ok(newCategoryDto);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromForm] UpdateCategoryDto categoryDto, int id)
        {

            string categoryImagePath = null;

            if (categoryDto.Image != null)
            {
                categoryImagePath = _imagesUploader.UploadImage(categoryDto.Image);
            }

            var categoryModel = new Category()
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                Path = ""
            };

            var updatedCategory = await _categoryRepository.UpdateCategory(categoryModel);

            return Ok(updatedCategory);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var categoryRemoved = await _categoryRepository.Remove(id);

            if (categoryRemoved)
            {
                return Ok(true);
            }

            return Ok(false);

        }

        [HttpPost("removeRange")]
        public async Task<IActionResult> DeleteAppUsers(List<int> ids)
        {
            await _categoryRepository.DeleteCategories(ids);

            return Ok(true);

        }


        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            var categoriesList = await this._categoryRepository.GetAll();

            return Ok(categoriesList);
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> CategoryProducts(int id, [FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var paginatedCategoryProducts = await _categoryRepository.getCategoryProductsPaginated(id, pageNumber, pageSize);

            var productsDto = paginatedCategoryProducts.Data.Select(x => new ProductDto()
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                Name = x.Name,
                Path = x.Path,
                Price = x.Price,
                Category = new CategoryDto()
                {
                    Id = x.Category.Id,
                    Name = x.Category.Name,
                }
            });

            var paginatedProductsDto = new Pagination<ProductDto>(
                productsDto,
                paginatedCategoryProducts.PageNumber,
                paginatedCategoryProducts.PageSize,
                paginatedCategoryProducts.TotalCount
                )
            {
                Data = paginatedCategoryProducts.Data.Select(x => new ProductDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Path = x.Path,
                    Price = x.Price,
                    CategoryId = x.CategoryId,
                    Category = new CategoryDto()
                    {
                        Id = x.Category.Id,
                        Name = x.Category.Name,
                    }
                })
            };

            return Ok(paginatedProductsDto);

        }

    }
}
