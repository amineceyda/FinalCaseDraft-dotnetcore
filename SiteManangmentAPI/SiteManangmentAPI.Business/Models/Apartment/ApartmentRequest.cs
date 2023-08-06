

using SiteManangmentAPI.Base.Enums;

namespace SiteManangmentAPI.Application.Models;

public class ApartmentRequest
{
    public int OwnerUserID { get; set; }
    public int TenantUserID { get; set; }
    public string Block { get; set; }
    public ApartmentStatus Status { get; set; }
    public ApartmentType Type { get; set; }
    public int Floor { get; set; }
    public string ApartmentNumber { get; set; }

}
