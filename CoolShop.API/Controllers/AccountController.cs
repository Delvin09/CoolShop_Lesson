using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoolShop.API.Controllers
{
    public record AccountDto(string Login, string Password, string FirstName, string LastName, string Email, string PhoneNumber);
    public record Account(int Id, string Login, string Password, string FirstName, string LastName, string Email, string PhoneNumber) : AccountDto(Login, Password, FirstName, LastName, Email, PhoneNumber)
    {
        public bool IsLogin { get; set; }
    }

    public record LoginDto(string Login, string Password);

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        private static int _idCounter = 0;
        private static List<Account> _accounts = new List<Account>();

        public AccountController(ILogger<AccountController> logger)
        {
            this._logger = logger;
        }

        // TODO: Добавить бд и слои абстракций
        // TODO: jwt аутидентификация/авторизация
        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            _logger.LogInformation($"Try login by - {loginDto.Login}");
            var account = _accounts.FirstOrDefault(a => a.Login == loginDto.Login);
            if (account == null) return NotFound(loginDto.Login);
            if (account.Password != loginDto.Password) return Unauthorized(loginDto.Login);
            account.IsLogin = true;

            return Ok(account);
        }

        [HttpPut("logout/{login}")]
        public IActionResult Logout(string login)
        {
            _logger.LogInformation($"Try logout by - {login}");
            var account = _accounts.FirstOrDefault(a => a.Login == login);
            if (account == null) return NotFound(login);

            account.IsLogin = false;

            return Ok();
        }

        [HttpPost("register/user")]
        public IActionResult Register(AccountDto accountDto)
        {
            _logger.LogInformation($"Register begin process with account dto - {accountDto}");

            _idCounter++;
            Account account = new Account(
            _idCounter, accountDto.Login, accountDto.Password, accountDto.FirstName, accountDto.LastName, accountDto.Email, accountDto.PhoneNumber);

            _accounts.Add(account);

            return Created("api/Account/" + account.Id, null);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAccount(int id)
        {
            _logger.LogInformation($"Get account by id - {id}");

            var account = _accounts.FirstOrDefault(a => a.Id == id);
            if (account != null)
                return Ok(account);

            return BadRequest("Account not found!");
        }

        [HttpGet("list")]
        public IActionResult GetAccountsList([FromQuery] string? firstName = null, [FromQuery] string? lastName = null)
        {
            _logger.LogInformation($"Get all accounts");
            var result = _accounts
                .Where(a =>
                {
                    if (firstName != null)
                        return a.FirstName == firstName;
                    else
                        return true;
                })
                .Where(a =>
                {
                    if (lastName != null)
                        return a.LastName == lastName;
                    else
                        return true;
                });

            return Ok(result);
        }
    }
}
