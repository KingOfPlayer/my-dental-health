using System.ComponentModel.DataAnnotations;

namespace Entity.Models.Dto.Profile
{
	public class PasswordUpdateDto
	{
		[Required]
		[DataType(DataType.Password)]
		public string CurrentPassword { get; set; } = string.Empty;
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; } = string.Empty;
		[Required]
		[DataType(DataType.Password)]
		public string ValidatePassword { get; set; } = string.Empty;
	}
}
