using SiteManangmentAPI.Data.DBContext;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository.BaseRepository;


namespace SiteManangmentAPI.Data.Repository.ContactRepository;
public class ContactRepository : GenericRepository<Contact>, IContactRepository
{
    public ContactRepository(SimDbContext dbContext) : base(dbContext)
    {
    }
}
