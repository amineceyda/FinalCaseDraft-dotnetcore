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
public class ApartmentController : ControllerBase
{
    private readonly IApartmentRepository _repository;
    private readonly IMapper _mapper;

    public ApartmentController(IApartmentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ApiResponse<List<ApartmentResponse>> GetAllApartments()
    {
        var entityList = _repository.GetAll();
        var mapped = _mapper.Map<List<Apartment>, List<ApartmentResponse>>(entityList);
        return new ApiResponse<List<ApartmentResponse>>(mapped);
    }

    [HttpGet("{id}")]
    public ApiResponse<ApartmentResponse> GetApartmentDetails(int id)
    {
        var entity = _repository.GetById(id);
        var mapped = _mapper.Map<Apartment, ApartmentResponse>(entity);
        return new ApiResponse<ApartmentResponse>(mapped);
    }


    [HttpPost]
    public ApiResponse AddApartment([FromBody] ApartmentRequest request)
    {
        var entity = _mapper.Map<ApartmentRequest, Apartment>(request);
        _repository.Insert(entity);
        _repository.Save();
        return new ApiResponse();
    }

    [HttpPut("{id}")]
    public ApiResponse UpdateApartment(int id, [FromBody] ApartmentRequest request)
    {
        var entity = _mapper.Map<ApartmentRequest, Apartment>(request);
        entity.Id = id;
        _repository.Update(entity);
        _repository.Save();
        return new ApiResponse();
    }


    [HttpDelete("{id}")]
    public ApiResponse DeleteApartment(int id)
    {
        _repository.DeleteById(id);
        return new ApiResponse();
    }


}
