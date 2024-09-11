using AutoMapper;
using Entity.Models.Advice;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
	public class AdviceService : IAdviceService
	{
		private readonly IRepositoryManager repositoryManager;

		public AdviceService(IRepositoryManager repositoryManager)
		{
			this.repositoryManager = repositoryManager;
		}
		public Advice? GetRandomAdvice()
		{
			Random random = new Random();
			return repositoryManager.AdviceRepository.GetAllAdvice().ToList().OrderBy(a => random.Next()).FirstOrDefault();
		}
	}
}
