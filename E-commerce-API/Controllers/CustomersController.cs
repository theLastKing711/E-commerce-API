using AutoMapper;
using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos;
using ECommerce.API.Helpers;
using ECommerce.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private IMapper _mapper;
        private ICustomerRepository _CustomersRepository;
        private readonly IImagesUploader imagesUploader;

        public CustomersController(ICustomerRepository CustomerRepository, IImagesUploader imagesUploader, IMapper mapper)
        {
            _CustomersRepository = CustomerRepository;
            this.imagesUploader = imagesUploader;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {

            var PaginatedCustomersModel = await _CustomersRepository.GetAllCustomersPaginated(pageNumber, pageSize);

            var paginatedCustomersDto = this._mapper.Map<IEnumerable<CustomerDto>>(PaginatedCustomersModel.Data);

            var PaginatedInvoicesDto = new Pagination<CustomerDto>(paginatedCustomersDto, PaginatedCustomersModel.PageNumber, PaginatedCustomersModel.PageSize, PaginatedCustomersModel.TotalCount);

            return Ok(PaginatedInvoicesDto);

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {

            var CustomerModel = await _CustomersRepository.GetCustomerById(id);

            _mapper.Map<CustomerDto>(CustomerModel);

            return Ok(CustomerModel);

        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromForm] AddCustomerDto CustomerDto)
        {
            var CustomerModel = _mapper.Map<Customer>(CustomerDto);

            var CustomerImagePath = imagesUploader.UploadImage(CustomerDto.Image);

            var newCustomerModel = await _CustomersRepository.Add(CustomerModel);

            var result = _mapper.Map<CustomerDto>(newCustomerModel);

            return Ok(result);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromForm] AddCustomerDto CustomerDto, int id)
        {

            var CustomerModel = _mapper.Map<Customer>(CustomerDto);

            string CustomerImagePath = null;

            if (CustomerDto.Image != null)
            {
                CustomerImagePath = imagesUploader.UploadImage(CustomerDto.Image);
            }

            var updatedCustomer = await _CustomersRepository.UpdateCustomer(CustomerModel);

            return Ok(CustomerModel);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _CustomersRepository.Remove(id);

            return Ok(true);

        }
    }
}
