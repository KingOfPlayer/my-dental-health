using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.User
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string CookieHash { get; set; } = string.Empty;
        public User User { get; set; } = null!;
    }
}
