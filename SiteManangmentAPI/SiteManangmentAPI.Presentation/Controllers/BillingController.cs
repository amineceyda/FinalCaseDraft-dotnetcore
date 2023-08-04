using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository.ApartmentRepository;
using SiteManangmentAPI.Data.Repository.BillingRepository;

namespace SiteManangmentAPI.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BillingController : ControllerBase
{
    private readonly IBillingRepository _repository;

    public BillingController(IBillingRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ApiResponse<List<Billing>> GetAllBilling()
    {
        var entityList = _repository.GetAll();
        return new ApiResponse<List<Billing>>(entityList);
    }

    [HttpGet("{id}")]
    public ApiResponse<Billing> GetBillingDetails(int id)
    {
        var entity = _repository.GetById(id);
        return new ApiResponse<Billing>(entity);
    }


    [HttpPost]
    public ApiResponse AddBilling([FromBody] Billing request)
    {
        _repository.Insert(request);
        return new ApiResponse();
    }

    [HttpPut("{id}")]
    public ApiResponse UpdateBilling(int id, [FromBody] Billing request)
    {
        request.Id = id;
        _repository.Update(request);
        return new ApiResponse();
    }


    [HttpDelete("{id}")]
    public ApiResponse DeleteBilling(int id)
    {
        _repository.DeleteById(id);
        return new ApiResponse();
    }

}
