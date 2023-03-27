using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Item
    {
        public long Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]

        public int Unit { get; set; }
        [Required]
        public int QuantityPerUnit { get; set; }
        public int Cost { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public long OrganizationId { get; set; }
        /*public Organization? Organization { get; set; }*/
    
        //public IList<ProductItem>? ProductItems { get; set; }
    }
}
