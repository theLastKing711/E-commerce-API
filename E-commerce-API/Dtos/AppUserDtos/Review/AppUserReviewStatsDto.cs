
namespace ECommerce.API.Dtos.AppUserDtos.Review
{
    public class AppUserReviewStatsDto
    {

        public decimal TotalRating { get; set; }

        public IEnumerable<AppUserReviewStatsDetailsDto> StarStats { get; set; }


    }
}
