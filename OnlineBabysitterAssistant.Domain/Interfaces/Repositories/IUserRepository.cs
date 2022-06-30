using OnlineBabysitterAssistant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBabysitterAssistant.Domain.Interfaces.Repositories
{
    public interface IUserRepository:IGenericRepository<UserRecord>
    {
    }
}
