using AutoMapper;
using SiteManangmentAPI.Base.BaseEntities;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.UnitOfWork;
using Serilog;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Data.Entities;

namespace SiteManangmentAPI.Business.Services;

public class UserService : GenericService<User, UserRequest, UserResponse>, IUserService
{
    public UserService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
    }

}
