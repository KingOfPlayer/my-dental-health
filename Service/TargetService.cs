﻿using AutoMapper;
using Entity.Models.Target;
using Entity.Models.Target.Status;
using Entity.Models.User;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Service.Interfaces;

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

		public async Task<List<Target>> GetUserTargets(User user) => await GetUserTargets(user.Id);

		public async Task<List<Target>> GetUserTargets(int userId)
		{
			return await repositoryManager.TargetRepository.GetAllTargetsWithDetails()
				.Where(t => t.UserId.Equals(userId))
				.ToListAsync();
		}
		public void CreateTarget(Target target)
		{
			repositoryManager.TargetRepository.CreateTarget(target);
		}
		public void UpdateTarget(Target target)
		{
			repositoryManager.TargetRepository.UpdateTarget(target);
		}

		public async Task UpdateTargetCheckDates(User user) => await UpdateTargetCheckDates(user.Id);

		public async Task UpdateTargetCheckDates(int userId)
		{
			List<Target> outdatedTargets = await repositoryManager.TargetRepository.GetAllTargets().AsNoTracking()
				.Where(t => t.UserId.Equals(userId))
				.Where(t =>
				(t.TargetPeriodTypeId == 1 && DateTime.Now > t.PeriodTime.AddDays(t.PeriodLength)) ||
				(t.TargetPeriodTypeId == 2 && DateTime.Now > t.PeriodTime.AddDays(7 * t.PeriodLength)) ||
				(t.TargetPeriodTypeId == 3 && DateTime.Now > t.PeriodTime.AddMonths(t.PeriodLength)) ||
				(t.TargetPeriodTypeId == 4 && DateTime.Now > t.PeriodTime.AddYears(t.PeriodLength))
				).ToListAsync();
			for (int i = 0; i < outdatedTargets.Count(); i++)
			{
				DateTime temp = outdatedTargets[i].PeriodTime;

				do
				{
					temp = Target.GetPeriodEndTime(outdatedTargets[i].TargetPeriodTypeId, temp, outdatedTargets[i].PeriodLength);
				}
				while (DateTime.Now > Target.GetPeriodEndTime(outdatedTargets[i].TargetPeriodTypeId, temp, outdatedTargets[i].PeriodLength));
				outdatedTargets[i].PeriodTime = temp;

			}
			repositoryManager.TargetRepository.UpdateTargetRange(outdatedTargets);
		}
		public void RemoveTarget(Target target)
		{
			repositoryManager.TargetRepository.RemoveTarget(target);
		}
		public async Task RemoveTarget(Target target, int userId) => await RemoveTarget(target.Id, userId);
		public void RemoveTarget(List<Target> targets)
		{

			repositoryManager.TargetRepository.RemoveTarget(targets);
		}
		public async Task RemoveTarget(int targetId, int userId)
		{
			List<Target> targets = await repositoryManager.TargetRepository.GetAllTargets().Where(t => t.Id.Equals(targetId) && t.UserId.Equals(userId)).ToListAsync();
			repositoryManager.TargetRepository.RemoveTarget(targets);
		}

		public List<TargetStatus> GetUsersTargetStatus(User user) => GetUsersAllTargetStatus(user.Id);
		public List<TargetStatus> GetUsersAllTargetStatus(int userId)
		{
			return repositoryManager.TargetRepository.GetAllTargetStatus()
				.Include(ts => ts.Target).Where(ts => ts.Target!.UserId.Equals(userId)).AsNoTracking().ToList();
		}

		public List<TargetStatus> GetAllTargetStatus(Target target) => GetAllTargetStatus(target.Id);
		public List<TargetStatus> GetAllTargetStatus(int targetId)
		{
			return repositoryManager.TargetRepository.GetAllTargetStatus()
				.Where(ts => ts.TargetId.Equals(targetId)).ToList();
		}
		public TargetStatus? GetTargetStatus(TargetStatus targetStatus) => GetTargetStatus(targetStatus.Id);
		public TargetStatus? GetTargetStatus(int targetStatusId)
		{
			return repositoryManager.TargetRepository.GetAllTargetStatus()
				.Where(ts => ts.Id.Equals(targetStatusId)).SingleOrDefault();
		}
		public void CreateTargetStatus(TargetStatus targetStatus)
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
		public void RemoveTargetStatus(List<TargetStatus> targetStatus)
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
