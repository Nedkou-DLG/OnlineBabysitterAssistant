using AutoMapper;
using OnlineBabysitterAssistant.Domain.Entities;
using OnlineBabysitterAssistant.Domain.Models.Child;
using OnlineBabysitterAssistant.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBabysitterAssistant.Domain.Interfaces.Repositories
{
    public interface IParentRepository : IGenericRepository<ParentRecord>
    {
        Task<IEnumerable<ChildModel>> GetChildren(int parentId, IConfigurationProvider configuration);
        Task<IEnumerable<UserModel>> GetBabysitters(int parentId, IConfigurationProvider configuration);
    }
}
