using Entity.Models.Advice;
using Repository.Interfaces;

namespace Service.Interfaces
{
	public class AdviceService : IAdviceService
	{
		private readonly IRepositoryManager repositoryManager;

		public AdviceService(IRepositoryManager repositoryManager)
		{
			this.repositoryManager = repositoryManager;
		}
		public Advice? GetRandomAdvice()
		{
			Random random = new Random();
			return repositoryManager.AdviceRepository.GetAllAdvice().ToList().OrderBy(a => random.Next()).FirstOrDefault();
		}
	}
}
