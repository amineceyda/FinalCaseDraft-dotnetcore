using AutoMapper;
using SiteManangmentAPI.Base.BaseEntities;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.UnitOfWork;
using Serilog;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.DBContext;
using Microsoft.EntityFrameworkCore;

namespace SiteManangmentAPI.Business.Services;

public class PaymentService : GenericService<Payment, PaymentRequest, PaymentResponse>, IPaymentService
{
    private readonly SimDbContext _dbContext;

    public PaymentService(IMapper mapper, IUnitOfWork unitOfWork, SimDbContext dbContext) : base(mapper, unitOfWork)
    {
        _dbContext = dbContext;
    }

    public ApiResponse<List<PaymentResponse>> GetAllPaymentsWithInclude()
    {
        try
        {
            var payments = _dbContext.Payments
                .Include(p => p.User) // Include the User navigation property
                .ToList();

            return new ApiResponse<List<PaymentResponse>>(_mapper.Map<List<PaymentResponse>>(payments));
        }
        catch (Exception ex)
        {
            Log.Error(ex, "PaymentService.GetAllPaymentsWithInclude");
            return new ApiResponse<List<PaymentResponse>>(ex.Message);
        }
    }

    public ApiResponse<PaymentResponse> GetPaymentByIdWithInclude(int id)
    {
        try
        {
            var payment = _dbContext.Payments
                .Include(p => p.User) 
                .FirstOrDefault(p => p.Id == id);

            if (payment == null)
            {
                return new ApiResponse<PaymentResponse>("Payment not found");
            }

            var paymentResponse = _mapper.Map<PaymentResponse>(payment);
            paymentResponse.UserName = payment.User.Username; 

            return new ApiResponse<PaymentResponse>(paymentResponse);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "PaymentService.GetPaymentByIdWithInclude");
            return new ApiResponse<PaymentResponse>(ex.Message);
        }
    }
}
