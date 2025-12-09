namespace InventoryManagmentAPI.Entities;

public class Category:BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
    
    List<Product> Products { get; set; }

}