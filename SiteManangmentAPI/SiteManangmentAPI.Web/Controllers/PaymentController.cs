using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Business.Services;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;

namespace SiteManangmentAPI.Web.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _service;
    private readonly IMapper _mapper;

    public PaymentController(IMapper mapper, IPaymentService service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpGet,Authorize(Roles = "Admin")]
    public ApiResponse<List<PaymentResponse>> GetAllPayments()
    {
        var response = _service.GetAllPaymentsWithInclude();
        return response;
    }

    [HttpGet("{id}"),Authorize]
    public ApiResponse<PaymentResponse> GetPaymentDetails(int id)
    {
        var response = _service.GetPaymentByIdWithInclude(id);
        return response;
    }


    [HttpPost("make-payment"), Authorize]
    public ApiResponse AddPayment([FromBody] PaymentRequest request)
    {
        var response = _service.Insert(request);
        return response;
    }

    [HttpPut("{id}"),Authorize]
    public ApiResponse UpdatePayment(int id, [FromBody] PaymentRequest request)
    {
        var response = _service.Update(id, request);
        return response;
    }


    [HttpDelete("{id}"), Authorize("Admin")]
    public ApiResponse DeletePayment(int id)
    {
        var response = _service.Delete(id);
        return response;
    }
}
