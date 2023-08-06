using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManangmentAPI.Application.Models;

public class UserResponse
{
    public string Username { get; set; }
    public string UserType { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string TCNo { get; set; }
    public string VehiclePlateNumber { get; set; }

}
