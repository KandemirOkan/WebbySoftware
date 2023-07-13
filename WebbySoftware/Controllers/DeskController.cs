using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebbySoftware.Application.DeskOperations.Commands.CreateDesk;
using WebbySoftware.Application.DeskOperations.Commands.DeleteDesk;
using WebbySoftware.Application.DeskOperations.Commands.UpdateDesk;
using WebbySoftware.Application.DeskOperations.Queries;
using WebbySoftware.DBOperations;
using FluentValidation;
namespace WebbySoftware.Controllers.DeskController
{
    public class DeskController: Controller
    {
        private readonly IWebbySoftDBContext _context;
        private readonly IMapper _mapper;

        public DeskController(IWebbySoftDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("Development/DesktopDevelopment")]
        public IActionResult DesktopDevelopment(string searchedTag)
        {
            GetDeskQuery query = new GetDeskQuery(_context, _mapper);
            var result = string.IsNullOrEmpty(searchedTag) ? query.Handle() : query.Handle(searchedTag);
            return View("~/Views/Development/DesktopDevelopment.cshtml", result);
        }

        [HttpGet("Development/DesktopDevelopment/[action]")]
        public IActionResult GetDeskQuery(string searchedTag)
        {
            GetDeskQuery query = new GetDeskQuery(_context, _mapper);
            var result = string.IsNullOrEmpty(searchedTag) ? query.Handle() : query.Handle(searchedTag);
            return Ok(result);
        }


        [HttpGet("Development/DesktopDevelopment/[action]/{id}")]
        public IActionResult GetDeskById(int id)
        {
            GetDeskById query = new GetDeskById(_context,_mapper);
            DeskDevIdModel result;
            query.DeskID = id;
            GetDeskByIdValidator validator = new GetDeskByIdValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }

        [HttpPost("Development/DesktopDevelopment/[action]")]
        public IActionResult CreateDesktopApp([FromBody] DeskDevModel newDesk)
        {
            CreateDeskCommand command = new CreateDeskCommand(_context,_mapper);
            command.Model = newDesk;
            CreateDeskCommandValidator validator = new CreateDeskCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("Development/DesktopDevelopment/[action]/{id}")]
        public IActionResult UpdateDesktopApp(int id,[FromBody] UpdateDeskModel updateDesk)
        {
            UpdateDeskCommand command = new UpdateDeskCommand(_context,_mapper);

            command.DeskID = id;
            command.Model = updateDesk;
            UpdateDeskCommandValidator validator = new UpdateDeskCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle(); 
            return Ok();
        }

        [HttpDelete("Development/DesktopDevelopment/[action]/{id}")]
        public IActionResult DeleteDesktopApp(int id)
        {
            DeleteDeskCommand command = new DeleteDeskCommand(_context);
            command.DeskID=id;
            DeleteDeskCommandValidator validator = new DeleteDeskCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}