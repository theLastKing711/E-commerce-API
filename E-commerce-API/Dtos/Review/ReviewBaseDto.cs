using ECommerce.API.Dtos;


namespace ECommerce.API.Dtos.Review
{
    public class ReviewBaseDto : BaseDto
    {
        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public decimal Rating { get; set; }

        public string Body { get; set; }

    }

}