using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos.Identity;
using ECommerce.API.Models;
using ECommerce.API.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Data.Repos
{
    public class AppUserRepository : IAppUserRepository
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        private DataContext _context;


        public AppUserRepository(DataContext context,
                                     UserManager<AppUser> userManaager,
                                     RoleManager<AppRole> roleManager
                                )
        {
            _context = context;
            this._userManager = userManaager;
            this._roleManager = roleManager;
        }

        public async Task<bool> IsUserNameDuplicated(string username)
        {

            var IsUserNameDuplicated = await this._userManager.FindByNameAsync(username);

            return IsUserNameDuplicated != null ? true : false;

        }

        public async Task<bool> IsEmailDuplicated(string email)
        {

            var IsEmailDuplicated = await this._userManager.FindByEmailAsync(email);


            return IsEmailDuplicated != null ? true : false;

        }

        public async Task<AppUser> AddAppUser(AppUser user, string password)
        {

            var result = await this._userManager.CreateAsync(user, password);

            var createdUser = await this._userManager.Users
                                                     .Where(x => x.UserName == user.UserName)
                                                     .FirstOrDefaultAsync();

            if (createdUser != null)
                await this._userManager.AddToRoleAsync(createdUser, UserRoles.User);

            return createdUser;
        }

        public async Task<AppUser> UpdateAppUser(AppUser user, string? password)
        {
            var OldAppUser = await this._userManager.FindByNameAsync(user.UserName);

            OldAppUser.ImagePath = user.ImagePath ?? OldAppUser.ImagePath;

            OldAppUser.Email = user.Email;

            if (password != null)
            {
                var token = await this._userManager.GeneratePasswordResetTokenAsync(OldAppUser);
                var passwordUpdateResult = await this._userManager.ResetPasswordAsync(OldAppUser, token, password);
            }

            var result = await this._userManager.UpdateAsync(OldAppUser);

            return OldAppUser;
        }

        public async Task<Pagination<AppUser>> GetAllAppUsersPaginated(int pageNumber, int pageSize)
        {
            var usersModel = this._userManager.Users.OrderByDescending(x => x.CreatedAt);


            var paginatedCategoriesModel = await Pagination<AppUser>.GetPaginatedData(usersModel, pageNumber, pageSize);


            return paginatedCategoriesModel;

        }

        public async Task<AppUser> GetAppUserById(int id)
        {
            var AppUserModel = await this._userManager.Users
                                                      .Where(x => x.Id == id)
                                                      .FirstOrDefaultAsync();

            return AppUserModel;

        }

        public async Task<bool> DeleteAppUser(int id)
        {

            var AppUserModel = await this._userManager.Users.Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();

            var result = await this._userManager.DeleteAsync(AppUserModel);

            return true;

        }

    }


}
