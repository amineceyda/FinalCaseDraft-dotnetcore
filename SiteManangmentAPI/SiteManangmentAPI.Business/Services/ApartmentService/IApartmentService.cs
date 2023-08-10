using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.Entities;
using System.Collections.Generic;

namespace SiteManangmentAPI.Business.Services
{
    public interface IApartmentService : IGenericService<Apartment, ApartmentRequest, ApartmentResponse>
    {
        ApiResponse<List<ApartmentResponse>> GetAllApartmentsWithInclude();
        ApiResponse<ApartmentResponse> GetByIdWithInclude(int id);
    }
}
