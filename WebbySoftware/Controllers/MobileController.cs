using AutoMapper;
using WebbySoftware.Application.MobileAppOperations.Commands.CreateMobileApp;
using WebbySoftware.Application.MobileAppOperations.Commands.DeleteMobileApp;
using WebbySoftware.Application.MobileAppOperations.Commands.UpdateMobileApp;
using WebbySoftware.Application.MobileAppOperations.Queries;
using WebbySoftware.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebbySoftware.Controllers.MobileAppController;

[ApiController]
[Route("[controller]")]
public class MobileAppController : Controller
{
    private readonly IWebbySoftDBContext _context;
    private readonly IMapper _mapper;

    public MobileAppController(IWebbySoftDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("Development/MobileAppDevelopment")]
    public IActionResult MobileAppDevelopment(string searchedTag)
    {
        GetMobileAppQuery query = new GetMobileAppQuery(_context, _mapper);
        var result = string.IsNullOrEmpty(searchedTag) ? query.Handle() : query.Handle(searchedTag);
        return View("~/Views/Development/MobileAppDevelopment.cshtml", result);
    }

    [HttpGet("Development/MobileAppDevelopment/[action]")]
    public IActionResult GetMobileAppQuery(string searchedTag)
    {
        GetMobileAppQuery query = new GetMobileAppQuery(_context, _mapper);
        var result = string.IsNullOrEmpty(searchedTag) ? query.Handle() : query.Handle(searchedTag);
        return Ok(result);
    }

    [HttpGet("Development/MobileAppDevelopment/[action]/{id}")]
    public IActionResult GetMobileAppById(int id)
    {
        GetMobileAppByID query = new GetMobileAppByID(_context,_mapper);
        MobileAppIdModel result;
        query.MobileAppID = id;
        GetMobileAppByIdValidator validator = new GetMobileAppByIdValidator();
        validator.ValidateAndThrow(query);
        result = query.Handle();
        return Ok(result);
    }

    [HttpPost("Development/MobileAppDevelopment/[action]")]
    public IActionResult CreateMobileApp([FromBody] MobileAppDevModel newMobileApp)
    {
        CreateMobileAppCommand command = new CreateMobileAppCommand(_context,_mapper);
        command.Model = newMobileApp;
        CreateMobileAppCommandValidator validator = new CreateMobileAppCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpPut("Development/MobileAppDevelopment/[action]/{id}")]
    public IActionResult UpdateMobileApp(int id,[FromBody] UpdateMobileAppModel updateMobileApp)
    {
        UpdateMobileAppCommand command = new UpdateMobileAppCommand(_context,_mapper);

        command.MobileAppID = id;
        command.Model = updateMobileApp;
        UpdateMobileAppCommandValidator validator = new UpdateMobileAppCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle(); 
        return Ok();
    }

    [HttpDelete("Development/MobileAppDevelopment/[action]/{id}")]
    public IActionResult DeleteMobileApp(int id)
    {
        DeleteMobileAppCommand command = new DeleteMobileAppCommand(_context);
        command.MobileAppID=id;
        DeleteMobileAppCommandValidator validator = new DeleteMobileAppCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
}