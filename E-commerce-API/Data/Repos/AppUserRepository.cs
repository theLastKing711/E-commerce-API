using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos.Identity;
using ECommerce.API.Dtos.Identity.AppUser;
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

        public AppUserRepository(
                                    DataContext context,
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

        public async Task<AppUser> AddAppUser(AppUser user, string password, string role)
        {

            var result = await this._userManager.CreateAsync(user, password);

            var createdUser = await this._userManager.Users
                                                     .Where(x => x.UserName == user.UserName)
                                                     .FirstOrDefaultAsync();

            if (createdUser != null)
                await this._userManager.AddToRoleAsync(createdUser, role);

            return createdUser;
        }

        public async Task<AppUser> UpdateAppUser(AppUser user, string roleName, string? password)
        {
            var OldAppUser = await this._userManager.FindByNameAsync(user.UserName);

            OldAppUser.ImagePath = user.ImagePath ?? OldAppUser.ImagePath;

            OldAppUser.Email = user.Email;

            var userRoles = await _userManager.GetRolesAsync(user);

            var UserRolesRemoved = await this._userManager.RemoveFromRolesAsync(OldAppUser, userRoles);

            if (UserRolesRemoved.Succeeded)
            {
                await this._userManager.AddToRoleAsync(OldAppUser, roleName);
            }

            if (password != null)
            {
                var token = await this._userManager.GeneratePasswordResetTokenAsync(OldAppUser);
                var passwordUpdateResult = await this._userManager.ResetPasswordAsync(OldAppUser, token, password);
            }

            var result = await this._userManager.UpdateAsync(OldAppUser);

            return OldAppUser;
        }

        public async Task<Pagination<AppUser>> GetAllAppUsersPaginated(int pageNumber, int pageSize, string query, string active, string direction)
        {

            var usersModel = this._userManager.Users
                                 .Where(x => query == "-1" || (x.UserName.Contains(query) || x.Email.Contains(query) || x.Id.ToString().Contains(query)))
                                 .OrderByDescending(x => x.CreatedAt);

            IOrderedQueryable<AppUser>? orderedUsersModel;

            if (active != "-1" && direction != "-1")
            {

                switch (active)
                {
                    case "id":
                        orderedUsersModel = direction == "asc" ? usersModel.OrderBy(x => x.Id) : usersModel.OrderByDescending(x => x.Id);

                        break;

                    case "email":
                        orderedUsersModel = direction == "asc" ? usersModel.OrderBy(x => x.Email) : usersModel.OrderByDescending(x => x.Email);
                        break;

                    case "username":
                        orderedUsersModel = direction == "asc" ? usersModel.OrderBy(x => x.UserName) : usersModel.OrderByDescending(x => x.UserName);
                        break;

                    case "createdAt":
                        orderedUsersModel = direction == "asc" ? usersModel.OrderBy(x => x.CreatedAt) : usersModel.OrderByDescending(x => x.CreatedAt);
                        break;

                    default:
                        orderedUsersModel = usersModel.OrderByDescending(x => x.CreatedAt);
                        break;
                }
            }
            else
            {
                orderedUsersModel = usersModel.OrderByDescending(x => x.CreatedAt);
            }

            var paginatedCategoriesModel = await Pagination<AppUser>.GetPaginatedData(orderedUsersModel, pageNumber, pageSize);

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

        public async Task<bool> DeleteAppUsers(List<int> ids)
        {

            var AppUsersModel = await this._userManager.Users.Where(x => ids.Contains(x.Id))
                                          .ToListAsync();

            this._context.Users.RemoveRange(AppUsersModel);

            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<List<RoleItemDto>> GetAllRoles()
        {

            var AllRoles = _roleManager.Roles.Select(x => new RoleItemDto()
            {
                Id = x.Id,
                Name = x.Name
            });


            return AllRoles.ToList();

        }


    }


}
