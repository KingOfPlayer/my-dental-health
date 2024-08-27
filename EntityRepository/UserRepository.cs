using Entity.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepository.Interfaces
{
	public class UserRepository : RepositoryBase, IUserRepository
	{
		public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{

		}

		public void ChangePassword(User User)
		{
			throw new NotImplementedException();
		}

		public void Create(User user)
		{
			throw new NotImplementedException();
		}

		public IQueryable<User> GetAllUsers()
		{
			return GetAll<User>().Include(u => u.Roles);
		}

		public UserRole GetRoles()
		{
			throw new NotImplementedException();
		}

		public User? GetUser(int id)
		{
			return Query<User>(U => U.Id.Equals(id));
		}

		public void GiveRole(User user, UserRole roleId)
		{
			throw new NotImplementedException();
		}

		public void RemoveRole(User user, UserRole roleId)
		{
			throw new NotImplementedException();
		}

		public void Update(User user)
		{
			throw new NotImplementedException();
		}

		public void UpdateUser(User user)
		{
			throw new NotImplementedException();
		}
	}
}
