using AutoMapper;
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

    [HttpGet]
    public ApiResponse<List<PaymentResponse>> GetAllPayments()
    {
        var response = _service.GetAll();
        return response;
    }

    [HttpGet("{id}")]
    public ApiResponse<PaymentResponse> GetPaymentDetails(int id)
    {
        var response = _service.GetById(id);
        return response;
    }


    [HttpPost]
    public ApiResponse AddPayment([FromBody] PaymentRequest request)
    {
        var response = _service.Insert(request);
        return response;
    }

    [HttpPut("{id}")]
    public ApiResponse UpdatePayment(int id, [FromBody] PaymentRequest request)
    {
        var response = _service.Update(id, request);
        return response;
    }


    [HttpDelete("{id}")]
    public ApiResponse DeletePayment(int id)
    {
        var response = _service.Delete(id);
        return response;
    }
}
