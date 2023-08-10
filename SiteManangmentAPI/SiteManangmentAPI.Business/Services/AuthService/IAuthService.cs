using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Business.Models;
using SiteManangmentAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManangmentAPI.Business.Services;

public interface IAuthService : IGenericService<User, RegisterRequest, UserResponse>
{

}
