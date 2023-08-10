using SiteManangmentAPI.Data.DBContext;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;

namespace SiteManangmentAPI.Data.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(SimDbContext dbContext) : base(dbContext)
    {
    }
    public void MakePayment(Payment payment)
    {
        _dbContext.Payments.Add(payment);
        _dbContext.SaveChanges();
    }

    public void SendMessageToAdministrator(Message message)
    {
        _dbContext.Messages.Add(message);
        _dbContext.SaveChanges();
    }

    public List<Apartment> GetUserApartments(int userId)
    {
        return _dbContext.Users
            .Where(u => u.Id == userId)
            .SelectMany(u => u.OwnedApartments)
            .Union(_dbContext.Users.Where(u => u.Id == userId)
            .SelectMany(u => u.TenantedApartments))
            .ToList();
    }

    public User GetByUsername(string username)
    {
        return _dbContext.Users.SingleOrDefault(u => u.Username == username);
    }
}
