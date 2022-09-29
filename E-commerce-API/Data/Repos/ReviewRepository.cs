using ECommerce.API.Data.IRepos;
using ECommerce.API.Dtos.Invoice;
using ECommerce.API.Dtos.InvoiceDetails;
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Data.Repos
{
    public class ReviewRepository : BaseRepo<Invoice>, IReviewRepository
    {

        public ReviewRepository(DataContext context) : base(context)
        {
        }

        // public async Task<IEnumerable<Review>> getReviewStats(int id)
        // {


        // }
    }


}
