using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Business.Services;
using SiteManangmentAPI.Data.Entities;

public interface IUserService : IGenericService<User, UserRequest, UserResponse>
{

    ApiResponse MakePayment(PaymentRequest paymentRequest);
    ApiResponse SendMessageToAdministrator(MessageRequest messageRequest);
    ApiResponse<List<BillingResponse>> GetApartmentBills(int apartmentId);

}
