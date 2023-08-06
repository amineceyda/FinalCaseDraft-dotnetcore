using AutoMapper;
using SiteManangmentAPI.Base.BaseEntities;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.UnitOfWork;
using Serilog;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Data.Entities;

namespace SiteManangmentAPI.Business.Services;

public class PaymentService : GenericService<Payment, PaymentRequest, PaymentResponse>, IPaymentService
{
    public PaymentService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
    }

}
