using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Business.Services;
using SiteManangmentAPI.Data.Entities;

public interface IUserService : IGenericService<User, UserRequest, UserResponse>
{

    ApiResponse MakePayment(int userId, PaymentRequest paymentRequest);
    ApiResponse SendMessageToAdministrator(int userId, MessageRequest messageRequest);
    ApiResponse<List<BillingResponse>> GetApartmentBills(int userId, int apartmentId);

}
