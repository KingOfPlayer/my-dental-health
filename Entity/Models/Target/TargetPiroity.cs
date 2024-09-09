namespace Entity.Models.Target
{
	public class TargetPiroity
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public HashSet<Target> Target { get; set; } = new HashSet<Target>();
	}
}