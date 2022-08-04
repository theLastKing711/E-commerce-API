using ECommerce.API.Models;

namespace ECommerce.API.Data.IRepos
{
    public interface IInvoiceRepository : IBaseRepo<Invoice>
    {
        Task<Invoice> AddInvoice(Invoice Invoice);

        Task<Pagination<Invoice>> GetAllInvoicesPaginated(int pageNumber, int pageSize);

        Task<Invoice> GetInvoiceById(int id);


        Task<Invoice> UpdateInvoice(Invoice Invoice);

    }
}
