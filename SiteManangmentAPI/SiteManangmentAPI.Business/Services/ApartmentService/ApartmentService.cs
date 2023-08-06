using AutoMapper;
using SiteManangmentAPI.Base.BaseEntities;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.UnitOfWork;
using Serilog;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Data.Entities;

namespace SiteManangmentAPI.Business.Services;

public class ApartmentService : GenericService<Apartment, ApartmentRequest, ApartmentResponse>, IApartmentService
{
    public ApartmentService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
    }

}
