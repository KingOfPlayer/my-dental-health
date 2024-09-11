using Repository.Interfaces;

namespace Repository
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly RepositoryContext repositoryContext;
		private readonly IUserRepository userRepository;
		private readonly ITargetRepository targetRepository;
		private readonly IAdviceRepository adviceRepository;

		public RepositoryManager(RepositoryContext repositoryContext, IUserRepository userRepository, ITargetRepository targetRepository, IAdviceRepository adviceRepository)
		{
			this.repositoryContext = repositoryContext;
			this.userRepository = userRepository;
			this.targetRepository = targetRepository;
			this.adviceRepository = adviceRepository;
		}

		public IUserRepository UserRepository => userRepository;
		public ITargetRepository TargetRepository => targetRepository;
		public IAdviceRepository AdviceRepository => adviceRepository;
	}
}
