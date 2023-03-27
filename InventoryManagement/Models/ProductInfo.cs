namespace InventoryManagement.Models
{
    public class ProductInfo
    {
        public string? Name { get; set; }
        public int Unit { get; set; }
        public int QuantityPerUnit { get; set; }
        public int Cost { get; set; }
        public int Quantity { get; set; }
        public long QuantityInProduct { get; set; }

    }
}
