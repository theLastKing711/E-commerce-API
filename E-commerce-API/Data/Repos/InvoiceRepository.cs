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
                AppUserId = x.AppUserId,
                InvoicesDetails = InvoiceModel.InvoicesDetails.Select(x => new InvoiceDetails()
                {
                    Id = x.Id,
                    InvoiceId = x.InvoiceId,
                    ProdcutQuantity = x.ProdcutQuantity,
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
                                            .Include(e => e.InvoicesDetails)
                                                .ThenInclude(e => e.Customer)
                                            .Include(e => e.InvoicesDetails)
                                                .ThenInclude(e => e.Product)
                                            .Select(x => new Invoice()
                                            {
                                                Id = x.Id,
                                                InvoicesDetails = x.InvoicesDetails.Select(e => new InvoiceDetails()
                                                {
                                                    Id = e.Id,
                                                    Customer = e.Customer,
                                                    AppUserId = e.AppUserId,
                                                    InvoiceId = e.InvoiceId,
                                                    ProdcutQuantity = e.ProdcutQuantity,
                                                    Product = e.Product,
                                                    ProductId = e.ProductId
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
                                                    InvoicesDetails = e.InvoicesDetails.Select(x => new InvoiceDetails()
                                                    {
                                                        Id = x.Id,
                                                        Customer = x.Customer,
                                                        AppUserId = x.AppUserId,
                                                        InvoiceId = x.InvoiceId,
                                                        ProdcutQuantity = x.ProdcutQuantity,
                                                        Product = x.Product,
                                                        ProductId = x.ProductId
                                                    })
                                                })
                                                .Where(e => e.Id == id)
                                                .FirstOrDefaultAsync();

            return InvoiceDto;

        }

    }


}
