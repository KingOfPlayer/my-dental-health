namespace Entity.Target
{
	public class TargetPiroity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public HashSet<Target> targets { get; set; } = new HashSet<Target>();
	}
}