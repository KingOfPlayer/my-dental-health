using Service.Interfaces;

namespace Service
{
	public class ServiceManager : IServiceManager
	{
		private readonly IUserService userService;
		private readonly ITargetService targetService;
		private readonly IAdviceService adviceService;
		private readonly IMailService mailService;

		public ServiceManager(IUserService userService, ITargetService targetService, IAdviceService adviceService, IMailService mailService)
		{
			this.userService = userService;
			this.targetService = targetService;
			this.adviceService = adviceService;
			this.mailService = mailService;
		}

		public IUserService UserService => userService;
        public ITargetService TargetService => targetService;
		public IAdviceService AdviceService => adviceService;
		public IMailService MailService => mailService;

	}
}
