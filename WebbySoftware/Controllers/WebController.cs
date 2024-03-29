using AutoMapper;
using WebbySoftware.Application.WebOperations.Commands.CreateWebApp;
using WebbySoftware.Application.WebOperations.Commands.DeleteWeb;
using WebbySoftware.Application.WebOperations.Commands.UpdateWebApp;
using WebbySoftware.Application.WebOperations.Queries;
using WebbySoftware.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebbySoftware.Controllers.WebController;

public class WebController : Controller
{
    private readonly IWebbySoftDBContext _context;
    private readonly IMapper _mapper;

    public WebController(IWebbySoftDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("Development/WebDevelopment")]
    public IActionResult WebDevelopment(string? searchedTag)
    {
        GetWebQuery query = new GetWebQuery(_context, _mapper);
        var result = string.IsNullOrEmpty(searchedTag) ? query.Handle() : query.Handle(searchedTag);
        return View("~/Views/Development/WebDevelopment.cshtml", result);
    }

    [HttpGet("Development/WebDevelopment/[action]")]
    public IActionResult GetWebQuery(string? searchedTag)
    {
        GetWebQuery query = new GetWebQuery(_context, _mapper);
        var result = string.IsNullOrEmpty(searchedTag) ? query.Handle() : query.Handle(searchedTag);
        return Ok(result);
    }

    [HttpGet("Development/WebDevelopment/[action]/{id}")]
    public IActionResult GetWebById(int id)
    {
        GetWebByID query = new GetWebByID(_context,_mapper);
        GetWebByIDModel result;
        query.WebAppID = id;
        GetWebByIdValidator validator = new GetWebByIdValidator();
        validator.ValidateAndThrow(query);
        result = query.Handle();
        return Ok(result);
    }

    [HttpPost("Development/WebDevelopment/[action]")]
    public IActionResult CreateWeb([FromBody] WebDevModel newWeb)
    {
        CreateWebAppCommand command = new CreateWebAppCommand(_context,_mapper);
        command.Model = newWeb;
        CreateWebAppCommandValidator validator = new CreateWebAppCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpPut("Development/WebDevelopment/[action]/{id}")]
    public IActionResult UpdateWeb(int id,[FromBody] UpdateWebAppModel updateWeb)
    {
        UpdateWebAppCommand command = new UpdateWebAppCommand (_context,_mapper);

        command.WebAppID = id;
        command.Model = updateWeb;
        UpdateWebAppCommandValidator validator = new UpdateWebAppCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle(); 
        return Ok();
    }

    [HttpDelete("Development/WebDevelopment/[action]/{id}")]
    public IActionResult DeleteWeb(int id)
    {
        DeleteWebAppCommand command = new DeleteWebAppCommand(_context);
        command.WebAppID=id;
        DeleteWebAppCommandValidator validator = new DeleteWebAppCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
}