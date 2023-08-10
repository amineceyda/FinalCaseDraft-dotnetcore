namespace SiteManangmentAPI.Application.Models;

public class ApartmentResponse
{
    public string OwnerUserName { get; set; }
    public string TenantUserName { get; set; }
    public string Block { get; set; }
    public string Status { get; set; } 
    public string Type { get; set; }   
    public int Floor { get; set; }
    public string ApartmentNumber { get; set; }
}
