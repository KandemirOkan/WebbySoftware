using AutoMapper;
using WebbySoftware.Application.GameOperations.Commands.CreateGame;
using WebbySoftware.Application.GameOperations.Commands.DeleteGame;
using WebbySoftware.Application.GameOperations.Commands.UpdateGame;
using WebbySoftware.Application.GameOperations.Quearies;
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

    [HttpGet("[action]")]
    public IActionResult GetGameQuery()
    {
       GetGameQuery query = new(context,_mapper);
       var result = query.Handle();
       return Ok(result);
    }

    [HttpGet("[action]/{id}")]
    public IActionResult GetGameById(int id)
    {
        GetGameById query = new GetGameById(context,_mapper);
        GameViewIdModel result;
        query.GameID = id;
        GetGameByIdValidator validator = new GetGameByIdValidator();
        validator.ValidateAndThrow(query);
        result = query.Handle();
        return Ok(result);
    }

    [HttpPost("[action]")]
    public IActionResult CreateGame([FromBody] GameDevModel newGame)
    {
        CreateGameCommand command = new CreateGameCommand(context,_mapper);
        command.Model = newGame;
        CreateGameCommandValidator validator = new CreateGameCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpPut("[action]/{id}")]
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

    [HttpDelete("[action]/{id}")]
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