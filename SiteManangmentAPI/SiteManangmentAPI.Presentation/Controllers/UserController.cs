using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository.UserRepository;

namespace SiteManangmentAPI.Presentation.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ApiResponse<List<User>> GetAllUser()
        {
            var entityList = _repository.GetAll();
            return new ApiResponse<List<User>>(entityList);
        }

        [HttpGet("{id}")]
        public ApiResponse<User> GetUserDetails(int id)
        {
            var entity = _repository.GetById(id);
            return new ApiResponse<User>(entity);
        }


        [HttpPost]
        public ApiResponse AddUser([FromBody] User request)
        {
            _repository.Insert(request);
            return new ApiResponse();
        }

        [HttpPut("{id}")]
        public ApiResponse UpdateUser(int id, [FromBody] User request)
        {
            request.UserId = id;
            _repository.Update(request);
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
