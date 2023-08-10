using AutoMapper;
using SiteManangmentAPI.Base.BaseEntities;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.UnitOfWork;
using Serilog;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Data.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace SiteManangmentAPI.Business.Services;

public class UserService : GenericService<User, UserRequest, UserResponse>, IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public int GetLoggedInUserId()
    {
        var userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        return userId;
    }

    public ApiResponse MakePayment(PaymentRequest paymentRequest)
    {
        var userId = GetLoggedInUserId();
        var user = _unitOfWork.UserRepository.GetById(userId);
        if (user == null)
        {
            Log.Warning($"User with ID {userId} not found.");
            return new ApiResponse("User not found.");
        }

        return new ApiResponse("Payment successful.");
    }

    public ApiResponse SendMessageToAdministrator(MessageRequest messageRequest)
    {
        var userId = GetLoggedInUserId();
        var user = _unitOfWork.UserRepository.GetById(userId);
        if (user == null)
        {
            Log.Warning($"User with ID {userId} not found.");
            return new ApiResponse("User not found.");
        }

        // Create a new message entity and save it to the database
        var message = _mapper.Map<Message>(messageRequest);
        message.SenderUserID = userId; 
        message.ReceiverUserID = 1; //for now

        _unitOfWork.MessageRepository.Insert(message);

        return new ApiResponse("Message sent successfully.");
    }

    public ApiResponse<List<BillingResponse>> GetApartmentBills(int apartmentId)
    {
        var userId = GetLoggedInUserId();
        // Get the authenticated user's ID from the claims
        var authenticatedUserId = Convert.ToInt32((Thread.CurrentPrincipal.Identity as ClaimsIdentity)?.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        // Check if the authenticated user is the same as the requested user
        if (authenticatedUserId != userId)
        {
            return new ApiResponse<List<BillingResponse>>("Unauthorized: You are not allowed to view bills for other users.");
        }

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

