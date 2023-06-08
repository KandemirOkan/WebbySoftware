using Microsoft.AspNetCore.Mvc;

namespace WebbySoftware.Controllers
{
	public class DevelopmentController : Controller
	{
		public IActionResult GameDevelopment()
		{
			return View();
		}

		public IActionResult WebDevelopment()
		{
			return View();
		}

		public IActionResult MobileAppDevelopment()
		{
			return View();
		}
	}
}
