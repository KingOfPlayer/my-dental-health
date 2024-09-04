using Entity.Models.User;
using Repository.Interfaces;

namespace Repository
{
	public class UserRepository : RepositoryBase, IUserRepository
	{
		public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{

		}

		public void CreateUser(User user) => Create(user);
		public void UpdateUser(User user) => Update(user);

		public IQueryable<User> GetAllUsers()
		{
			return GetAll<User>();
		}

		public IQueryable<UserRole> GetRoles()
		{
			return GetAll<UserRole>();
		}

		public IQueryable<User> GetUser(int id)
		{
			return Query<User>(U => U.Id.Equals(id));
		}

		public void GiveRole(UserUserRole userUserRole) => Create(userUserRole);
		public void RemoveRole(UserUserRole userUserRole) => Remove(userUserRole);

	}
}
