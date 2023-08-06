
using SiteManangmentAPI.Base.BaseEntities;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;

namespace SiteManangmentAPI.Data.UnitOfWork;

public interface IUnitOfWork
{
    void Complete();
    IGenericRepository<Entity> DynamicRepository<Entity>() where Entity : BaseEntity;
    IGenericRepository<Apartment> ApartmentRepository { get; }
    IGenericRepository<Billing> BillingRepository { get; }
    IGenericRepository<Contact> ContactRepository { get; }
    IGenericRepository<Message> MessageRepository { get; }
    IGenericRepository<Payment> PaymentRepository { get; }
    IGenericRepository<User> UserRepository { get; }

}
