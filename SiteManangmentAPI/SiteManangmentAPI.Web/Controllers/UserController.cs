using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;

namespace SiteManangmentAPI.Web.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ApiResponse<List<UserResponse>> GetAllUser()
        {
            var entityList = _repository.GetAll();
            var mapped = _mapper.Map<List<User>, List<UserResponse>>(entityList);
            return new ApiResponse<List<UserResponse>>(mapped);
        }

        [HttpGet("{id}")]
        public ApiResponse<UserResponse> GetUserDetails(int id)
        {
            var entity = _repository.GetById(id);
            var mapped = _mapper.Map<User, UserResponse>(entity);
            return new ApiResponse<UserResponse>(mapped);
        }


        [HttpPost]
        public ApiResponse AddUser([FromBody] UserRequest request)
        {
            var entity = _mapper.Map<UserRequest, User>(request);
            _repository.Insert(entity);
            _repository.Save();
            return new ApiResponse();
        }

        [HttpPut("{id}")]
        public ApiResponse UpdateUser(int id, [FromBody] UserRequest request)
        {
            var entity = _mapper.Map<UserRequest, User>(request);
            entity.Id = id;
            _repository.Update(entity);
            _repository.Save();
            return new ApiResponse();
        }


        [HttpDelete("{id}")]
        public ApiResponse DeleteUser(int id)
        {
            _repository.DeleteById(id);
            return new ApiResponse();
        }

    }
}
