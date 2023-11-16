using CatenaccioStore.Application.Services.constant;
using CatenaccioStore.Application.Services.DTOs;

namespace CatenaccioStore.Application.Services.Abstraction
{
    public interface IAccountService
    {
        Task<string> LogIn(string email, string password);
        Task<bool> Register(AccountDto account);
        Task<AccountDto> GetUserByEmail(string email);
        Task<List<AccountDto>> GetAll();
        Task<bool> CreateModerator(AccountDto account);
        Task<bool> CreateAdmin(AccountDto account);
        Task<bool> UpdateUserName(string email, string userName);
        Task<bool> DeleteUser(string email);
        Task<bool> CreateRoles(Role role);
    }
}
