using System.ComponentModel.DataAnnotations;

namespace Entity.Models.Dto
{
	public class RecoveryEmailDto
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; } = string.Empty;
	}
}
