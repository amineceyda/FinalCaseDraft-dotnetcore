using SiteManangmentAPI.Data.DBContext;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository.BaseRepository;

namespace SiteManangmentAPI.Data.Repository.UserRepository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(SimDbContext dbContext) : base(dbContext)
    {
    }
}
