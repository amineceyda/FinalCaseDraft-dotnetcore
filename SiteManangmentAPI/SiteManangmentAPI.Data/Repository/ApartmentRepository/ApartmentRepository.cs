using SiteManangmentAPI.Data.DBContext;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository.BaseRepository;


namespace SiteManangmentAPI.Data.Repository.ApartmentRepository;

public class ApartmentRepository : GenericRepository<Apartment>, IApartmentRepository
{
    public ApartmentRepository(SimDbContext dbContext) : base(dbContext)
    {
    }
}
