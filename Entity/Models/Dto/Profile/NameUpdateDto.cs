using System.ComponentModel.DataAnnotations;

namespace Entity.Models.Dto.Profile
{
	public class NameUpdateDto
	{
		[Required]
		public string Name { get; set; } = string.Empty;
	}
}
