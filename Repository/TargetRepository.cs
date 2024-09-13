using Entity.Models.Target;
using Entity.Models.Target.Status;
using Entity.Models.User;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TargetRepository : RepositoryBase, ITargetRepository
    {
        public TargetRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateTarget(Target target) => Create(target);
        public void UpdateTarget(Target target) => Update(target);
		public void UpdateTargetRange(List<Target> target) => UpdateRange(target);
		public void RemoveTarget(Target target) => Remove(target);
        public void RemoveTarget(List<Target> target) => Remove(target);
		public void AttachTarget(Target target) => Attach(target);
		public IQueryable<Target> GetAllTargets() => GetAll<Target>().
            Include(target => target.TargetPeriodType)
            .Include(target => target.TargetPiroity)
            .Include(target => target.TargetStatuses.OrderByDescending(ts => ts.Attime))
            ;

		public IQueryable<Target> GetAllTargetsWithTrack() => GetAllWithTrack<Target>().
			Include(target => target.TargetPeriodType)
			.Include(target => target.TargetPiroity)
			.Include(target => target.TargetStatuses.OrderByDescending(ts => ts.Attime));
		public void CreateTargetStatus(TargetStatus targetStatus) => Create(targetStatus);
        public void UpdateTargetStatus(TargetStatus targetStatus) => Update(targetStatus);
        public void RemoveTargetStatus(TargetStatus targetStatus) => Remove(targetStatus);
        public void RemoveTargetStatus(List<TargetStatus> targetStatus) => Remove(targetStatus);
        public IQueryable<TargetStatus> GetAllTargetStatus() => GetAll<TargetStatus>();

		public IQueryable<TargetPeriodType> GetTargetPeriodTypes() => GetAll<TargetPeriodType>();

		public IQueryable<TargetPiroity> GetTargetPiroities() => GetAll<TargetPiroity>();

        public void SaveChanges() => SaveChanges();
	}
}
