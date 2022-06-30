using AutoMapper;
using OnlineBabysitterAssistant.Domain.Entities;
using OnlineBabysitterAssistant.Domain.Models.Child;
using OnlineBabysitterAssistant.Domain.Models.User;

namespace OnlineBabysitterAssistant.Domain.Interfaces.Repositories
{
    public interface IBabysitterRepository:IGenericRepository<BabysitterRecord>
    {
        Task<IEnumerable<ChildModel>> GetChildren(int parentId, IConfigurationProvider configuration);
        Task<IEnumerable<UserModel>> GetParents(int babysitterId, IConfigurationProvider configuration);
    }
}
