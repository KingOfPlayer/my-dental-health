using System.ComponentModel.DataAnnotations;

namespace Entity.Models.Dto.Profile
{
	public class BirthdayDateUpdateDto
	{
		[Required]
		[DataType(DataType.Date)]
		public DateTime BirthdayDate { get; set; }
	}
}
