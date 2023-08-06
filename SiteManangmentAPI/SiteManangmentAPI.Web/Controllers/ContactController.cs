using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;

namespace SiteManangmentAPI.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactRepository _repository;
    private readonly IMapper _mapper;

    public ContactController(IContactRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ApiResponse<List<ContactResponse>> GetAllContacts()
    {
        var entityList = _repository.GetAll();
        var mapped = _mapper.Map<List<Contact>, List<ContactResponse>>(entityList);
        return new ApiResponse<List<ContactResponse>>(mapped);
    }

    [HttpGet("{id}")]
    public ApiResponse<ContactResponse> GetContactDetails(int id)
    {
        var entity = _repository.GetById(id);
        var mapped = _mapper.Map<Contact, ContactResponse>(entity);
        return new ApiResponse<ContactResponse>(mapped);
    }


    [HttpPost]
    public ApiResponse AddContact([FromBody] ContactRequest request)
    {
        var entity = _mapper.Map<ContactRequest, Contact>(request);
        _repository.Insert(entity);
        _repository.Save();
        return new ApiResponse();

    }

    [HttpPut("{id}")]
    public ApiResponse UpdateContact(int id, [FromBody] ContactRequest request)
    {
        var entity = _mapper.Map<ContactRequest, Contact>(request);
        entity.Id = id;
        _repository.Update(entity);
        _repository.Save();
        return new ApiResponse();
    }


    [HttpDelete("{id}")]
    public ApiResponse DeleteContact(int id)
    {
        _repository.DeleteById(id);
        return new ApiResponse();
    }
}
