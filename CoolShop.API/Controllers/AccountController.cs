using CoolShop.API.Dtos;
using CoolShop.Common;
using CoolShop.Common.Repositories;
using CoolShop.Common.Services;
using CoolShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoolShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountService accountService, IUserRepository userRepository, ILogger<AccountController> logger)
        {
            this._accountService = accountService;
            this._userRepository = userRepository;
            this._logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            _logger.LogInformation($"Try login by - {loginDto.Login}");
            try
            {
                var result = await _accountService.Login(loginDto.Login, loginDto.Password);
                if (result.user == null) return NotFound(loginDto.Login);
                return Ok(new { result.user, result.token });
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError(ex, ex.Message);
                return Unauthorized(loginDto.Login);
            }
        }

        [HttpPost("register/user")]
        public async Task<IActionResult> Register(AccountDto accountDto)
        {
            _logger.LogInformation($"Register begin process with account dto - {accountDto}");

            var user = new User()
            {
                Email = accountDto.Email,
                FirstName = accountDto.FirstName,
                LastName = accountDto.LastName,
                Password = accountDto.Password,
                PhoneNumber = accountDto.PhoneNumber,
                Login = accountDto.Login
            };

            var result = await _accountService.Register(user);
            return Created("api/Account/" + user.Id, new { user, result.token });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAccount(int id)
        {
            _logger.LogInformation($"Get account by id - {id}");

            var user = await _userRepository.GetUser(id);
            if (user != null)
                return Ok(user);

            return NotFound("Account not found!");
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAccountsList([FromQuery] string? firstName = null, [FromQuery] string? lastName = null)
        {
            _logger.LogInformation($"Get all accounts");

            var reuslts = await _userRepository.GetUsers(firstName, lastName);
            return Ok(reuslts);
        }
    }
}
