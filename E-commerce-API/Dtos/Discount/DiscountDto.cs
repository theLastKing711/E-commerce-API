using ECommerce.API.Dtos;
using ECommerce.API.Dtos.Product;

namespace ECommerce.API.Dtos.Discount
{
    public class DiscountDto : DiscountBaseDto
    {

        public ProductDto Product { get; set; }

    }

}