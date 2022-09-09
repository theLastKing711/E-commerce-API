namespace ECommerce.API.Dtos.Shared
{
    public class ProductFilter
    {
        public int StartValue { get; set; }

        public int EndValue { get; set; }

        public SortType SortType { get; set; }
    }
}
