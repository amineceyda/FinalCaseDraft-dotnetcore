using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using SiteManangmentAPI.Business.Models;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace SiteManangmentAPI.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    public static User user = new User();
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AuthController(IConfiguration configuration, IUserRepository userRepository, IMapper mapper)
    {
        _configuration = configuration;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(RegisterRequest request)
    {
        try
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                // Map properties from request to User entity
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                UserType = Base.Enums.UserType.Admin,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                VehiclePlateNumber = request.VehiclePlateNumber,
                TCNo = request.TCNo
            };

            _userRepository.Insert(user);

            _userRepository.Save(); 

            Log.Information("User registered successfully: {@User}", user); 
            return Ok("User registered successfully");
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred during user registration");
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred during user registration");
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(LoginRequest request)
    {
        try
        {
            var user = _userRepository.GetByUsername(request.Username); 

            if (user == null)
            {
                return BadRequest("User not found.");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(user);

            return Ok(token);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred during user login");
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred during user login");
        }
    }

    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, "Admin")
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}
