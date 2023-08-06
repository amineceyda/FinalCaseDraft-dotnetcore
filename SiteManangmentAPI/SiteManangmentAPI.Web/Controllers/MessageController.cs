
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;

namespace SiteManangmentAPI.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IMessageRepository _repository;
    private readonly IMapper _mapper;

    public MessageController(IMessageRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ApiResponse<List<MessageResponse>> GetAllMessages()
    {
        var entityList = _repository.GetAll();
        var mapped = _mapper.Map<List<Message>, List<MessageResponse>>(entityList);
        return new ApiResponse<List<MessageResponse>>(mapped);
    }

    [HttpGet("{id}")]
    public ApiResponse<MessageResponse> GetMessageDetails(int id)
    {
        var entity = _repository.GetById(id);
        var mapped = _mapper.Map<Message, MessageResponse>(entity);
        return new ApiResponse<MessageResponse>(mapped);
    }


    [HttpPost]
    public ApiResponse AddMessage([FromBody] MessageRequest request)
    {
        var entity = _mapper.Map<MessageRequest, Message>(request);
        _repository.Insert(entity);
        _repository.Save();
        return new ApiResponse();
    }

    [HttpPut("{id}")]
    public ApiResponse UpdateMessage(int id, [FromBody] MessageRequest request)
    {
        var entity = _mapper.Map<MessageRequest, Message>(request);
        entity.Id = id;
        _repository.Update(entity);
        _repository.Save();
        return new ApiResponse();
    }


    [HttpDelete("{id}")]
    public ApiResponse DeleteMessage(int id)
    {
        _repository.DeleteById(id);
        return new ApiResponse();
    }
}
