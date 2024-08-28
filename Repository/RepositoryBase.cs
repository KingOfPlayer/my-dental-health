using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public abstract class RepositoryBase : IRepositoryBase
	{
		protected readonly RepositoryContext repositoryContext;

		public RepositoryBase(RepositoryContext repositoryContext)
		{
			this.repositoryContext = repositoryContext;
		}

		public void Create<T>(T entity) where T : class
		{
			repositoryContext.Set<T>().Add(entity);
		}


		public void Remove<T>(T entity) where T : class
		{
			repositoryContext.Set<T>().Remove(entity);
		}

		public void Update<T>(T entity) where T : class
		{
			repositoryContext.Set<T>().Update(entity);
		}

		public T? Query<T>(Expression<Func<T, bool>> conditional) where T : class
		{
			return repositoryContext.Set<T>().Where(conditional).AsNoTracking().SingleOrDefault();
		}

		public T? QueryWithTrack<T>(Expression<Func<T, bool>> conditional,bool Tracking = false) where T : class
		{
			return repositoryContext.Set<T>().Where(conditional).SingleOrDefault();
		}

		public IQueryable<T> GetAll<T>() where T : class
		{
			return repositoryContext.Set<T>().AsNoTracking();
		}

		public IQueryable<T> GetAllWithTrack<T>(Expression<Func<T, bool>> conditional, bool Tracking = false) where T : class
		{
			return repositoryContext.Set<T>();
		}
	}
}
