using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Business.Services;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;

namespace SiteManangmentAPI.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BillingController : ControllerBase
{
    private readonly IBillingService _service;
    private readonly IMapper _mapper;

    public BillingController(IMapper mapper, IBillingService service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpGet]
    public ApiResponse<List<BillingResponse>> GetAllBilling()
    {
        var response = _service.GetAll();
        return response;
    }

    [HttpGet("{id}")]
    public ApiResponse<BillingResponse> GetBillingDetails(int id)
    {
        var response = _service.GetById(id);
        return response;
    }


    [HttpPost]
    public ApiResponse AddBilling([FromBody] BillingRequest request)
    {
        var response = _service.Insert(request);
        return response;
    }

    [HttpPut("{id}")]
    public ApiResponse UpdateBilling(int id, [FromBody] BillingRequest request)
    {
        var response = _service.Update(id, request);
        return response;
    }


    [HttpDelete("{id}")]
    public ApiResponse DeleteBilling(int id)
    {
        var response = _service.Delete(id);
        return response;
    }

}
