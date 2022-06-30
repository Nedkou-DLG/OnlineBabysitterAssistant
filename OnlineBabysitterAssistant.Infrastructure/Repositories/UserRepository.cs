using OnlineBabysitterAssistant.Domain.Entities;
using OnlineBabysitterAssistant.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBabysitterAssistant.Infrastructure.Repositories
{
    public class UserRepository:GenericRepository<UserRecord>, IUserRepository
    {
        public UserRepository(BabysitterContext context):base(context)
        {

        }
    }
}
