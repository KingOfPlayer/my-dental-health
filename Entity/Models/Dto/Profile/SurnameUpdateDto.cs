using System.ComponentModel.DataAnnotations;

namespace Entity.Models.Dto.Profile
{
	public class SurnameUpdateDto
	{
		[Required]
		public string Surname { get; set; } = string.Empty;
	}
}
