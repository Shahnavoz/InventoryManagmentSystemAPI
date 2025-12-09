namespace InventoryManagmentAPI.Entities;

public class SupplyProduct:BaseEntity
{
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public long SupplyId { get; set; }
    public Supply Supply { get; set; }
    public int ProductCount { get; set; }
}