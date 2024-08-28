using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
