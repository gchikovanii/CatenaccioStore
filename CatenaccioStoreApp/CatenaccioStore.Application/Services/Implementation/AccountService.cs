using CatenaccioStore.Application.Infrastruture.Errors;
using CatenaccioStore.Application.Infrastruture.JWT;
using CatenaccioStore.Application.Services.Abstraction;
using CatenaccioStore.Application.Services.constant;
using CatenaccioStore.Application.Services.DTOs;
using CatenaccioStore.Domain.Entities.Users;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CatenaccioStore.Application.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtAuthenticationManager jwtAuthenticationManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _roleManager = roleManager;
        }
        public async Task<string> LogIn(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var result = await _signInManager.PasswordSignInAsync(user, password, true, false);
            var roles = await _userManager.GetRolesAsync(user);
            return _jwtAuthenticationManager.Authenticate(result.Succeeded, email, roles.ToList());
        }
        public async Task<bool> Register(AccountDto account)
        {
            var userExists = await _userManager.FindByEmailAsync(account.Email);
            var checkUserName = await _userManager.FindByNameAsync(account.UserName);
            if (userExists == null)
            {

                if (checkUserName != null)
                {
                    throw new AlreadyExists("User Name isn't avaliable!");
                }
                var currentUser = new AppUser()
                {
                    UserName = account.UserName,
                    Email = account.Email,
                    PhoneNumber = account.PhoneNumber
                };
                var createdUser = await _userManager.CreateAsync(currentUser, account.Password);
                if (createdUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(currentUser, Role.User.ToString());
                    return true;
                }
            }
            throw new AlreadyExists("Email already is registered!");
        }
        public async Task<AccountDto> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user.Adapt<AccountDto>();
        }
        public async Task<List<AccountDto>> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            return users.Adapt<List<AccountDto>>();
        }
        public async Task<bool> CreateModerator(AccountDto account)
        {
            var userExists = await _userManager.FindByEmailAsync(account.Email);
            var checkUserName = await _userManager.FindByNameAsync(account.UserName);
            if (userExists == null)
            {

                if (checkUserName != null)
                {
                    throw new AlreadyExists("Already Exists with this username!");
                }
                var currentUser = new AppUser()
                {
                    UserName = account.UserName,
                    Email = account.Email,
                    PhoneNumber = account.PhoneNumber
                };
                var createdUser = await _userManager.CreateAsync(currentUser, account.Password);
                if (createdUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(currentUser, Role.Moderator.ToString());
                    return true;
                }
            }
            throw new AlreadyExists("Email Already Exists!");
        }
        public async Task<bool> CreateAdmin(AccountDto account)
        {
            var userExists = await _userManager.FindByEmailAsync(account.Email);
            var checkUserName = await _userManager.FindByNameAsync(account.UserName);
            if (userExists == null)
            {

                if (checkUserName != null)
                {
                    throw new AlreadyExists("Already Exists with this username!");
                }
                var currentUser = new AppUser()
                {
                    UserName = account.UserName,
                    Email = account.Email,
                    PhoneNumber = account.PhoneNumber
                };
                var createdUser = await _userManager.CreateAsync(currentUser, account.Password);
                if (createdUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(currentUser, Role.Admin.ToString());
                    return true;
                }
            }
            throw new AlreadyExists("Already Exists with this email!");
        }
        public async Task<bool> UpdateUserName(string email, string userName)
        {
            var userExists = await _userManager.FindByEmailAsync(email);
            if (userExists != null)
            {
                var userNameExists = await _userManager.FindByNameAsync(userName);
                if (userNameExists != null)
                {
                    throw new AlreadyExists("Already Exists with this username!");
                }
                else
                {
                    userExists.UserName = userName;
                    var result = await _userManager.UpdateAsync(userExists);
                    if (result.Succeeded)
                        return true;
                }
            }
            return false;
        }
        public async Task<bool> DeleteUser(string email)
        {
            var userExists = await _userManager.FindByEmailAsync(email);
            if (userExists != null)
            {
                var result = await _userManager.DeleteAsync(userExists);
                if (result.Succeeded)
                    return true;

            }
            throw new NotFoundException("User With This Email Doesn't exists");
        }
        public async Task<bool> CreateRoles(Role role)
        {
            var roleExists = await _roleManager.FindByNameAsync(role.ToString());
            if (roleExists == null)
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = role.ToString()
                });
                return true;
            }
            return false;
        }

    }
}
