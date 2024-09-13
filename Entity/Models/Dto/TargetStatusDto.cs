using System.ComponentModel.DataAnnotations;

namespace Entity.Models.Target.Status
{
	public class TargetStatusDto
	{
		[Required]
		[DataType(DataType.Duration)]
		public int Minutes { get; set; }
		[Required]
		[DataType(DataType.Duration)]
		public int Second { get; set; }
		public string ImgHash { get; set; } = string.Empty;
		public int TargetId { get; set; }
	}
}
