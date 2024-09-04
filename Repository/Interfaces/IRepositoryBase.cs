using System.Linq.Expressions;

namespace Repository.Interfaces
{
	public interface IRepositoryBase
	{

		void Create<T>(T entity) where T : class;
		void Update<T>(T entity) where T : class;
		void Remove<T>(T entity) where T : class;
		void Save<T>() where T : class;
		IQueryable<T> Query<T>(Expression<Func<T, bool>> conditional) where T : class;
		IQueryable<T> QueryWithTrack<T>(Expression<Func<T, bool>> conditional, bool Tracking = false) where T : class;

	}
}
