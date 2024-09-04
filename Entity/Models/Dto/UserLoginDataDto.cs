﻿using System.ComponentModel.DataAnnotations;

namespace Entity.Models.Dto
{
	public record UserLoginDataDto
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
