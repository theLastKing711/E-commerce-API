using ECommerce.API.Dtos;


namespace ECommerce.API.Dtos.Discount
{
    public class DiscountBaseDto : BaseDto
    {

        public int ProductId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Value { get; set; }

    }

}