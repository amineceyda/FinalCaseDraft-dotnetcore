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
public class ApartmentController : ControllerBase
{
    private readonly IApartmentService _service;
    private readonly IMapper _mapper;

    public ApartmentController(IMapper mapper, IApartmentService service)
    {

        _mapper = mapper;
        _service = service;
    }

    [HttpGet]
    public ApiResponse<List<ApartmentResponse>> GetAllApartments()
    {
        var response = _service.GetAllApartmentsWithInclude();
        return response;
    }

    [HttpGet("{id}")]
    public ApiResponse<ApartmentResponse> GetApartmentDetails(int id)
    {
        var response = _service.GetByIdWithInclude(id);
        return response;
    }


    [HttpPost]
    public ApiResponse AddApartment([FromBody] ApartmentRequest request)
    {
        var response = _service.Insert(request);
        return response;
    }

    [HttpPut("{id}")]
    public ApiResponse UpdateApartment(int id, [FromBody] ApartmentRequest request)
    {

        var response = _service.Update(id, request);
        return response;
    }


    [HttpDelete("{id}")]
    public ApiResponse DeleteApartment(int id)
    {
        var response = _service.Delete(id);
        return response;
    }


}
