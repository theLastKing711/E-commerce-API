using ECommerce.API.Models;

namespace ECommerce.API.Data.IRepos
{
  public interface IBaseRepo<T> where T : BaseEntity
  {


    Task<IQueryable<T>> GetAll();

    Task<T> GetById(int id);

    Task<T> Add(T item);

    Task<T> Update(int id, T entity);

    Task<Boolean> Remove(int id);

    Task SaveAsync();

  }
}
