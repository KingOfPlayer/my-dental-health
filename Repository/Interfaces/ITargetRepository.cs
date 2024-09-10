using Entity.Models.Target;
using Entity.Models.Target.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ITargetRepository
    {
        void CreateTarget(Target target);
        void UpdateTarget(Target target);
		void UpdateTargetRange(List<Target> target);
		void RemoveTarget(Target target);
        void RemoveTarget(List<Target> target);
        IQueryable<Target> GetAllTargets();
		IQueryable<Target> GetAllTargetsWithTrack();
		void CreateTargetStatus(TargetStatus targetStatus);
        void UpdateTargetStatus(TargetStatus targetStatus);
        void RemoveTargetStatus(TargetStatus targetStatus);
        void RemoveTargetStatus(List<TargetStatus> targetStatus);
        IQueryable<TargetStatus> GetAllTargetStatus();
        IQueryable<TargetPeriodType> GetTargetPeriodTypes();
		IQueryable<TargetPiroity> GetTargetPiroities();
		void SaveChanges();
	}
}
