using AutoMapper;
using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos.Identity.AppUser;
using ECommerce.API.Helpers;
using ECommerce.API.Models;
using ECommerce.API.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _usermanager;


        public AppUsersController(IAppUserRepository AppUserRepository,
                                   IImagesUploader imagesUploader,
                                   IMapper mapper,
                                   UserManager<AppUser> userManager
                                   )
        {
            _AppUsersRepository = AppUserRepository;
            this.imagesUploader = imagesUploader;
            _mapper = mapper;
            _usermanager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppUsers([FromQuery] int pageNumber, [FromQuery] int pageSize, [FromQuery] string query, [FromQuery] string active, [FromQuery] string direction)
        {

            var PaginatedAppUsersModel = await _AppUsersRepository.GetAllAppUsersPaginated(pageNumber, pageSize, query, active, direction);

            var paginatedAppUsersDto = this._mapper.Map<IEnumerable<AppUserDto>>(PaginatedAppUsersModel.Data);

            var PaginatedInvoicesDto = new Pagination<AppUserDto>(paginatedAppUsersDto, PaginatedAppUsersModel.PageNumber, PaginatedAppUsersModel.PageSize, PaginatedAppUsersModel.TotalCount);

            return Ok(PaginatedInvoicesDto);

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUserById(int id)
        {

            var AppUserModel = await _AppUsersRepository.GetAppUserById(id);

            var userRoles = await this._usermanager.GetRolesAsync(AppUserModel);


            AppUserDto AppUserDto = _mapper.Map<AppUserDto>(AppUserModel);

            AppUserDto.RoleName = userRoles.FirstOrDefault();


            return Ok(AppUserDto);

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddAppUser([FromForm] AddAppUserDto AppUserDto)
        {
            var AppUserModel = _mapper.Map<AppUser>(AppUserDto);

            string AppUserImagePath = null;

            if (AppUserDto.Image != null)
            {
                AppUserImagePath = imagesUploader.UploadImage(AppUserDto.Image);
            }

            AppUserModel.ImagePath = AppUserImagePath;

            var newAppUserModel = await _AppUsersRepository.AddAppUser(AppUserModel, AppUserDto.Password, AppUserDto.RoleName);

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

            var updatedAppUser = await _AppUsersRepository.UpdateAppUser(AppUserModel, AppUserDto.RoleName, AppUserDto.Password);

            return Ok(AppUserModel);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUser(int id)
        {
            await _AppUsersRepository.DeleteAppUser(id);

            return Ok(true);

        }

        [HttpPost("removeRange")]
        public async Task<IActionResult> DeleteAppUsers(List<int> ids)
        {
            await _AppUsersRepository.DeleteAppUsers(ids);

            return Ok(true);

        }


        [HttpGet("Roles")]
        public async Task<IActionResult> GetRoles()
        {
            var AllRoles = await _AppUsersRepository.GetAllRoles();

            return Ok(AllRoles);

        }


    }
}
