using Entity.Models.Target.Status;

namespace Entity.Models.Target
{
	public class Target
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public User.User User { get; set; } = null!;
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int TargetPiroityId { get; set; }
		public TargetPiroity? TargetPiroity { get; set; }
		public DateTime PeriodTime { get; set; } = DateTime.Now;
		public int TargetPeriodTypeId { get; set; }
		public TargetPeriodType? TargetPeriodType { get; set; }
		public int PeriodLength { get; set; }
		public int Count { get; set; }
		public HashSet<TargetStatus> TargetStatus { get; set; } = new HashSet<TargetStatus>();
	}
}
