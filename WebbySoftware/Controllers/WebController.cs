using AutoMapper;
using WebbySoftware.Application.WebOperations.Commands.CreateWeb;
using WebbySoftware.Application.WebOperations.Commands.DeleteWeb;
using WebbySoftware.Application.WebOperations.Commands.UpdateWeb;
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
       GetGameQuery query = new(context,_mapper);
       var result = query.Handle();
       return Ok(result);
    }

    [HttpGet("[action]/{id}")]
    public IActionResult GetWebById(int id)
    {
        GetWebById query = new GetWebById(context,_mapper);
        WebViewIdModel result;
        query.WebAppID = id;
        GetWebByIdValidator validator = new GetWebByIdValidator();
        validator.ValidateAndThrow(query);
        result = query.Handle();
        return Ok(result);
    }

    [HttpPost("[action]")]
    public IActionResult CreateWeb([FromBody] WebDevModel newWeb)
    {
        CreateWebCommand command = new CreateWebCommand(context,_mapper);
        command.Model = newWeb;
        CreateWebCommandValidator validator = new CreateWebCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpPut("[action]/{id}")]
    public IActionResult UpdateWeb(int id,[FromBody] UpdateWebModel updateWeb)
    {
        UpdateWebCommand command = new UpdateWebCommand(context,_mapper);

        command.WebAppID = id;
        command.Model = updateGame;
        UpdateWebCommandValidator validator = new UpdateWebCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle(); 
        return Ok();
    }

    [HttpDelete("[action]/{id}")]
    public IActionResult DeleteWeb(int id)
    {
        DeleteWebCommand command = new DeleteWebCommand(context);
        command.WebAppID=id;
        DeleteWebCommandValidator validator = new DeleteWebCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
}