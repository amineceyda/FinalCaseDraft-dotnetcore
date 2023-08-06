
using SiteManangmentAPI.Base.BaseEntities;
using SiteManangmentAPI.Data.DBContext;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;
using SiteManangmentAPI.Data.UnitOfWork;

namespace SiteManangmentAPI.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{


    private readonly SimDbContext _dbContext;
    public UnitOfWork(SimDbContext dbContext)
    {
        _dbContext = dbContext;

        ApartmentRepository = new GenericRepository<Apartment>(dbContext);
        BillingRepository = new GenericRepository<Billing>(dbContext);
        ContactRepository = new GenericRepository<Contact>(dbContext);
        MessageRepository = new GenericRepository<Message>(dbContext);
        PaymentRepository = new GenericRepository<Payment>(dbContext);
        UserRepository = new GenericRepository<User>(dbContext);

    }

    public IGenericRepository<Apartment> ApartmentRepository { get; private set; }

    public IGenericRepository<Billing> BillingRepository { get; private set; }

    public IGenericRepository<Contact> ContactRepository { get; private set; }

    public IGenericRepository<Message> MessageRepository { get; private set; }

    public IGenericRepository<Payment> PaymentRepository { get; private set; }

    public IGenericRepository<User> UserRepository { get; private set; }

    public void Complete()
    {
        _dbContext.SaveChanges();
    }

    public IGenericRepository<Entity> DynamicRepository<Entity>() where Entity : BaseEntity
    {
        return new GenericRepository<Entity>(_dbContext);
    }
}
