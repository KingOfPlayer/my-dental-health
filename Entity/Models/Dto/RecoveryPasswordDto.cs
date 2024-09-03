﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Dto
{
	public class RecoveryPasswordDto
	{
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; } = string.Empty;
		[Required]
		[DataType(DataType.Password)]
		public string ValidatePassword { get; set; } = string.Empty;
		[Required]
		public string h { get; set; } = string.Empty;
		[Required]
		public string t { get; set; } = string.Empty;
		[Required]
		public string u { get; set; } = string.Empty;
	}
}
