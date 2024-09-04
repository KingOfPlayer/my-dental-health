using System.ComponentModel.DataAnnotations;

namespace Entity.Models.Dto
{
	public class NewUserDto
	{
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
		[DataType(DataType.Password)]
		public string ValidatePassword { get; set; } = string.Empty;
		[Required]
		[DataType(DataType.Date)]
		public DateTime BirthdayDate { get; set; }

		public User.User ToUser()
		{
			return new User.User()
			{
				Name = Name,
				Surname = Surname,
				Email = Email,
				Password = User.User.HashPassword(Password),
				BirthdayDate = BirthdayDate,
				Target = new HashSet<Target.Target>(),
				Roles = new HashSet<User.UserUserRole>()
			};
		}
	}
}
