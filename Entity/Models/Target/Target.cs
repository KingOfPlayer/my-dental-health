using Entity.Models.Target.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Target
{
    public class Target
    {
        public int Id { get; set; }
        public User.User User { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public required TargetPiroity TargetPiroity { get; set; }
        public DateTime PeriodTime { get; set; } = DateTime.Now;
        public required TargetPeriodType TargetPeriodType { get; set; }
        public int PeriodLength { get; set; }
        public int Count { get; set; }
        public HashSet<TargetStatus> TargetStatus { get; set; } = new HashSet<TargetStatus>();
    }
}
