using Entity.Models.Dto;
using Entity.Models.User;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRepository
	{
		void CreateUser(User user);
		void UpdateUser(User user);
		IQueryable<User> GetAllUsers();
        IQueryable<User> GetUser(int id);
        IQueryable<UserRole> GetRoles();
		void GiveRole(UserUserRole userUserRole);
		void RemoveRole(UserUserRole userUserRole);
    }
}
