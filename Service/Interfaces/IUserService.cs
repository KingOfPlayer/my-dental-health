using Entity.Models.Dto;
using Entity.Models.User;

namespace Service.Interfaces
{
	public interface IUserService
	{
		IEnumerable<User> GetAllUsers();
		User? GetUserWithId(int UserId);
		List<UserRole>? GetUserRolesWithUserId(int UserId);
		Task<User?> FindUserWithEmail(string email);
		void CreateNewUser(NewUserDto newUserDto);
		void UpdateUser(User user);
	}
}
