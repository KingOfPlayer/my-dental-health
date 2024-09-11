using Service.Interfaces;

namespace Service
{
	public class ServiceManager : IServiceManager
	{
		private readonly IUserService userService;
		private readonly ITargetService targetService;
		private readonly IAdviceService adviceService;

		public ServiceManager(IUserService userService, ITargetService targetService, IAdviceService adviceService)
		{
			this.userService = userService;
			this.targetService = targetService;
			this.adviceService = adviceService;
		}

		public IUserService UserService => userService;
        public ITargetService TargetService => targetService;
		public IAdviceService AdviceService => adviceService;

	}
}
