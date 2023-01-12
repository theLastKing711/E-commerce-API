using AutoMapper;
using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos.Discount;
using ECommerce.API.Helpers;
using ECommerce.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Authorize(Roles = "Admin, SalesManager")]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {

        private IMapper _mapper;
        private IDiscountRepository _DiscountsRepository;
        private readonly IImagesUploader imagesUploader;

        public DiscountsController(IDiscountRepository DiscountRepository, IImagesUploader imagesUploader, IMapper mapper)
        {
            _DiscountsRepository = DiscountRepository;
            this.imagesUploader = imagesUploader;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiscounts([FromQuery] int pageNumber, [FromQuery] int pageSize, [FromQuery] string query, [FromQuery] string active, [FromQuery] string direction)
        {

            var PaginatedDiscountsModel = await _DiscountsRepository.getDiscountsPaginated(pageNumber, pageSize, query, active, direction);

            var DiscountsDetailsDto = this._mapper.Map<IEnumerable<DiscountDto>>(PaginatedDiscountsModel.Data)
                                                 .Select(x => new DiscountDto()
                                                 {
                                                     Id = x.Id,
                                                     Value = x.Value,
                                                     CreatedAt = x.CreatedAt,
                                                 });


            var PaginatedDiscountsDto = new Pagination<DiscountDto>(DiscountsDetailsDto, PaginatedDiscountsModel.PageNumber, PaginatedDiscountsModel.PageSize, PaginatedDiscountsModel.TotalCount);


            return Ok(PaginatedDiscountsDto);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountById(int id)
        {

            var DiscountModel = await _DiscountsRepository.GetById(id);

            var DiscountDto = _mapper.Map<DiscountDto>(DiscountModel);

            return Ok(DiscountDto);

        }

        [HttpPost]
        public async Task<IActionResult> AddDiscount([FromBody] AddDiscountDto DiscountDto)
        {

            var discountModel = new Discount
            {
                Id = 0,
                Value = DiscountDto.Value,
                ProductId = DiscountDto.ProductId
            };

            var newDiscountModel = await _DiscountsRepository.Add(discountModel);

            var newdiscountDto = new DiscountDto()
            {
                Id = newDiscountModel.Id,
                Value = newDiscountModel.Value,
                ProductId = newDiscountModel.ProductId,
                CreatedAt = newDiscountModel.CreatedAt
            };


            return Ok(newdiscountDto);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiscount(AddDiscountDto DiscountDto, int id)
        {

            var DiscountModel = _mapper.Map<Discount>(DiscountDto);

            var updatedDiscount = await _DiscountsRepository.UpdateDiscount(DiscountModel);

            return Ok(DiscountModel);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            await _DiscountsRepository.Remove(id);

            return Ok(true);

        }

        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteDiscounts(List<int> ids)
        {
            await _DiscountsRepository.DeleteDiscounts(ids);

            return Ok(true);

        }


        [HttpGet("check-if-duplicated")]
        public async Task<IActionResult> CheckifDiscountDuplicated([FromQuery] int productId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var IsDiscountDuplicatedMessage = await this._DiscountsRepository.CheckIfDiscountDuplicated(productId, startDate, endDate);

            if (IsDiscountDuplicatedMessage == "")
            {
                return Ok(false);
            }

            return Ok(IsDiscountDuplicatedMessage);


        }


    }
}
