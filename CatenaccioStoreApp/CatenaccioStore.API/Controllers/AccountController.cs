using CatenaccioStore.API.Infrastructure.constans;
using CatenaccioStore.Application.Services.Accounts.Abstraction;
using CatenaccioStore.Application.Services.Accounts.constant;
using CatenaccioStore.Application.Services.Accounts.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
            try
            {
                return Ok(await _accountService.GetUserByEmail(email));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                return Ok(await _accountService.GetAll());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        //[Authorize(Roles = UserType.Admin)]
        [HttpPost("Roles")]
        public async Task<IActionResult> CreateRoles(UserRoles role)
        {
            try
            {
                return Ok(await _accountService.CreateRoles(role));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpPost("Moderator")]
        public async Task<IActionResult> AddUser(AccountDto input)
        {
            try
            {
                return Ok(await _accountService.CreateModerator(input));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        //[Authorize(Roles = UserType.Admin)]
        [HttpPost("Admin")]
        public async Task<IActionResult> AddAdmin(AccountDto input)
        {
            try
            {
                return Ok(await _accountService.CreateAdmin(input));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpPut("UpdateUserName")]
        public async Task<IActionResult> Update(string email, string userName)
        {
            try
            {
                return Ok(await _accountService.UpdateUserName(email, userName));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpDelete]
        public async Task<IActionResult> Delete(string email)
        {
            try
            {
                return Ok(await _accountService.DeleteUser(email));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Register(RegisterDto input)
        {
            try
            {
                return Ok(await _accountService.Register(input));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LogIn(LoginDto input)
        {
            try
            {
                var result = await _accountService.LogIn(input);
                if(result.Length > 0)
                    return Ok(await _accountService.LogIn(input));
                throw new Exception();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
