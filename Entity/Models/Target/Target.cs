using Entity.Models.Target.Status;
using System;

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

		public static DateTime GetPeriodEndTime(int TargetPeriodTypeId, DateTime PeriodTime, int PeriodLength)
		{
			switch (TargetPeriodTypeId)
			{
				case 1:
					return PeriodTime.AddDays(PeriodLength);
				case 2:
					return PeriodTime.AddDays(7 * PeriodLength);
				case 3:
					return PeriodTime.AddMonths(PeriodLength);
				case 4:
					return PeriodTime.AddYears(PeriodLength);
				default:
					return PeriodTime;
			}
		}
	}
}
