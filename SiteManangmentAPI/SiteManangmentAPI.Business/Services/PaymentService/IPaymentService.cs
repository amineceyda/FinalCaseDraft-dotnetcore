using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.Entities;

namespace SiteManangmentAPI.Business.Services;

public interface IPaymentService : IGenericService<Payment, PaymentRequest, PaymentResponse>
{

}
