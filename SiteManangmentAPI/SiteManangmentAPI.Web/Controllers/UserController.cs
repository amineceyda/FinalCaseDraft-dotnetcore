using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Business.Services;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;

namespace SiteManangmentAPI.Web.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public ApiResponse<List<UserResponse>> GetAllUser()
        {
            var response = _service.GetAll();
            return response;
        }

        [HttpGet("{id}")]
        public ApiResponse<UserResponse> GetUserDetails(int id)
        {
            var response = _service.GetById(id);
            return response;
        }


        [HttpPost]
        public ApiResponse AddUser([FromBody] UserRequest request)
        {
            var response = _service.Insert(request);
            return response;
        }

        [HttpPut("{id}")]
        public ApiResponse UpdateUser(int id, [FromBody] UserRequest request)
        {
            var response = _service.Update(id, request);
            return response;
        }


        [HttpDelete("{id}")]
        public ApiResponse DeleteUser(int id)
        {
            var response = _service.Delete(id);
            return response;
        }

    }
}
