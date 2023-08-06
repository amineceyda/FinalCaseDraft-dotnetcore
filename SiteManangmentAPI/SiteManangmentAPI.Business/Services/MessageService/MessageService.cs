using AutoMapper;
using SiteManangmentAPI.Base.BaseEntities;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.UnitOfWork;
using Serilog;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;

namespace SiteManangmentAPI.Business.Services;

public class MessageService : GenericService<Message, MessageRequest, MessageResponse>, IMessageService
{
    public MessageService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
    }

    public Task<List<MessageResponse>> GetMessagesByUserId(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<MessageResponse> SendMessage(MessageRequest messageRequest)
    {
        throw new NotImplementedException();
    }
}
