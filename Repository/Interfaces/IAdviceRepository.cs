using Entity.Models.Advice;

namespace Repository.Interfaces
{
	public interface IAdviceRepository
	{
		IQueryable<Advice> GetAllAdvice();
	}
}
