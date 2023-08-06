using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Business.Services;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;

namespace SiteManangmentAPI.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactService _service;
    private readonly IMapper _mapper;

    public ContactController(IMapper mapper, IContactService service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpGet]
    public ApiResponse<List<ContactResponse>> GetAllContacts()
    {
        var response = _service.GetAll();
        return response;
    }

    [HttpGet("{id}")]
    public ApiResponse<ContactResponse> GetContactDetails(int id)
    {
        var response = _service.GetById(id);
        return response;
    }


    [HttpPost]
    public ApiResponse AddContact([FromBody] ContactRequest request)
    {
        var response = _service.Insert(request);
        return response;

    }

    [HttpPut("{id}")]
    public ApiResponse UpdateContact(int id, [FromBody] ContactRequest request)
    {
        var response = _service.Update(id, request);
        return response;
    }


    [HttpDelete("{id}")]
    public ApiResponse DeleteContact(int id)
    {
        var response = _service.Delete(id);
        return response;
    }
}
