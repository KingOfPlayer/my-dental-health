using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Linq.Expressions;

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
			Save<T>();
		}


		public void Remove<T>(T entity) where T : class
		{
			repositoryContext.Set<T>().Remove(entity);
			Save<T>();
        }
        public void RemoveAll<T>(List<T> entity) where T : class
        {
            repositoryContext.Set<T>().RemoveRange(entity);
            Save<T>();
        }

        public void Update<T>(T entity) where T : class
		{
			repositoryContext.Set<T>().Update(entity);
			Save<T>();
		}
		public void Save<T>() where T : class
		{
			repositoryContext.SaveChanges();
		}

		public IQueryable<T> Query<T>(Expression<Func<T, bool>> conditional) where T : class
		{
			return repositoryContext.Set<T>().Where(conditional).AsNoTracking();
		}

		public IQueryable<T> QueryWithTrack<T>(Expression<Func<T, bool>> conditional, bool Tracking = false) where T : class
		{
			return repositoryContext.Set<T>().Where(conditional);
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
