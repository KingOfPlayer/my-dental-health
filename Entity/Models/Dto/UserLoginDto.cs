﻿using System.ComponentModel.DataAnnotations;

namespace Entity.Models.Dto
{
	public class UserLoginDto
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; } = string.Empty;
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; } = string.Empty;
	}
}
