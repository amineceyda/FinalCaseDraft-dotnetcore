using SiteManangmentAPI.Data.DBContext;
using SiteManangmentAPI.Data.Entities;
using SiteManangmentAPI.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManangmentAPI.Data.Repository;

public class MessageRepository : GenericRepository<Message>, IMessageRepository
{
    public MessageRepository(SimDbContext dbContext) : base(dbContext)
    {
    }
}
