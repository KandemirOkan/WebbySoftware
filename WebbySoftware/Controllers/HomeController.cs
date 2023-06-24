using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using WebbySoftware.Models;

namespace WebbySoftware.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet("")]
		public IActionResult Home()
		{
			return View();
		}

		[HttpGet("About")]
		public IActionResult About()
		{
			return View();
		}

		[HttpGet("Contact")]
		public IActionResult Contact()
		{
			return View();
		}

		[HttpGet("Development/GameDevelopment")]
		public IActionResult GameDevelopment()
		{
			return View();
		}

		[HttpGet("Development/WebDevelopment")]
		public IActionResult WebDevelopment()
		{
			return View();
		}

		[HttpGet("Development/MobileAppDevelopment")]
		public IActionResult MobileAppDevelopment()
		{
			return View();
		}
	}
}