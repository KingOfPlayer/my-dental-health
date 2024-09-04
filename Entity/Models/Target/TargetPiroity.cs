namespace Entity.Models.Target
{
	public class TargetPiroity
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public HashSet<Target> Target { get; set; } = new HashSet<Target>();
	}
}