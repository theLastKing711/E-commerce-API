using ECommerce.API.Models;

namespace ECommerce.API.Data.IRepos
{
    public interface ICustomerRepository : IBaseRepo<Customer>
    {
        Task<Customer> AddCustomer(Customer Customer);

        Task<Pagination<Customer>> GetAllCustomersPaginated(int pageNumber, int pageSize);

        Task<Customer> GetCustomerById(int id);


        Task<Customer> UpdateCustomer(Customer Customer);

    }
}
