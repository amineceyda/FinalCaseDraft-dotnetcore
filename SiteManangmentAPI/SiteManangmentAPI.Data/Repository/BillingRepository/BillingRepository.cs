using SiteManangmentAPI.Data.DBContext;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;

namespace SiteManangmentAPI.Data.Repository;

public class BillingRepository : GenericRepository<Billing>, IBillingRepository
{
    public BillingRepository(SimDbContext dbContext) : base(dbContext)
    {
    }
}
