using Entity.Models.Dto;
using Entity.Models.User;

namespace Services.Interfaces
{
	public interface IUserService
	{
		IQueryable<User> GetAllUsers();
		User? GetUserWithId(int UserId);
		List<UserRole>? GetUserRolesWithUserId(int UserId);
		User? FindUserWithEmail(string? email);
		void CreateNewUser(NewUserDto newUserDto);
		void UpdateUser(User user);
	}
}
