
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;

namespace SiteManangmentAPI.Data.Repository;

public interface IUserRepository : IGenericRepository<User>
{
    void MakePayment(Payment payment);
    void SendMessageToAdministrator(Message message);

    List<Apartment> GetUserApartments(int userId);
}
