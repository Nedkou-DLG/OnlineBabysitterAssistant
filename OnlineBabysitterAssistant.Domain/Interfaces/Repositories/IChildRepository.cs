using AutoMapper;
using OnlineBabysitterAssistant.Domain.Entities;
using OnlineBabysitterAssistant.Domain.Models.Child;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBabysitterAssistant.Domain.Interfaces.Repositories
{
    public interface IChildRepository:IGenericRepository<ChildRecord>
    {
        IQueryable<ChildModel> GetAllByParent(int parentId, IConfigurationProvider configuration);
    }
}
