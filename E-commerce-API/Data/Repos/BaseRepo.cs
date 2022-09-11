using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos;
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ECommerce.API.Data.Repos
{
    public class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
    {

        public readonly DataContext _context;

        public BaseRepo(DataContext context)
        {
            _context = context;
        }


        public async Task<IQueryable<T>> GetAll()
        {
            return _context.Set<T>().AsNoTracking()
                                    .OrderByDescending(x => x.CreatedAt);
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _context.Set<T>()
                      .AsNoTracking()
                      .FirstOrDefaultAsync(e => e.Id == id);

            return entity;

        }

        public async Task<T> Add(T item)
        {
            var entity = _context.Set<T>().Add(item);

            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<T> Update(int id, T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

            return entity;

        }

        public async Task<Boolean> Remove(int id)
        {

            var entity = await this.GetById(id);

            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();

            return true;

        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
