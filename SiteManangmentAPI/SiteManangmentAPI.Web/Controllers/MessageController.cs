using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Business.Services;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;
using SiteManangmentAPI.Web.Services;
using System.Data;

namespace SiteManangmentAPI.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class MessageController : ControllerBase
{
    private readonly IMessageService _service;
    private readonly IMapper _mapper;
    private readonly RabbitMQService _rabbitMQService;

    public MessageController(IMapper mapper, IMessageService service, RabbitMQService rabbitMQService)
    {
        _mapper = mapper;
        _service = service;
        _rabbitMQService = rabbitMQService;
    }

    [HttpGet]
    public ApiResponse<List<MessageResponse>> GetAllMessages()
    {
        var response = _service.GetAll();
        return response;
    }

    [HttpGet("{id}")]
    public ApiResponse<MessageResponse> GetMessageDetails(int id)
    {
        var response = _service.GetById(id);
        return response;
    }


    [HttpPost]
    public ApiResponse AddMessage([FromBody] MessageRequest request)
    {
        var response = _service.Insert(request);
        return response;
    }

    [HttpPut("{id}")]
    public ApiResponse UpdateMessage(int id, [FromBody] MessageRequest request)
    {
        var response = _service.Update(id, request);
        return response;
    }


    [HttpDelete("{id}")]
    public ApiResponse DeleteMessage(int id)
    {
        var response = _service.Delete(id);
        return response;
    }

    [HttpPost("send")]
    public IActionResult SendMessageToAdmin([FromBody] string message)
    {
        _rabbitMQService.SendMessage(message);
        return Ok("Message sent to admin.");
    }
}
