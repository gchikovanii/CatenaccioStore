using CatenaccioStore.API.Infrastructure.constans;
using CatenaccioStore.Application.Services.Accounts.Abstraction;
using CatenaccioStore.Application.Services.Accounts.constant;
using CatenaccioStore.Application.Services.Accounts.DTOs;
using CatenaccioStore.Application.Services.Cloudinaries.Abstraction;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatenaccioStore.API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly ICloudinaryService _cloud;

        public AccountController(IAccountService accountService, ICloudinaryService cloud)
        {
            _accountService = accountService;
            _cloud = cloud;
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

        //[HttpPost("Test")]
        //public async Task<IActionResult> UplaodImage(IFormFile file)
        //{
        //    var result = await _cloud.UploadImage(file);
        //    return Ok(result);
        //}
        //[HttpPost("Test2")]
        //public async Task<IActionResult> UplaodImages(List<IFormFile> files)
        //{
        //    var result = await _cloud.UploadImages(files);
        //    return Ok(result);
        //}


    }
}
