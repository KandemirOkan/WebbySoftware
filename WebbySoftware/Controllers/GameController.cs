using AutoMapper;
using WebbySoftware.Application.GameOperations.Commands.CreateGame;
using WebbySoftware.Application.GameOperations.Commands.DeleteGame;
using WebbySoftware.Application.GameOperations.Commands.UpdateGame;
using WebbySoftware.Application.GameOperations.Queries;
using WebbySoftware.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebbySoftware.Controllers.GameController;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly IWebbySoftDBContext context;
    private readonly IMapper _mapper;

    public GameController(IWebbySoftDBContext _context,IMapper mapper)
    {
        context = _context;
        _mapper = mapper;
    }

    [HttpGet("Development/GameDevelopment")]
    public IActionResult GameDevelopment(string searchedTag)
    {
        GetGameQuery query = new GetGameQuery(_context, _mapper);
        var result = string.IsNullOrEmpty(searchedTag) ? query.Handle() : query.Handle(searchedTag);
        return View("~/Views/Development/GameDevelopment.cshtml", result);
    }

    [HttpGet("Development/GameDevelopment/[action]")]
    public IActionResult GetGameQuery(string searchedTag)
    {
        GetGameQuery query = new GetGameQuery(context, _mapper);
        var result = string.IsNullOrEmpty(searchedTag) ? query.Handle() : query.Handle(searchedTag);
        return Ok(result);
    }


    [HttpGet("Development/GameDevelopment/[action]/{id}")]
    public IActionResult GetGameById(int id)
    {
        GetGameByID query = new GetGameByID(context,_mapper);
        GameDevIdModel result;
        query.GameID = id;
        GetGameByIdValidator validator = new GetGameByIdValidator();
        validator.ValidateAndThrow(query);
        result = query.Handle();
        return Ok(result);
    }

    [HttpPost("Development/GameDevelopment/[action]")]
    public IActionResult CreateGame([FromBody] GameDevModel newGame)
    {
        CreateGameCommand command = new CreateGameCommand(context,_mapper);
        command.Model = newGame;
        CreateGameCommandValidator validator = new CreateGameCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpPut("Development/GameDevelopment/[action]/{id}")]
    public IActionResult UpdateGame(int id,[FromBody] UpdateGameModel updateGame)
    {
        UpdateGameCommand command = new UpdateGameCommand(context,_mapper);

        command.GameID = id;
        command.Model = updateGame;
        UpdateGameCommandValidator validator = new UpdateGameCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle(); 
        return Ok();
    }

    [HttpDelete("Development/GameDevelopment/[action]/{id}")]
    public IActionResult DeleteGame(int id)
    {
        DeleteGameCommand command = new DeleteGameCommand(context);
        command.GameID=id;
        DeleteGameCommandValidator validator = new DeleteGameCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
}