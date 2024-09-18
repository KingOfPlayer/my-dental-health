using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.User
{
	public class UserSession
	{
		[Key]
		[Column(TypeName = "nvarchar(449)")]
		public string Id { get; set; }

		[Required]
		[Column(TypeName = "varbinary(max)")]
		public byte[] Value { get; set; }

		[Required]
		[Column(TypeName = "datetimeoffset(7)")]
		public DateTimeOffset ExpiresAtTime { get; set; }

		[Column(TypeName = "bigint")]
		public long? SlidingExpirationInSeconds { get; set; }

		[Column(TypeName = "datetimeoffset(7)")]
		public DateTimeOffset? AbsoluteExpiration { get; set; }
	}
}
