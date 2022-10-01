using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerce.API.Models;

namespace ECommerce.API.Models
{
    public class Inventory : BaseEntity
    {

        [Required, ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int CurrentAmount { get; set; }

    }
}
