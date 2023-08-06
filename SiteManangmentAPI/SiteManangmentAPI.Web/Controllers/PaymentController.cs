using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;

namespace SiteManangmentAPI.Web.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentRepository _repository;

    public PaymentController(IPaymentRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ApiResponse<List<Payment>> GetAllPayments()
    {
        var entityList = _repository.GetAll();
        return new ApiResponse<List<Payment>>(entityList);
    }

    [HttpGet("{id}")]
    public ApiResponse<Payment> GetPaymentDetails(int id)
    {
        var entity = _repository.GetById(id);
        return new ApiResponse<Payment>(entity);
    }


    [HttpPost]
    public ApiResponse AddPayment([FromBody] Payment request)
    {
        _repository.Insert(request);
        return new ApiResponse();
    }

    [HttpPut("{id}")]
    public ApiResponse UpdatePayment(int id, [FromBody] Payment request)
    {
        request.Id= id;
        _repository.Update(request);
        return new ApiResponse();
    }


    [HttpDelete("{id}")]
    public ApiResponse DeletePayment(int id)
    {
        _repository.DeleteById(id);
        return new ApiResponse();
    }
}
