using Entity.Target.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Target
{
	public class TargetPeriodType
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public ICollection<Target> Target { get; set; } = new List<Target>();
	}
}
