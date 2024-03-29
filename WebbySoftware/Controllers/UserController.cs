using AutoMapper;
using WebbySoftware.Application.UserOperations.Commands.CreateToken;
using WebbySoftware.Application.UserOperations.Commands.CreateUser;
using WebbySoftware.Application.UserOperations.Commands.DeleteUser;
using WebbySoftware.Application.UserOperations.Commands.UpdateUser;
using WebbySoftware.Application.UserOperations.Commands.RefreshToken;
using WebbySoftware.Application.UserOperations.Queries;
using WebbySoftware.DBOperations;
using WebbySoftware.TokenOperations;
using Microsoft.AspNetCore.Mvc;
using static WebbySoftware.Application.UserOperations.Commands.CreateUser.CreateUserCommand;


namespace WebbySoftware.Controllers.UserController;

public class UserController : Controller
{
    private readonly IWebbySoftDBContext _context;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public UserController(IWebbySoftDBContext context,IConfiguration configuration, IMapper mapper)
    {
        _context = context;
        _configuration = configuration;
        _mapper = mapper;
    }

    [HttpGet("Team/[action]")]
    public IActionResult Contact()
    {
        GetUserQuery query = new GetUserQuery(_context, _mapper);
        var result = query.Handle();
        return View("~/Views/Contact.cshtml", result);
    }

    [HttpGet("Team/[action]")]
    public IActionResult GetAllUsers()
    {
        GetUserQuery query = new GetUserQuery(_context, _mapper);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpPost("Team/[action]")]
    public IActionResult CreateUser([FromBody] CreateUserModel newUser)
    {
        CreateUserCommand command = new(_context,_mapper);
        command.Model = newUser;
        command.Handle();
        return Ok();
    }

    [HttpPost("Team/[action]")]
    public IActionResult UpdateUser(int id, [FromBody] UpdateUserModel newUser)
    {
        UpdateUserCommand command = new(_context,_mapper);
        command.UserID = id;
        command.Model = newUser;
        command.Handle();
        return Ok();
    }

    [HttpDelete("Team/[action]/{id}")]
    public IActionResult DeleteUser(int id)
    {
        DeleteUserCommand command = new(_context);
        command.UserID=id;
        command.Handle();
        return Ok();
    }
    
    [HttpPost("Team/[action]/{id}")]
    public ActionResult<Token> CreateToken([FromBody] CreateTokenModel newToken)
    {
        CreateTokenCommand command = new(_context, _mapper, _configuration);
        command.Model = newToken;
        var token = command.Handle();
        return token;
    }

    [HttpGet("Team/[action]")]
    public ActionResult<Token> RefreshToken([FromQuery] string token)
    {
        RefreshTokenCommand command = new(_context, _configuration);
        command.RefreshToken = token;
        var refreshedToken = command.Handle();
        return refreshedToken;
    }
}