using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebbySoftware.Models;

namespace WebbySoftware.Controllers
{
	public class HomeController : Controller
	{
		[Route("")]
		public IActionResult Home()
		{
			return View();
		}

		[Route("About")]
		public IActionResult About()
		{
			return View();
		}

		[Route("Contact")]
		public IActionResult Contact()
		{
			return View();
		}

		[Route("Development/GameDevelopment")]
		public IActionResult GameDevelopment()
		{
			return View();
		}

		[Route("Development/WebDevelopment")]
		public IActionResult WebDevelopment()
		{
			return View();
		}

		[Route("Development/MobileAppDevelopment")]
		public IActionResult MobileAppDevelopment()
		{
			return View();
		}


	}
}