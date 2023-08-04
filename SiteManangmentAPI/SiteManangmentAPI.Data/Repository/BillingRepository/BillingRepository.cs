using SiteManangmentAPI.Data.DBContext;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository.BaseRepository;

namespace SiteManangmentAPI.Data.Repository.BillingRepository;

public class BillingRepository : GenericRepository<Billing>, IBillingRepository
{
    public BillingRepository(SimDbContext dbContext) : base(dbContext)
    {
    }
}
