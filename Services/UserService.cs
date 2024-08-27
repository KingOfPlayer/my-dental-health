using Entity.User;
using EntityRepository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class UserService : IUserService
	{
		private readonly IRepositoryManager repositoryManager;

		public UserService(IRepositoryManager repositoryManager)
		{
			this.repositoryManager = repositoryManager;
		}

		public IQueryable<User> GetAllUsers()
		{
			return repositoryManager.UserRepository.GetAllUsers();
		}
	}
}
