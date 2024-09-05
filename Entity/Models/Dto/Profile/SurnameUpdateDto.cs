using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Dto.Profile
{
    public class SurnameUpdateDto
    {
		[Required]
		public string Surname { get; set; } = string.Empty;
	}
}
