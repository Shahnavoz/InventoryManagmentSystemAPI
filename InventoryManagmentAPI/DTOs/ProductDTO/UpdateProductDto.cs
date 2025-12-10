namespace InventoryManagmentAPI.DTOs.ProductDTO;

public class UpdateProductDto
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public double? Price { get; set; }   
}