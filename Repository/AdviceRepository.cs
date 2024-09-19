using Entity.Models.Advice;

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
