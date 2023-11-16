using Microsoft.AspNetCore.Identity;


namespace CatenaccioStore.Domain.Entities.Users
{
    public class AppUser : IdentityUser<string>
    {
        public ICollection<AppUserRole> AppUserRoles { get; set; }
    }
}
