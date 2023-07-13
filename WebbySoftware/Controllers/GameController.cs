using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebbySoftware.Application.GameOperations.Commands.CreateGame;
using WebbySoftware.Application.GameOperations.Commands.DeleteGame;
using WebbySoftware.Application.GameOperations.Commands.UpdateGame;
using WebbySoftware.Application.GameOperations.Queries;
using WebbySoftware.DBOperations;
using FluentValidation;
using WebbySoftware.Models;

namespace WebbySoftware.Controllers.GameController;

[ApiController]
[Route("[controller]")]
public class GameController : Controller
{
    private readonly IWebbySoftDBContext _context;
    private readonly IMapper _mapper;

    public GameController(IWebbySoftDBContext context, IMapper mapper)
    {
        _context = context;
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
        GetGameQuery query = new GetGameQuery(_context, _mapper);
        var result = string.IsNullOrEmpty(searchedTag) ? query.Handle() : query.Handle(searchedTag);
        return Ok(result);
    }


    [HttpGet("Development/GameDevelopment/[action]/{id}")]
    public IActionResult GetGameById(int id)
    {
        GetGameByID query = new GetGameByID(_context,_mapper);
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
        CreateGameCommand command = new CreateGameCommand(_context,_mapper);
        command.Model = newGame;
        CreateGameCommandValidator validator = new CreateGameCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpPut("Development/GameDevelopment/[action]/{id}")]
    public IActionResult UpdateGame(int id,[FromBody] UpdateGameModel updateGame)
    {
        UpdateGameCommand command = new UpdateGameCommand(_context,_mapper);

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
        DeleteGameCommand command = new DeleteGameCommand(_context);
        command.GameID=id;
        DeleteGameCommandValidator validator = new DeleteGameCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
}