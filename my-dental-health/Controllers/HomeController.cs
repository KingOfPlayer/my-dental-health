﻿using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace my_dental_health.Controllers
{
	public class HomeController : Controller
	{
		IServiceManager serviceManager;

		public HomeController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Users()
		{
			return View(serviceManager.UserService.GetAllUsers());
		}
	}
}
