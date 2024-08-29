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

        public async Task<List<UserRole>> GetUserRoles(User user)
        {
            List<UserRole> userRole = await repositoryManager.UserRepository.GetUser(user.Id).SelectMany(u => u.Roles.Select(urr => urr.UserRole)).ToListAsync();
            return userRole;
        }

        public async Task<User?> FindUserWithEmail(string email)
        {
			User? user = await repositoryManager.UserRepository.GetAllUsers().Where(u =>
				u.Email.Equals(email)).SingleOrDefaultAsync();
            
            return user;
        }
    }
}
