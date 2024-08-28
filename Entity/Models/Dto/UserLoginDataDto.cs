using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Dto
{
    public record UserLoginDataDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        private string p_Password { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        public string Password
        {
            get { return p_Password; }
            init
            {
                using (SHA256 sHA256 = SHA256.Create())
                {
                    p_Password = Convert.ToBase64String(sHA256.ComputeHash(Encoding.UTF8.GetBytes(value)));
                }
            }
        }
    }
}
