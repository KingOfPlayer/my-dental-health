using Entity;
using Entity.Target.Status;
using Entity.Target;
using Entity.User;
using EntityRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepository
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
