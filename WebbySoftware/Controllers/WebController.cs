using AutoMapper;
using WebbySoftware.Application.WebOperations.Commands.CreateWebApp;
using WebbySoftware.Application.WebOperations.Commands.DeleteWeb;
using WebbySoftware.Application.WebOperations.Commands.UpdateWebApp;
using WebbySoftware.Application.WebOperations.Queries;
using WebbySoftware.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebbySoftware.Controllers.WebController;

[ApiController]
[Route("[controller]")]
public class WebController : ControllerBase
{
    private readonly IWebbySoftDBContext context;
    private readonly IMapper _mapper;

    public WebController(IWebbySoftDBContext _context,IMapper mapper)
    {
        context = _context;
        _mapper = mapper;
    }

    [HttpGet("[action]")]
    public IActionResult GetWebQuery()
    {
       GetWebQuery query = new(context,_mapper);
       var result = query.Handle();
       return Ok(result);
    }

    [HttpGet("[action]/{id}")]
    public IActionResult GetWebById(int id)
    {
        GetWebByID query = new GetWebByID(context,_mapper);
        GetWebByIDModel result;
        query.WebAppID = id;
        GetWebByIdValidator validator = new GetWebByIdValidator();
        validator.ValidateAndThrow(query);
        result = query.Handle();
        return Ok(result);
    }

    [HttpPost("[action]")]
    public IActionResult CreateWeb([FromBody] WebDevModel newWeb)
    {
        CreateWebAppCommand command = new CreateWebAppCommand(context,_mapper);
        command.Model = newWeb;
        CreateWebAppCommandValidator validator = new CreateWebAppCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpPut("[action]/{id}")]
    public IActionResult UpdateWeb(int id,[FromBody] UpdateWebAppModel updateWeb)
    {
        UpdateWebAppCommand command = new UpdateWebAppCommand (context,_mapper);

        command.WebAppID = id;
        command.Model = updateWeb;
        UpdateWebAppCommandValidator validator = new UpdateWebAppCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle(); 
        return Ok();
    }

    [HttpDelete("[action]/{id}")]
    public IActionResult DeleteWeb(int id)
    {
        DeleteWebAppCommand command = new DeleteWebAppCommand(context);
        command.WebAppID=id;
        DeleteWebAppCommandValidator validator = new DeleteWebAppCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
}