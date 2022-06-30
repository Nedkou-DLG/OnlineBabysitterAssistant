using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineBabysitterAssistant.Domain.Entities;
using OnlineBabysitterAssistant.Domain.Interfaces.Repositories;
using OnlineBabysitterAssistant.Domain.Models.Child;
using OnlineBabysitterAssistant.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBabysitterAssistant.Infrastructure.Repositories
{
    public class BabysitterRepository:GenericRepository<BabysitterRecord>, IBabysitterRepository
    {
        public BabysitterRepository(BabysitterContext context):base(context)
        {

        }

        public async Task<IEnumerable<ChildModel>> GetChildren(int babysitterId, IConfigurationProvider configuration)
        {
            var babysitter = await AsQueryable().Include(x => x.Children).Include(x => x.Parents)
                                            .FirstOrDefaultAsync(x => x.Id == babysitterId);

            var children = babysitter?.Children.AsQueryable().ProjectTo<ChildModel>(configuration);

            return children.AsEnumerable();

        }

        public async Task<IEnumerable<UserModel>> GetParents(int babysitterId, IConfigurationProvider configuration)
        {
            var babysitter = await AsQueryable().Include(x => x.Parents)
                                            .FirstOrDefaultAsync(x => x.Id == babysitterId);

            var parents = babysitter?.Parents.AsQueryable().ProjectTo<UserModel>(configuration);

            return parents.AsEnumerable();

        }

        public override async Task<BabysitterRecord?> GetAsync(int id)
        {
            return await dbSet.Include(x => x.Children).Include(x => x.Parents).FirstAsync(x => x.Id == id);
        }
    }
}
