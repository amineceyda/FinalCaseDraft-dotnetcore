using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Business.Models;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SiteManangmentAPI.Business.Models;
using SiteManangmentAPI.Data.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;

namespace SiteManangmentAPI.Business.Services;

public class AuthService : GenericService<User, RegisterRequest, UserResponse>, IAuthService
{
    private readonly IConfiguration _configuration;
    public AuthService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration configuration = null) : base(mapper, unitOfWork)
    {
        _configuration = configuration;
    }

}

