using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.User
{
    public class User
	{
		public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
		[DataType(DataType.Password)]
		public string Password { get; set; } = string.Empty;
		public DateTime BirthdayDate { get; set; }
        public HashSet<Target.Target> Targets { get; set; } = new HashSet<Target.Target>();
		public HashSet<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
		public HashSet<UserLogin> UserLogins { get; set; } = new HashSet<UserLogin>();
	}
}
