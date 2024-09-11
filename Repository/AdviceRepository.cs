using Entity.Models.Advice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
	public class AdviceRepository : RepositoryBase, IAdviceRepository
	{
		public AdviceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public IQueryable<Advice> GetAllAdvice() => GetAll<Advice>();
	}
}
