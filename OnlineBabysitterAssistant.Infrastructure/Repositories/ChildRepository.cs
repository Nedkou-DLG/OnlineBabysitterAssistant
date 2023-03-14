using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineBabysitterAssistant.Domain.Entities;
using OnlineBabysitterAssistant.Domain.Interfaces.Repositories;
using OnlineBabysitterAssistant.Domain.Models.Child;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBabysitterAssistant.Infrastructure.Repositories
{
    public class ChildRepository : GenericRepository<ChildRecord>, IChildRepository
    {
        public ChildRepository(BabysitterContext context):base(context)
        {

        }

        public override async Task<ChildRecord> GetAsync(int id)
        {
            return await dbSet.Include(x => x.Parent)
                        .Include(x => x.Babysitter)
                        .Include(x => x.ActivityRecords)
                        .FirstAsync(x => x.Id == id);
        }
        public IQueryable<ChildModel> GetAllByParent(int parentId, IConfigurationProvider configuration)
        {
            return  dbSet.Include(x => x.Parent)
                        .Include(x => x.Babysitter)
                        .Include(x => x.ActivityRecords)
                        .Where(x => x.ParentId == parentId).ProjectTo<ChildModel>(configuration);
        }
    }
}
