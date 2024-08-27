using Entity.User;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepository.Interfaces
{
	public interface IUserRepository
	{
		void Create(User user);
		void Update(User user);
		void UpdateUser(User user);
		IQueryable<User> GetAllUsers();
		User? GetUser(int id);
		void ChangePassword(User User);
		UserRole GetRoles();
		void GiveRole(User user, UserRole roleId);
		void RemoveRole(User user, UserRole roleId);

	}
}
