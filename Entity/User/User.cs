using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
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
		private string p_Password { get; set; } = null!;
		[DataType(DataType.Password)]
		public string Password
		{
			get { return p_Password; }
			set
			{
				using (SHA256 sHA256 = SHA256.Create())
				{
					p_Password = Convert.ToBase64String(sHA256.ComputeHash(Encoding.UTF8.GetBytes(value)));
				}
			}
		}
		public DateTime BirthdayDate { get; set; }
		public HashSet<Target.Target> Target { get; set; } = new HashSet<Target.Target>();
		public HashSet<UserUserRole> Roles { get; set; } = new HashSet<UserUserRole>();
		public HashSet<UserLogin> Logins { get; set; } = new HashSet<UserLogin>();
	}
}
