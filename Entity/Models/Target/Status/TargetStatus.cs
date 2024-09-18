namespace Entity.Models.Target.Status
{
	public class TargetStatus
	{
		public int Id { get; set; }
		public DateTime Attime { get; set; } = DateTime.Now;
		public int Minutes { get; set; }
		public int Second { get; set; }
		public string ImgHash { get; set; } = string.Empty;
		public int TargetId { get; set; }
		public Target? Target { get; set; }
	}
}
