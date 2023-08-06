using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;

namespace SiteManangmentAPI.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BillingController : ControllerBase
{
    private readonly IBillingRepository _repository;
    private readonly IMapper _mapper;

    public BillingController(IBillingRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ApiResponse<List<BillingResponse>> GetAllBilling()
    {
        var entityList = _repository.GetAll();
        var mapped = _mapper.Map<List<Billing>, List<BillingResponse>>(entityList);
        return new ApiResponse<List<BillingResponse>>(mapped);
    }

    [HttpGet("{id}")]
    public ApiResponse<BillingResponse> GetBillingDetails(int id)
    {
        var entity = _repository.GetById(id);
        var mapped = _mapper.Map<Billing, BillingResponse>(entity);
        return new ApiResponse<BillingResponse>(mapped);
    }


    [HttpPost]
    public ApiResponse AddBilling([FromBody] BillingRequest request)
    {
        var entity = _mapper.Map<BillingRequest, Billing>(request);
        _repository.Insert(entity);
        _repository.Save();
        return new ApiResponse();
    }

    [HttpPut("{id}")]
    public ApiResponse UpdateBilling(int id, [FromBody] BillingRequest request)
    {
        var entity = _mapper.Map<BillingRequest, Billing>(request);
        entity.Id = id;
        _repository.Update(entity);
        _repository.Save();
        return new ApiResponse();
    }


    [HttpDelete("{id}")]
    public ApiResponse DeleteBilling(int id)
    {
        _repository.DeleteById(id);
        return new ApiResponse();
    }

}
