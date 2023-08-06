using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.Entities;

namespace SiteManangmentAPI.Business.Services;

public interface IMessageService : IGenericService<Message, MessageRequest, MessageResponse>
{

}