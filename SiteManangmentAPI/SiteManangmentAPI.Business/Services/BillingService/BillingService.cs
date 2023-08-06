using AutoMapper;
using SiteManangmentAPI.Data.UnitOfWork;
using Serilog;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Data.Entities;

namespace SiteManangmentAPI.Business.Services;

public class BillingService : GenericService<Billing,BillingRequest, BillingResponse>, IBillingService
{
    public BillingService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
    }

}
