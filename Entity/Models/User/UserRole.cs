using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.User
{
    public class UserRole
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public HashSet<UserUserRole> Users { get; set; } = new HashSet<UserUserRole>();
    }
}
