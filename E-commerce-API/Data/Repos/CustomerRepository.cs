using ECommerce.API.Data.IRepos;
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Data.Repos
{
    public class CustomerRepository : BaseRepo<Customer>, ICustomerRepository
    {

        public CustomerRepository(DataContext context) : base(context)
        {
        }

        public async Task<Customer> AddCustomer(Customer Customer)
        {
            var CustomerModel = await this.Add(Customer);

            return CustomerModel;
        }

        public async Task<Customer> UpdateCustomer(Customer Customer)
        {
            var OldCustomerModel = await this._context.Customers
                                                      .Where(x => x.Id == Customer.Id)
                                                      .FirstOrDefaultAsync();

            OldCustomerModel.ImagePath = Customer.ImagePath ?? OldCustomerModel.ImagePath;

            await this._context.SaveChangesAsync();

            var updatedCustomer = await this._context.Customers
                                                     .Where(x => x.Id == Customer.Id)
                                                     .FirstOrDefaultAsync();

            return updatedCustomer;
        }

        public async Task<Pagination<Customer>> GetAllCustomersPaginated(int pageNumber, int pageSize)
        {
            var CustomersModel = this._context.Customers
                                            .OrderByDescending(x => x.CreatedAt);

            Pagination<Customer> paginatedCategoriesModel = await Pagination<Customer>.GetPaginatedData(CustomersModel, pageNumber, pageSize);


            return paginatedCategoriesModel;

        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var CustomerModel = await this._context.Customers.AsNoTracking()
                                                             .Where(e => e.Id == id)
                                                             .FirstOrDefaultAsync();

            return CustomerModel;

        }

    }


}
