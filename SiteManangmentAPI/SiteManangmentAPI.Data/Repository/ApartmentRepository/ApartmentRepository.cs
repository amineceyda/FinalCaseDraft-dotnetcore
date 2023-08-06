using SiteManangmentAPI.Data.DBContext;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;


namespace SiteManangmentAPI.Data.Repository;

public class ApartmentRepository : GenericRepository<Apartment>, IApartmentRepository
{
    public ApartmentRepository(SimDbContext dbContext) : base(dbContext)
    {
    }
}
