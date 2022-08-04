using ECommerce.API.Models;

namespace ECommerce.API.Models
{
    public class Category : BaseEntity
    {

        public IEnumerable<Product> Products { get; set; }



        public string Name { get; set; }

    }
}
