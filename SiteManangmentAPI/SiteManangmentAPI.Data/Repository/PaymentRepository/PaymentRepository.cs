using SiteManangmentAPI.Data.DBContext;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository.BaseRepository;


namespace SiteManangmentAPI.Data.Repository.PaymentRepository;

public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
{
    public PaymentRepository(SimDbContext dbContext) : base(dbContext)
    {
    }
}
