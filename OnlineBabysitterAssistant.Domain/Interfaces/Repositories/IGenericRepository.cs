using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineBabysitterAssistant.Domain.Interfaces.Repositories
{
	public interface IGenericRepository<TEntity> where TEntity : class, IEntity
	{
		TEntity Get(int id);

		Task<TEntity> GetAsync(int id);

		IEnumerable<TEntity> GetAll(IEnumerable<int> ids);

		IQueryable<TEntity> AsQueryable();

		IEnumerable<TEntity> AsEnumerable();

		void Add(TEntity entity);

		Task AddAsync(TEntity entity);

		void Delete(TEntity entity);

		void Delete(int id);

		Task DeleteAsync(int id);

		void Detach(TEntity entity);

		void Update(TEntity entity);
	}
}
