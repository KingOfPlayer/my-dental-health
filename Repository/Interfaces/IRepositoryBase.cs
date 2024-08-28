using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
	public interface IRepositoryBase
	{
		
		void Create<T>(T entity) where T : class;
		void Update<T>(T entity) where T : class;
		void Remove<T>(T entity) where T : class;
		T? Query<T>(Expression<Func<T, bool>> conditional) where T : class;
		T? QueryWithTrack<T>(Expression<Func<T, bool>> conditional, bool Tracking = false) where T : class;
		
	}
}
