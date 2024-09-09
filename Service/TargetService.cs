using AutoMapper;
using Entity.Models.Target;
using Entity.Models.Target.Status;
using Entity.Models.User;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TargetService : ITargetService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;

        public TargetService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
        }

        public List<Target> GetUserTargets(User user)
        {
            return repositoryManager.TargetRepository.GetAllTargets()
                .Where(t => t.UserId.Equals(user.Id))
				.ToList();
		}

		public List<Target> GetUserTargets(int userId)
        {
            return repositoryManager.TargetRepository.GetAllTargets()
				.Where(t => t.UserId.Equals(userId))
                .ToList();
		}
        public void CreateTarget(Target target)
        {
            repositoryManager.TargetRepository.CreateTarget(target);
        }
        public void UpdateTarget(Target target)
        {
            repositoryManager.TargetRepository.UpdateTarget(target);
        }
        public void RemoveTarget(Target target)
        {
            repositoryManager.TargetRepository.RemoveTarget(target);
        }
        public void RemoveTarget(Target target, int userId)
        {
            Target? _target = repositoryManager.TargetRepository.GetAllTargets()
                .Where(t => t.UserId.Equals(userId))
                .Where(t => t.Id.Equals(target.Id)).SingleOrDefault();
            repositoryManager.TargetRepository.RemoveTarget(target);
        }
        public void RemoveTarget(int targetId, int userId)
        {
            Target? _target = repositoryManager.TargetRepository.GetAllTargets()
                .Where(t => t.UserId.Equals(userId))
                .Where(t => t.Id.Equals(targetId)).SingleOrDefault();
            repositoryManager.TargetRepository.RemoveTarget(_target!);
        }

        public List<TargetStatus> GetAllTargetStatus(Target target)
        {
            return repositoryManager.TargetRepository.GetAllTargetStatus()
                .Where(ts => ts.TargetId.Equals(target)).ToList();
        }
        public List<TargetStatus> GetAllTargetStatus(int targetId)
        {
            return repositoryManager.TargetRepository.GetAllTargetStatus()
                .Where(ts => ts.TargetId.Equals(targetId)).ToList();
        }
        public TargetStatus? GetTargetStatus(TargetStatus targetStatus)
        {
            return repositoryManager.TargetRepository.GetAllTargetStatus()
                .Where(ts => ts.Id.Equals(targetStatus.Id)).SingleOrDefault();
        }
        public TargetStatus? GetTargetStatus(int targetStatusId)
        {
            return repositoryManager.TargetRepository.GetAllTargetStatus()
                .Where(ts => ts.Id.Equals(targetStatusId)).SingleOrDefault();
        }
        public void CreateTarget(TargetStatus targetStatus)
        {
            repositoryManager.TargetRepository.CreateTargetStatus(targetStatus);
        }
        public void UpdateTargetStatus(TargetStatus targetStatus)
        {
            repositoryManager.TargetRepository.UpdateTargetStatus(targetStatus);
        }
        public void RemoveTargetStatus(TargetStatus targetStatus)
        {
            repositoryManager.TargetRepository.RemoveTargetStatus(targetStatus);
        }
        public void RemoveTargetStatus(int targetStatusId)
        {
            TargetStatus? _targetStatus = repositoryManager.TargetRepository.GetAllTargetStatus()
                .Where(ts => ts.Id.Equals(targetStatusId)).SingleOrDefault();
            repositoryManager.TargetRepository.RemoveTargetStatus(_targetStatus!);
        }

        public List<TargetPeriodType> GetTargetPeriodTypes()
        {
            return repositoryManager.TargetRepository.GetTargetPeriodTypes().ToList();
		}

        public List<TargetPiroity> GetTargetPiroities()
        {
            return repositoryManager.TargetRepository.GetTargetPiroities().ToList();
        }
    }
}
