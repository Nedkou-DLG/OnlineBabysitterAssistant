using System;

using Microsoft.EntityFrameworkCore;
using OnlineBabysitterAssistant.Domain.Interfaces;
using OnlineBabysitterAssistant.Domain.Interfaces.Repositories;

namespace OnlineBabysitterAssistant.Infrastructure.Repositories
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
	{
        protected BabysitterContext context;
        protected DbSet<TEntity> dbSet;

        public GenericRepository(BabysitterContext context)
		{
            this.context = context;
            this.dbSet = context.Set<TEntity>();
		}

        public virtual void Add(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            dbSet.Add(entity);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            await dbSet.AddAsync(entity);
        }

        public virtual IEnumerable<TEntity> AsEnumerable()
        {
            return dbSet.AsEnumerable();
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return dbSet.AsQueryable();
        }

        public virtual void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            TEntity entity = Get(id);
            Delete(entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            TEntity entity = await GetAsync(id);
            Delete(entity);
        }

        public virtual void Detach(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Detached;
        }

        public virtual TEntity Get(int id) => dbSet.Find(id) ?? throw new InvalidOperationException();

        public virtual IEnumerable<TEntity> GetAll(IEnumerable<int> ids)
        {
            return dbSet.Where(e => ids.Contains(e.Id)).AsEnumerable();
        }

        public virtual async Task<TEntity> GetAsync(int id) => await dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public virtual void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }
    }
}

