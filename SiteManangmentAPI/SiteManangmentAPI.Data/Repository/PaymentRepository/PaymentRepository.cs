using SiteManangmentAPI.Data.DBContext;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;


namespace SiteManangmentAPI.Data.Repository;

public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
{
    public PaymentRepository(SimDbContext dbContext) : base(dbContext)
    {
    }
}
