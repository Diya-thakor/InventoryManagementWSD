using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class ProductItem
    {
        public long ProductId { get; set; }
        public Product? Product { get; set; }
        public long ItemId { get; set; }
        public Item? Item { get; set; }
        [Required]
        public long Quantity { get; set; }
    }
}