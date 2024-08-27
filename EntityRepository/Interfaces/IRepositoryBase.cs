using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepository.Interfaces
{
	public interface IRepositoryBase<T>
	{
		public T GetById(int id);
		public T Create(T entity);
		public T Update(T entity);
		public T Delete(T entity);
	}
}
