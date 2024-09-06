using Service.Interfaces;

namespace Service
{
	public class ServiceManager : IServiceManager
	{
		private readonly IUserService userService;
		private readonly ITargetService targetService;

        public ServiceManager(IUserService userService, ITargetService targetService)
        {
            this.userService = userService;
            this.targetService = targetService;
        }

        public IUserService UserService => userService;
        public ITargetService TargetService => targetService;

	}
}
