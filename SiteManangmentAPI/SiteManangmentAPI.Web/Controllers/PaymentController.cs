using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;

namespace SiteManangmentAPI.Web.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentRepository _repository;
    private readonly IMapper _mapper;

    public PaymentController(IPaymentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ApiResponse<List<PaymentResponse>> GetAllPayments()
    {
        var entityList = _repository.GetAll();
        var mapped = _mapper.Map<List<Payment>, List<PaymentResponse>>(entityList);
        return new ApiResponse<List<PaymentResponse>>(mapped);
    }

    [HttpGet("{id}")]
    public ApiResponse<PaymentResponse> GetPaymentDetails(int id)
    {
        var entity = _repository.GetById(id);
        var mapped = _mapper.Map<Payment, PaymentResponse>(entity);
        return new ApiResponse<PaymentResponse>(mapped);
    }


    [HttpPost]
    public ApiResponse AddPayment([FromBody] PaymentRequest request)
    {
        var entity = _mapper.Map<PaymentRequest, Payment>(request);
        _repository.Insert(entity);
        _repository.Save();
        return new ApiResponse();
    }

    [HttpPut("{id}")]
    public ApiResponse UpdatePayment(int id, [FromBody] PaymentRequest request)
    {
        var entity = _mapper.Map<PaymentRequest, Payment>(request);
        entity.Id = id;
        _repository.Update(entity);
        _repository.Save();
        return new ApiResponse();
    }


    [HttpDelete("{id}")]
    public ApiResponse DeletePayment(int id)
    {
        _repository.DeleteById(id);
        return new ApiResponse();
    }
}
