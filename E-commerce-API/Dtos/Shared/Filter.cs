namespace ECommerce.API.Dtos.Shared
{
    public class Filter
    {

        public string? query { get; set; }

        public int? Stars { get; set; } = null;

        public ProductFilter? Price { get; set; }

    }
}
