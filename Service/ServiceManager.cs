using Services.Interfaces;

namespace Services
{
	public class ServiceManager : IServiceManager
	{
		private readonly IUserService userService;

		public ServiceManager(IUserService userService)
		{
			this.userService = userService;
		}

		public IUserService UserService => userService;

	}
}
