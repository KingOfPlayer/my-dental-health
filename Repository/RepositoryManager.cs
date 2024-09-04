using Repository.Interfaces;

namespace Repository
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly RepositoryContext repositoryContext;
		private readonly IUserRepository userRepository;

		public RepositoryManager(RepositoryContext repositoryContext, IUserRepository userRepository)
		{
			this.repositoryContext = repositoryContext;
			this.userRepository = userRepository;
		}

		public IUserRepository UserRepository => userRepository;
	}
}
