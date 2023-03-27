using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Product
    {
        public long Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Progress { get; set; }
        /* Here we might want to keep 
         * 0 --> Production is not started yet
         * 1 --> Raw material is not available
         * 2 --> Production is in progress
         * 3 --> Product is produced
         * */
        [Required]
        public float Profit { get; set; }
        public long Cost { get; set; }
        //Cost per unit
        [Required]
        public long Quantity { get; set; }
        // We don't have unit over here  because it might differ for different product
        [Required]
        public long OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        
        //public IList<ProductItem>? ProductItems { get; set; }
    }
}
