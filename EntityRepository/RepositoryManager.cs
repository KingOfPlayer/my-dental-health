using Entity;
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
		private readonly RepositoryContext context;

		private readonly IUserRepository userRepository;
		private readonly ITargetRepository targetRepository;

		public RepositoryManager(RepositoryContext context, IUserRepository userRepository, ITargetRepository targetRepository)
		{
			this.context = context;
			this.userRepository = userRepository;
			this.targetRepository = targetRepository;
		}

		public IUserRepository UserRepository => userRepository;

		public ITargetRepository TargetRepository => targetRepository;
	}
}
