using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;

namespace SiteManangmentAPI.Web.Controllers;


[Route("api/[controller]s")]
[ApiController]
public class ApartmentController : ControllerBase
{
    private readonly IApartmentRepository _repository;

    public ApartmentController(IApartmentRepository repository)
    {
            _repository = repository;
    }

    [HttpGet]
    public ApiResponse<List<Apartment>> GetAllApartments()
    {
        var entityList = _repository.GetAll();
        return new ApiResponse<List<Apartment>>(entityList);
    }

    [HttpGet("{id}")]
    public ApiResponse<Apartment> GetApartmentDetails(int id)
    {
        var entity = _repository.GetById(id);
        return new ApiResponse<Apartment>(entity);
    }


    [HttpPost]
    public ApiResponse AddApartment([FromBody] Apartment request)
    {
        _repository.Insert(request);
        return new ApiResponse();
    }

    [HttpPut("{id}")]
    public ApiResponse UpdateApartment(int id, [FromBody] Apartment request)
    {
        request.Id = id;
        _repository.Update(request);
        return new ApiResponse();
    }


    [HttpDelete("{id}")]
    public ApiResponse DeleteApartment(int id)
    {
        _repository.DeleteById(id);
        return new ApiResponse();
    }


}
