
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Serilog;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.DBContext;
using SiteManangmentAPI.Data.UnitOfWork;

namespace SiteManangmentAPI.Business.Services;

public class BillingService : GenericService<Billing, BillingRequest, BillingResponse>, IBillingService
{
    private readonly SimDbContext _dbContext;

    public BillingService(IMapper mapper, IUnitOfWork unitOfWork, SimDbContext dbContext) : base(mapper, unitOfWork)
    {
        _dbContext = dbContext;
    }

    public ApiResponse<List<BillingResponse>> GetAllBillingWithInclude()
    {
        try
        {
            var billings = _dbContext.Billing
                .Include(b => b.Apartment)
                .ToList();

            return new ApiResponse<List<BillingResponse>>(_mapper.Map<List<BillingResponse>>(billings));
        }
        catch (Exception ex)
        {
            Log.Error(ex, "BillingService.GetAllBillingWithInclude");
            return new ApiResponse<List<BillingResponse>>(ex.Message);
        }
    }

    public ApiResponse<BillingResponse> GetBillingByIdWithInclude(int id)
    {
        try
        {
            var billing = _dbContext.Billing
                .Include(b => b.Apartment) 
                .FirstOrDefault(b => b.Id == id);

            if (billing == null)
            {
                return new ApiResponse<BillingResponse>("Billing not found");
            }

            return new ApiResponse<BillingResponse>(_mapper.Map<BillingResponse>(billing));
        }
        catch (Exception ex)
        {
            Log.Error(ex, "BillingService.GetBillingByIdWithInclude");
            return new ApiResponse<BillingResponse>(ex.Message);
        }
    }
}
