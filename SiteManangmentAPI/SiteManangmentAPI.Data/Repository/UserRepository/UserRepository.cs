using SiteManangmentAPI.Data.DBContext;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;

namespace SiteManangmentAPI.Data.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(SimDbContext dbContext) : base(dbContext)
    {
    }
}
