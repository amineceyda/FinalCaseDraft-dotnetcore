using Microsoft.AspNetCore.Mvc;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository.ContactRepository;

namespace SiteManangmentAPI.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactRepository _repository;

    public ContactController(IContactRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ApiResponse<List<Contact>> GetAllContacts()
    {
        var entityList = _repository.GetAll();
        return new ApiResponse<List<Contact>>(entityList);
    }

    [HttpGet("{id}")]
    public ApiResponse<Contact> GetContactDetails(int id)
    {
        var entity = _repository.GetById(id);
        return new ApiResponse<Contact>(entity);
    }


    [HttpPost]
    public ApiResponse AddContact([FromBody] Contact request)
    {
        _repository.Insert(request);
        return new ApiResponse();
    }

    [HttpPut("{id}")]
    public ApiResponse UpdateContact(int id, [FromBody] Contact request)
    {
        request.ContactID = id;
        _repository.Update(request);
        return new ApiResponse();
    }


    [HttpDelete("{id}")]
    public ApiResponse DeleteContact(int id)
    {
        _repository.DeleteById(id);
        return new ApiResponse();
    }
}
