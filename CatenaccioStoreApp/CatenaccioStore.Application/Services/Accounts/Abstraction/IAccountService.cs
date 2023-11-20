using CatenaccioStore.Application.Services.Accounts.constant;
using CatenaccioStore.Application.Services.Accounts.DTOs;

namespace CatenaccioStore.Application.Services.Accounts.Abstraction
{
    public interface IAccountService
    {
        Task<string> LogIn(LoginDto login);
        Task<bool> Register(RegisterDto account);
        Task<AccountDto> GetUserByEmail(string email);
        Task<List<AccountDto>> GetAll();
        Task<bool> CreateModerator(AccountDto account);
        Task<bool> CreateAdmin(AccountDto account);
        Task<bool> UpdateUserName(string email, string userName);
        Task<bool> DeleteUser(string email);
        Task<bool> CreateRoles(UserRoles role);
        Task Logout();
    }
}
