using SiteManangmentAPI.Data.DBContext;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;


namespace SiteManangmentAPI.Data.Repository;
public class ContactRepository : GenericRepository<Contact>, IContactRepository
{
    public ContactRepository(SimDbContext dbContext) : base(dbContext)
    {
    }
}
