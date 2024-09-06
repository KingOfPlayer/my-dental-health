using Repository.Interfaces;

namespace Repository
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly RepositoryContext repositoryContext;
		private readonly IUserRepository userRepository;
		private readonly ITargetRepository targetRepository;

        public RepositoryManager(RepositoryContext repositoryContext, IUserRepository userRepository, ITargetRepository targetRepository)
        {
            this.repositoryContext = repositoryContext;
            this.userRepository = userRepository;
            this.targetRepository = targetRepository;
        }

        public IUserRepository UserRepository => userRepository;
		public ITargetRepository TargetRepository => targetRepository;
	}
}
