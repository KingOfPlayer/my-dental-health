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
		void Create(User user);
		void Update(User user);
		void UpdateUser(User user);
		IQueryable<User> GetAllUsers();
		User? GetUser(int id);
		void ChangePassword(User User);
		UserRole GetRoles();
		void GiveRole(User user, UserRole roleId);
		void RemoveRole(User user, UserRole roleId);
		public void AddUserLogin(User user, string token);
        User? Login(UserLoginDataDto userLoginData);
    }
}
