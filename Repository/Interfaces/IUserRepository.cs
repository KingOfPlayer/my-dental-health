using Entity.Models.User;

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
