using AutoMapper;
using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos;
using ECommerce.API.Dtos.Identity;
using ECommerce.API.Dtos.Identity.AppUser;
using ECommerce.API.Helpers;
using ECommerce.API.Models;
using ECommerce.API.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {

        private IMapper _mapper;
        private IAppUserRepository _AppUsersRepository;
        private readonly IImagesUploader imagesUploader;

        public AppUsersController(IAppUserRepository AppUserRepository, IImagesUploader imagesUploader, IMapper mapper)
        {
            _AppUsersRepository = AppUserRepository;
            this.imagesUploader = imagesUploader;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppUsers([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {

            var PaginatedAppUsersModel = await _AppUsersRepository.GetAllAppUsersPaginated(pageNumber, pageSize);

            var paginatedAppUsersDto = this._mapper.Map<IEnumerable<AppUserDto>>(PaginatedAppUsersModel.Data);

            var PaginatedInvoicesDto = new Pagination<AppUserDto>(paginatedAppUsersDto, PaginatedAppUsersModel.PageNumber, PaginatedAppUsersModel.PageSize, PaginatedAppUsersModel.TotalCount);

            return Ok(PaginatedInvoicesDto);

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUserById(int id)
        {

            var AppUserModel = await _AppUsersRepository.GetAppUserById(id);

            AppUserDto appUserDto = _mapper.Map<AppUserDto>(AppUserModel);

            return Ok(appUserDto);

        }

        [HttpPost]
        public async Task<IActionResult> AddAppUser([FromForm] AddAppUserDto AppUserDto)
        {
            var AppUserModel = _mapper.Map<AppUser>(AppUserDto);



            var AppUserImagePath = imagesUploader.UploadImage(AppUserDto.Image);

            AppUserModel.ImagePath = AppUserImagePath;

            var newAppUserModel = await _AppUsersRepository.AddAppUser(AppUserModel, AppUserDto.Password);

            var result = _mapper.Map<AppUserDto>(newAppUserModel);

            return Ok(result);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppUser([FromForm] AddAppUserDto AppUserDto, int id)
        {

            var AppUserModel = _mapper.Map<AppUser>(AppUserDto);

            string AppUserImagePath = null;

            if (AppUserDto.Image != null)
            {
                AppUserImagePath = imagesUploader.UploadImage(AppUserDto.Image);
            }


            AppUserModel.ImagePath = AppUserImagePath;

            var updatedAppUser = await _AppUsersRepository.UpdateAppUser(AppUserModel, AppUserDto.Password);

            return Ok(AppUserModel);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUser(int id)
        {
            await _AppUsersRepository.DeleteAppUser(id);

            return Ok(true);

        }
    }
}
