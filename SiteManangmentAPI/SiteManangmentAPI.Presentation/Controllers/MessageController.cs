
using Microsoft.AspNetCore.Mvc;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository.MessageRepository;

namespace SiteManangmentAPI.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IMessageRepository _repository;

    public MessageController(IMessageRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ApiResponse<List<Message>> GetAllMessages()
    {
        var entityList = _repository.GetAll();
        return new ApiResponse<List<Message>>(entityList);
    }

    [HttpGet("{id}")]
    public ApiResponse<Message> GetMessageDetails(int id)
    {
        var entity = _repository.GetById(id);
        return new ApiResponse<Message>(entity);
    }


    [HttpPost]
    public ApiResponse AddMessage([FromBody] Message request)
    {
        _repository.Insert(request);
        return new ApiResponse();
    }

    [HttpPut("{id}")]
    public ApiResponse UpdateMessage(int id, [FromBody] Message request)
    {
        request.Id= id;
        _repository.Update(request);
        return new ApiResponse();
    }


    [HttpDelete("{id}")]
    public ApiResponse DeleteMessage(int id)
    {
        _repository.DeleteById(id);
        return new ApiResponse();
    }
}
