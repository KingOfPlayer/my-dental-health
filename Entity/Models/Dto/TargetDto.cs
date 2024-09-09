using Entity.Models.Target.Status;
using Entity.Models.Target;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entity.Models.Dto
{
    public class TargetDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
		[DataType(DataType.Text)]
		public string Name { get; set; } = string.Empty;
		[DataType(DataType.MultilineText)]
		public string Description { get; set; } = string.Empty;
		[Required]
		public int TargetPiroityId { get; set; }
		[Required]
		public int TargetPeriodTypeId { get; set; }
		[Required]
		public int PeriodLength { get; set; }
		[Required]
		public int Count { get; set; }
    }
}
