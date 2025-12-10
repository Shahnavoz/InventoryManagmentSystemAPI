namespace InventoryManagmentAPI.Entities;

public class Product:BaseEntity
{
    public string Name { get; set; }
    public double Price { get; set; }
    public double Ostatok{get; set;}
    public string Description { get; set; }
    public long CategoryId { get; set; }
    public Category? Category { get; set; }
    public long SupplyId { get; set; }
    public Supply Supply { get; set; }
    
}