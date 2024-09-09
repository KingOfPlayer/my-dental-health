using AutoMapper;
using Entity.Models.Dto;
using Entity.Models.User;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service
{
	public class UserService : IUserService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly IMapper mapper;

        public UserService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
        }

        public IEnumerable<User> GetAllUsers()
		{
			return repositoryManager.UserRepository.GetAllUsers();
		}
		public User? GetUserWithId(int UserId)
		{
			return repositoryManager.UserRepository.GetUser(UserId).SingleOrDefault();
		}
		public List<UserRole> GetUserRolesWithUserId(int UserId)
		{
			List<UserRole> userRole = repositoryManager.UserRepository.GetUser(UserId).SelectMany(u => u.Roles.Select(urr => urr.UserRole)).ToList();
			return userRole;
		}
		public User? FindUserWithEmail(string email)
		{
			User? user = repositoryManager.UserRepository.GetAllUsers().Where(u =>
				u.Email.Equals(email)).SingleOrDefault();
			return user;
		}

		public void CreateNewUser(NewUserDto newUserDto)
		{
			User? user = new User();
			mapper.Map(newUserDto, user);
			user.Password = User.HashPassword(newUserDto.Password);
			repositoryManager.UserRepository.CreateUser(user);
			UserRole? role = repositoryManager.UserRepository.GetRoles().Where(r => r.Name.Equals("User")).SingleOrDefault();
			repositoryManager.UserRepository.GiveRole(new UserUserRole() { UserId = user.Id, UserRoleId = role!.Id });
			Console.WriteLine("Sending mail to wlc");
		}

		public void UpdateUser(User user)
		{
			repositoryManager.UserRepository.UpdateUser(user);
		}


	}
}
