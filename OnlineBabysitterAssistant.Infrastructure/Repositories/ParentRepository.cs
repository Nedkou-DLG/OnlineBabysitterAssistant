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
    public class ParentRepository : GenericRepository<ParentRecord>, IParentRepository
    {
        public ParentRepository(BabysitterContext context):base(context)
        {

        }

        public async Task<IEnumerable<ChildModel>> GetChildren(int parentId, IConfigurationProvider configuration)
        {
            var parent = await AsQueryable().Include(x => x.Children)
                                            .FirstOrDefaultAsync(x => x.Id == parentId);

            var children = parent?.Children.AsQueryable().ProjectTo<ChildModel>(configuration);

            return children.AsEnumerable();

        }

        public async Task<IEnumerable<UserModel>> GetBabysitters(int parentId, IConfigurationProvider configuration)
        {
            var parent = await AsQueryable().Include(x => x.Babysitters)
                                            .FirstOrDefaultAsync(x => x.Id == parentId);

            
            var babysitters = parent.Babysitters.AsQueryable().ProjectTo<UserModel>(configuration);

            return babysitters.AsEnumerable();
        }

        public override async Task<ParentRecord> GetAsync(int id)
        {
            return await dbSet.Include(x => x.Babysitters)
                                .Include(x => x.Children).FirstAsync(x => x.Id == id);
        }
    }
}
