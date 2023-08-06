
using SiteManangmentAPI.Base.Enums;

namespace SiteManangmentAPI.Application.Models;

public class ApartmentResponse
{
    public string OwnerUserName { get; set; }
    public string TenantUserName { get; set; }
    public string Block { get; set; }
    public ApartmentStatus Status { get; set; }
    public ApartmentType Type { get; set; }
    public int Floor { get; set; }
    public string ApartmentNumber { get; set; }
}
