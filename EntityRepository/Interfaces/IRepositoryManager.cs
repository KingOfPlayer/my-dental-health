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
	public interface IRepositoryManager
	{
		IUserRepository UserRepository { get; }
		ITargetRepository TargetRepository { get; }
	}
}
