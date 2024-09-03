using Entity.Models.Dto;
using Entity.Models.User;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class UserService : IUserService
	{
		private readonly IRepositoryManager repositoryManager;

		public UserService(IRepositoryManager repositoryManager)
		{
			this.repositoryManager = repositoryManager;
		}

		public IQueryable<User> GetAllUsers()
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
        public User? FindUserWithEmail(string? email)
        {
			User? user = repositoryManager.UserRepository.GetAllUsers().Where(u =>
				u.Email.Equals(email)).SingleOrDefault();
            
            return user;
        }

		public void CreateNewUser(NewUserDto newUserDto)
		{
			User? user = newUserDto.ToUser();
			repositoryManager.UserRepository.CreateUser(user);
			UserRole? role = (UserRole?)repositoryManager.UserRepository.GetRoles().Where(r => r.Name.Equals("User")).SingleOrDefault();
			repositoryManager.UserRepository.GiveRole(new UserUserRole() {UserId = user.Id, UserRoleId = role.Id});
			Console.WriteLine("Sending mail to wlc");
		}

		public void UpdateUser(User user)
		{
			repositoryManager.UserRepository.UpdateUser(user);
		}
	}
}
