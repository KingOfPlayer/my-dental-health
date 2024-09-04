using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Entity.Models.User
{
	public class User
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = string.Empty;
		[Required]
		public string Surname { get; set; } = string.Empty;
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; } = string.Empty;
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; } = string.Empty;
		[Required]
		[DataType(DataType.Date)]
		public DateTime BirthdayDate { get; set; }
		public HashSet<Target.Target> Target { get; set; } = new HashSet<Target.Target>();
		public HashSet<UserUserRole> Roles { get; set; } = new HashSet<UserUserRole>();
		public static string HashPassword(string Password)
		{
			string h_Password = "";
			using (SHA256 sHA256 = SHA256.Create())
			{
				h_Password = Convert.ToBase64String(sHA256.ComputeHash(Encoding.UTF8.GetBytes(Password)));
			}
			return h_Password;
		}

		public static bool isValidPassword(string? password)
		{
			return Regex.Match(password, @"(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$").Success;
		}
		public bool isPasswordMatch(string Password)
		{
			return this.Password.Equals(Password);
		}
	}
}
