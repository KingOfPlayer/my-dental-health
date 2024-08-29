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
        Task<List<UserRole>> GetUserRoles(User user);
        Task<User?> FindUserWithEmail(string email);
    }
}
