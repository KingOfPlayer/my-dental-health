using Entity.Target;
using Entity.Target.Status;
using Entity.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepository
{
    public class RepositoryContext : DbContext
	{
		public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<UserLogin> UserLogins { get; set; }
		public DbSet<User> Users {  get; set; }
		public DbSet<TargetStatus> TargetStatus { get; set; }
		public DbSet<TagetPeriodType> TagetPeriodTypes { get; set; }
		public DbSet<Target> Targets { get; set; }

		public RepositoryContext(DbContextOptions<RepositoryContext> options)
		: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
