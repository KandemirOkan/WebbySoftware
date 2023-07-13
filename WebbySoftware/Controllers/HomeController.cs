using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using WebbySoftware.Application.DevOperations.Queries;
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
			GetAllDevelopmentTitles query = new GetAllDevelopmentTitles(_context, _mapper);
			var result = query.Handle();
			return View("Home", result);
		}

		[HttpGet("About")]
		public IActionResult About()
		{
			return View();
		}

		[HttpGet("Team")]
		public IActionResult Team()
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

	}
}