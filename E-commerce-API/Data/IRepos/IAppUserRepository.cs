using ECommerce.API.Models;
using ECommerce.API.Models.Identity;

namespace ECommerce.API.Data.IRepos
{
    public interface IAppUserRepository
    {

        Task<Pagination<AppUser>> GetAllAppUsersPaginated(int pageNumber, int pageSize);

        Task<AppUser> GetAppUserById(int id);

        Task<AppUser> AddAppUser(AppUser AppUser, string password);

        Task<AppUser> UpdateAppUser(AppUser user, string password);

        Task<bool> DeleteAppUser(int id);

    }
}
