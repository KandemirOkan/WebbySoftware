using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using WebbySoftware.Application.GameOperations.Queries;
using WebbySoftware.Application.MobileAppOperations.Queries;
using WebbySoftware.Application.UserOperations.Queries;
using WebbySoftware.Application.WebOperations.Queries;
using WebbySoftware.DBOperations;
using WebbySoftware.Models;

namespace WebbySoftware.Controllers
{
	public class HomeController : Controller
	{

		private readonly IWebbySoftDBContext _context;
		private readonly IMapper _mapper;

		public HomeController(IWebbySoftDBContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		
		[HttpGet("")]
		public IActionResult Home()
		{
			return View();
		}

		[HttpGet("About")]
		public IActionResult About()
		{
			GetUserQuery query = new GetUserQuery(_context, _mapper);
			var result = query.Handle();
			return View(result);
		}

		[HttpGet("Contact")]
		public IActionResult Contact()
		{
			return View();
		}

		[HttpGet("Development/GameDevelopment")]
		public IActionResult GameDevelopment()
		{
			GetGameQuery query = new(_context,_mapper);
			var result = query.Handle();
			return View("~/Views/Development/GameDevelopment.cshtml", result);
		}

		[HttpGet("Development/WebDevelopment")]
		public IActionResult WebDevelopment()
		{
			GetWebQuery query = new(_context,_mapper);
			var result = query.Handle();
			return View("~/Views/Development/WebDevelopment.cshtml", result);
		}

		[HttpGet("Development/MobileAppDevelopment")]
		public IActionResult MobileAppDevelopment()
		{
			GetMobileAppQuery query = new(_context,_mapper);
			var result = query.Handle();
			return View("~/Views/Development/MobileAppDevelopment.cshtml", result);
		}
	}
}