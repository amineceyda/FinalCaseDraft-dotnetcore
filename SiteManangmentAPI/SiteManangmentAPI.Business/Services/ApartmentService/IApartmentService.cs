using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Data.Entities;

namespace SiteManangmentAPI.Business.Services;

public interface IApartmentService : IGenericService<Apartment, ApartmentRequest, ApartmentResponse>
{
}
