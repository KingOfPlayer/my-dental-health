namespace Entity.Models.Target
{
	public class TargetPeriodType
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public ICollection<Target> Target { get; set; } = new List<Target>();
	}
}
