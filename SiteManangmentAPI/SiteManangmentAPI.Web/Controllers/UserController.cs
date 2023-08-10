using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize("Admin")]
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
        /* in AuthController
        [HttpPost]
        public ApiResponse AddUser([FromBody] UserRequest request)
        {
            var response = _service.Insert(request);
            return response;
        }*/

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

        [HttpPost("{userId}/make-payment")]
        public ApiResponse MakePayment(int userId, [FromBody] PaymentRequest paymentRequest)
        {
            var response = _service.MakePayment(userId, paymentRequest);
            return response;
        }

        [HttpPost("{userId}/send-message")]
        public ApiResponse SendMessageToAdministrator(int userId, [FromBody] MessageRequest messageRequest)
        {
            var response = _service.SendMessageToAdministrator(userId, messageRequest);
            return response;
        }


        [HttpGet("{id}/apartments/{apartmentId}/bills")]
        public ApiResponse<List<BillingResponse>> GetUserApartmentBills(int id, int apartmentId)
        {
            var response = _service.GetApartmentBills(id, apartmentId);
            return response;
        }
    }
}
