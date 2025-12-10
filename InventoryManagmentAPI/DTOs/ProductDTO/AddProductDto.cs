namespace InventoryManagmentAPI.DTOs.ProductDTO;

public class AddProductDto
{
    public string Name { get; set; }
    public string? Price { get; set; }
    public double? Ostatok { get; set; }
    public string? Description { get; set; }
    public long? CategoryId { get; set; }
    public long? SupplyId { get; set; }
}