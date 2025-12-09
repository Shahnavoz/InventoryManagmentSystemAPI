namespace InventoryManagmentAPI.Entities;

public class Supplier:BaseEntity
{
    public string CompanyName { get; set; }
    public string ContactEmail { get; set; }
    public string PhoneNumber { get; set; }
    public long SupplyId { get; set; }
    public Supply Supply { get; set; }
    
}