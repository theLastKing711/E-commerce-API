using ECommerce.API.Data.IRepos;
using ECommerce.API.Data.Repos;
using ECommerce.API.Dtos;
using ECommerce.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class CategoriesController : ControllerBase
  {

    ICategoryRepository _categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
    {
      _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories([FromQuery] int pageNumber ,[FromQuery] int pageSize )
    {
        var categories = await _categoryRepository.getCategoriesPaginated(pageNumber, pageSize);

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
    public async Task<IActionResult> AddCategory(AddCategoryDto categoryDto)
    {
      var categoryModel = new Category
      {
        Id = 0,
        Name = categoryDto.Name
      };

      var newCategoryDto =  await _categoryRepository.Add(categoryModel);

      return Ok(newCategoryDto);

    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(AddCategoryDto categoryDto, int id)
    {

      var categoryModel = new Category()
      {
        Id = categoryDto.Id,
        Name = categoryDto.Name,
      };

      var updatedCategory = await _categoryRepository.Update(id ,categoryModel);

      return Ok(updatedCategory);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
      await _categoryRepository.Remove(id);

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
            CategoryDto = new CategoryDto()
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
                CategoryDto = new CategoryDto()
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
