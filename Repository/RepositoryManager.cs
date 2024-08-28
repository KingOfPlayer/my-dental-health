using Entity;
using Entity.Models.Target.Status;
using Entity.Models.Target;
using Entity.Models.User;
using Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
