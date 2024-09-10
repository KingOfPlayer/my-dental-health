using Entity.Models.Target;
using Entity.Models.Target.Status;
using Entity.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITargetService
    {
        void CreateTarget(Target target);
        void CreateTarget(TargetStatus targetStatus);
        List<TargetStatus> GetAllTargetStatus(Target target);
        List<TargetStatus> GetAllTargetStatus(int targetId);
		List<TargetPeriodType> GetTargetPeriodTypes();
		List<TargetPiroity> GetTargetPiroities();
		TargetStatus? GetTargetStatus(TargetStatus targetStatus);
        TargetStatus? GetTargetStatus(int targetStatusId);
		Task<List<Target>> GetUserTargets(User user);
		Task<List<Target>> GetUserTargets(int userId);
        void RemoveTarget(Target target);
        void RemoveTarget(Target target, int userId);
        void RemoveTarget(int targetId, int userId);
        void RemoveTargetStatus(TargetStatus targetStatus);
        void RemoveTargetStatus(int targetStatusId);
        void UpdateTarget(Target target);
		Task UpdateTargetCheckDates(int userId);
		Task UpdateTargetCheckDates(User user);
		void UpdateTargetStatus(TargetStatus targetStatus);
    }
}
