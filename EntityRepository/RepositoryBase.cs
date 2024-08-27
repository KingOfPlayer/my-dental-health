using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepository.Interfaces
{
	public class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		private RepositoryContext repositoryContext;
		public RepositoryBase(RepositoryContext repositoryContext) {
			this.repositoryContext = repositoryContext;
		}
		public T Create(T entity)
		{
			throw new NotImplementedException();
		}

		public T Delete(T entity)
		{
			throw new NotImplementedException();
		}

		public T GetById(int id)
		{
			throw new NotImplementedException();
		}

		public T Update(T entity)
		{
			throw new NotImplementedException();
		}
	}
}
