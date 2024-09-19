using System.ComponentModel.DataAnnotations;

namespace Entity.Models.Dto.Profile
{
	public class EmailUpdateDto
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; } = string.Empty;
	}
}
