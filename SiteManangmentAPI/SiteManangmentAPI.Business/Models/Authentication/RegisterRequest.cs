using SiteManangmentAPI.Base.Enums;

namespace SiteManangmentAPI.Business.Models;

public class RegisterRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string TCNo { get; set; }
    public string VehiclePlateNumber { get; set; }
}
