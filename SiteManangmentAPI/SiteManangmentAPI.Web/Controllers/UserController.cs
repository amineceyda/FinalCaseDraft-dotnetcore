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
 
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet,Authorize("Admin")]
        public ApiResponse<List<UserResponse>> GetAllUser()
        {
            var response = _service.GetAll();
            return response;
        }

        [HttpGet("{id}"), Authorize("Admin")]
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

        [HttpPut("{id}"), Authorize("Admin")]
        public ApiResponse UpdateUser(int id, [FromBody] UserRequest request)
        {
            var response = _service.Update(id, request);
            return response;
        }

        [HttpDelete("{id}"), Authorize("Admin")]
        public ApiResponse DeleteUser(int id)
        {
            var response = _service.Delete(id);
            return response;
        }

        [HttpPost("make-payment"),Authorize]
        public ApiResponse MakePayment([FromBody] PaymentRequest paymentRequest)
        {
            var response = _service.MakePayment(paymentRequest);
            return response;
        }

        [HttpPost("send-message"), Authorize]
        public ApiResponse SendMessageToAdministrator([FromBody] MessageRequest messageRequest)
        {
            var response = _service.SendMessageToAdministrator(messageRequest);
            return response;
        }


        [HttpGet("apartments/{apartmentId}/bills"), Authorize]
        public ApiResponse<List<BillingResponse>> GetUserApartmentBills(int apartmentId)
        {
            var response = _service.GetApartmentBills(apartmentId);
            return response;
        }
    }
}
