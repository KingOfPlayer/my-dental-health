using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Target.Status
{
	public class TargetStatus
	{
		public int Id { get; set; }
		public DateTime Attime { get; set; }
		public int Minutes { get; set; }
		public int Second { get; set; }
		public string? ImgHash { get; set; }
		public required Target Target { get; set; }
	}
}
