using Entity.Target;
using Entity.Target.Status;
using Entity.User;
using EntityRepository.ContextConfig;
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
		public DbSet<UserUserRole> UserUserRoles { get; set; }
		public DbSet<TargetPeriodType> TargetPeriodTypes { get; set; }
		public DbSet<TargetPiroity> TargetPiroities { get; set; }
		public DbSet<Target> Targets { get; set; }
		public DbSet<TargetStatus> TargetStatus { get; set; }

		public RepositoryContext(DbContextOptions<RepositoryContext> options)
		: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new UserConfig());
			modelBuilder.ApplyConfiguration(new UserRoleConfig());
			modelBuilder.ApplyConfiguration(new UserUserRoleConfig());
			modelBuilder.ApplyConfiguration(new TargetPeriodTypeConfig());
		}
	}
}
