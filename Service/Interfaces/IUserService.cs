using Entity.Models.Dto;
using Entity.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
	{
		IQueryable<User> GetAllUsers();
		User? GetUserWithId(int UserId);
		List<UserRole>? GetUserRolesWithUserId(int UserId);
		User? FindUserWithEmail(string? email);
		void CreateNewUser(NewUserDto newUserDto);
	}
}
