using AutoMapper;
using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos;
using ECommerce.API.Dtos.Invoice;
using ECommerce.API.Dtos.InvoiceDetails;
using ECommerce.API.Helpers;
using ECommerce.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {

        private IMapper _mapper;
        private IInvoiceRepository _InvoicesRepository;
        private readonly IImagesUploader imagesUploader;

        public InvoicesController(IInvoiceRepository InvoiceRepository, IImagesUploader imagesUploader, IMapper mapper)
        {
            _InvoicesRepository = InvoiceRepository;
            this.imagesUploader = imagesUploader;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {

            var PaginatedInvoicesModel = await _InvoicesRepository.GetAllInvoicesPaginated(pageNumber, pageSize);

            var InvoicesDetailsDto = this._mapper.Map<IEnumerable<InvoiceDto>>(PaginatedInvoicesModel.Data)
                                                 .Select(x => new InvoiceDto()
                                                 {
                                                     Id = x.Id,
                                                     CreatedAt = x.CreatedAt,
                                                     AppUser = x.AppUser,
                                                     InvoicesDetails = x.InvoicesDetails,
                                                     Total = x.InvoicesDetails.Sum(x => x.Product.Price * x.ProductQuantity)
                                                 });


            var PaginatedInvoicesDto = new Pagination<InvoiceDto>(InvoicesDetailsDto, PaginatedInvoicesModel.PageNumber, PaginatedInvoicesModel.PageSize, PaginatedInvoicesModel.TotalCount);


            return Ok(PaginatedInvoicesDto);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {

            var InvoiceModel = await _InvoicesRepository.GetInvoiceById(id);

            var InvoiceDto = _mapper.Map<InvoiceDto>(InvoiceModel);

            InvoiceDto.Total = InvoiceDto.InvoicesDetails.Select(e => e.Product).Sum(e => e.Price);

            return Ok(InvoiceDto);

        }

        [HttpPost]
        public async Task<IActionResult> AddInvoice([FromBody] AddInvoiceDto invoiceDto)
        {

            var InvoiceModel = new Invoice()
            {
                AppUserId = invoiceDto.AppUserId,
                CreatedAt = DateTime.Now,
                InvoicesDetails = invoiceDto.InvoicesDetails.Select(x => new InvoiceDetails()
                {
                    ProductId = x.ProductId,
                    ProductQuantity = x.ProductQuantity
                }).ToList()
            };

            var newInvoiceModel = await _InvoicesRepository.AddInvoice(InvoiceModel);

            var newInvoiceDto = _mapper.Map<InvoiceDto>(newInvoiceModel);

            return Ok(newInvoiceDto);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice(AddInvoiceDto InvoiceDto, int id)
        {

            var InvoiceModel = _mapper.Map<Invoice>(InvoiceDto);

            var updatedInvoice = await _InvoicesRepository.UpdateInvoice(InvoiceModel);

            return Ok(InvoiceModel);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            await _InvoicesRepository.Remove(id);

            return Ok(true);

        }
    }
}
