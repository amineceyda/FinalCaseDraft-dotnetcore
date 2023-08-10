using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.Entities;

namespace SiteManangmentAPI.Business.Services;

public interface IBillingService : IGenericService<Billing, BillingRequest, BillingResponse>
{
    ApiResponse<List<BillingResponse>> GetAllBillingWithInclude();
    ApiResponse<BillingResponse> GetBillingByIdWithInclude(int id);
}
