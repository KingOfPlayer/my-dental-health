using Entity.Target.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Target
{
	public class TagetPeriodType
	{
		public int Id { get; set; }
		public int Name { get; set; }
		public ICollection<Target> Targets { get; set; }
	}
}
