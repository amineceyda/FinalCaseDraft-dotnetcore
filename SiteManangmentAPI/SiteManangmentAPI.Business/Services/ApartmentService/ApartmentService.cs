using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.DBContext;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using Serilog;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Data.UnitOfWork;

namespace SiteManangmentAPI.Business.Services
{
    public class ApartmentService : GenericService<Apartment, ApartmentRequest, ApartmentResponse>, IApartmentService
    {
        private readonly SimDbContext _dbContext;

        public ApartmentService(IMapper mapper, IUnitOfWork unitOfWork, SimDbContext dbContext) : base(mapper, unitOfWork)
        {
            _dbContext = dbContext;
        }

        public ApiResponse<List<ApartmentResponse>> GetAllApartmentsWithInclude()
        {
            try
            {
                var apartments = _dbContext.Apartments
                    .Include(a => a.OwnerUser)
                    .Include(a => a.TenantUser)
                    .ToList();

                return new ApiResponse<List<ApartmentResponse>>(_mapper.Map<List<ApartmentResponse>>(apartments));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "ApartmentService.GetAllApartmentsWithInclude");
                return new ApiResponse<List<ApartmentResponse>>(ex.Message);
            }
        }

        public ApiResponse<ApartmentResponse> GetByIdWithInclude(int id)
        {
            try
            {
                var apartment = _dbContext.Apartments
                    .Include(a => a.OwnerUser)
                    .Include(a => a.TenantUser)
                    .FirstOrDefault(a => a.Id == id);

                if (apartment == null)
                {
                    return new ApiResponse<ApartmentResponse>("Apartment not found.");
                }

                return new ApiResponse<ApartmentResponse>(_mapper.Map<ApartmentResponse>(apartment));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "ApartmentService.GetByIdWithInclude");
                return new ApiResponse<ApartmentResponse>(ex.Message);
            }
        }
    }
}
