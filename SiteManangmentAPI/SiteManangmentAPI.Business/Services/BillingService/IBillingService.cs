using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.Entities;

namespace SiteManangmentAPI.Business.Services
{
    public interface IBillingService : IGenericService<Billing, BillingRequest, BillingResponse>
    {
        // Add any additional methods specific to the Billing entity if needed
    }
}
