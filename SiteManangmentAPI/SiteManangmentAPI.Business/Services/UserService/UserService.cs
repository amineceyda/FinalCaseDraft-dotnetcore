using AutoMapper;
using SiteManangmentAPI.Base.BaseEntities;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.UnitOfWork;
using Serilog;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Data.Entities;

namespace SiteManangmentAPI.Business.Services;

public class UserService : GenericService<User, UserRequest, UserResponse>, IUserService
{
    public UserService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
    }

    public ApiResponse MakePayment(int userId, PaymentRequest paymentRequest)
    {
        var user = _unitOfWork.UserRepository.GetById(userId);
        if (user == null)
        {
            Log.Warning($"User with ID {userId} not found.");
            return new ApiResponse("User not found.");
        }

        return new ApiResponse("Payment successful.");
    }

    public ApiResponse SendMessageToAdministrator(int userId, MessageRequest messageRequest)
    {

        var user = _unitOfWork.UserRepository.GetById(userId);
        if (user == null)
        {
            Log.Warning($"User with ID {userId} not found.");
            return new ApiResponse("User not found.");
        }

        // Create a new message entity and save it to the database
        var message = _mapper.Map<Message>(messageRequest);
        message.SenderUserID = userId; 
        //message.ReceiverUserID = null; 

        _unitOfWork.MessageRepository.Insert(message);

        return new ApiResponse("Message sent successfully.");
    }

    public ApiResponse<List<BillingResponse>> GetApartmentBills(int userId, int apartmentId)
    {
        var user = _unitOfWork.UserRepository.GetById(userId);
        if (user == null)
        {
            return new ApiResponse<List<BillingResponse>>("User not found.");
        }

        var apartment = _unitOfWork.ApartmentRepository.GetById(apartmentId);
        if (apartment == null)
        {
            return new ApiResponse<List<BillingResponse>>("Apartment not found.");
        }

        var bills = apartment.Bills;
        var billingResponses = _mapper.Map<List<BillingResponse>>(bills);
        return new ApiResponse<List<BillingResponse>>(billingResponses);
    }
}

