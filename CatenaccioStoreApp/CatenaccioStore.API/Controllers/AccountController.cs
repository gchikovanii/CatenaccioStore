using CatenaccioStore.API.Infrastructure.constans;
using CatenaccioStore.Application.Services.Abstraction;
using CatenaccioStore.Application.Services.constant;
using CatenaccioStore.Application.Services.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatenaccioStore.API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpGet("GetByEmail")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            return Ok(await _accountService.GetUserByEmail(email));
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _accountService.GetAll());
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpPost("Roles")]
        public async Task<IActionResult> CreateRoles(Role role)
        {
            return Ok(await _accountService.CreateRoles(role));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpPost("Moderator")]
        public async Task<IActionResult> AddUser(AccountDto input)
        {
            return Ok(await _accountService.CreateModerator(input));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpPost("Admin")]
        public async Task<IActionResult> AddAdmin(AccountDto input)
        {
            return Ok(await _accountService.CreateAdmin(input));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpPut("UpdateUserName")]
        public async Task<IActionResult> Update(string email, string userName)
        {
            return Ok(await _accountService.UpdateUserName(email, userName));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpDelete]
        public async Task<IActionResult> Delete(string email)
        {
            return Ok(await _accountService.DeleteUser(email));
        }
        
        [HttpPost("Registration")]
        public async Task<IActionResult> Register(AccountDto input)
        {
            return Ok(await _accountService.Register(input));
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> LogIn(string email, string password)
        {
            return Ok(await _accountService.LogIn(email, password));
        }
    }
}
