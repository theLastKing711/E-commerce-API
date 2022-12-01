using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos.Invoice;
using ECommerce.API.Dtos.InvoiceDetails;
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Data.Repos
{
    public class InvoiceRepository : BaseRepo<Invoice>, IInvoiceRepository
    {

        public InvoiceRepository(DataContext context) : base(context)
        {
        }

        public async Task<Invoice> AddInvoice(Invoice Invoice)
        {
            var InvoiceModel = await this.Add(Invoice);

            InvoiceModel = new Invoice()
            {
                Id = InvoiceModel.Id,
                CreatedAt = InvoiceModel.CreatedAt,
                AppUserId = InvoiceModel.AppUserId,
                InvoicesDetails = InvoiceModel.InvoicesDetails.Select(x => new InvoiceDetails()
                {
                    Id = x.Id,
                    InvoiceId = x.InvoiceId,
                    ProductQuantity = x.ProductQuantity,
                    ProductId = x.ProductId
                })
            };

            return InvoiceModel;
        }

        public async Task<Invoice> UpdateInvoice(Invoice Invoice)
        {
            var InvoiceModel = await this._context.Invoices
                                                      .Where(x => x.Id == Invoice.Id)

                                                      .FirstOrDefaultAsync();


            await this._context.SaveChangesAsync();

            var updatedInvoice = await this._context.Invoices
                                                     .Where(x => x.Id == Invoice.Id)
                                                     .FirstOrDefaultAsync();

            return updatedInvoice;
        }

        public async Task<Pagination<Invoice>> GetAllInvoicesPaginated(int pageNumber, int pageSize)
        {
            var InvoicesModel = this._context.Invoices
                                            .AsNoTracking()
                                            .Include(e => e.AppUser)
                                            .Include(e => e.InvoicesDetails)
                                            .Include(e => e.InvoicesDetails)
                                                .ThenInclude(e => e.Product)
                                            .Select(x => new Invoice()
                                            {
                                                Id = x.Id,
                                                AppUserId = x.AppUserId,
                                                AppUser = x.AppUser,
                                                InvoicesDetails = x.InvoicesDetails.Select(e => new InvoiceDetails()
                                                {
                                                    Id = e.Id,
                                                    InvoiceId = e.InvoiceId,
                                                    ProductQuantity = e.ProductQuantity,
                                                    Product = e.Product,
                                                    ProductId = e.ProductId,
                                                })
                                            });
            // .OrderByDescending(y => y.CreatedAt);


            Pagination<Invoice> paginatedInvoicesModel = await Pagination<Invoice>.GetPaginatedData(InvoicesModel, pageNumber, pageSize);


            return paginatedInvoicesModel;

        }

        public async Task<Invoice> GetInvoiceById(int id)
        {
            var InvoiceDto = await this._context.Invoices
                                                .AsNoTracking()
                                                .Include(e => e.InvoicesDetails)
                                                .Select(e => new Invoice()
                                                {
                                                    Id = e.Id,
                                                    AppUserId = e.AppUserId,
                                                    AppUser = e.AppUser,
                                                    InvoicesDetails = e.InvoicesDetails.Select(x => new InvoiceDetails()
                                                    {
                                                        Id = x.Id,
                                                        InvoiceId = x.InvoiceId,
                                                        ProductQuantity = x.ProductQuantity,
                                                        Product = x.Product,
                                                        ProductId = x.ProductId
                                                    })
                                                })
                                                .Where(e => e.Id == id)
                                                .FirstOrDefaultAsync();

            return InvoiceDto;

        }

        public async Task<bool> DeleteInvoicesRange(IEnumerable<int> ids)
        {

            var invoicesModel = await this._context.Invoices.Where(x => ids.ToList().Contains(x.Id))
                                                            .ToListAsync();

            this._context.Invoices.RemoveRange(invoicesModel);

            return true;

        }



    }


}
