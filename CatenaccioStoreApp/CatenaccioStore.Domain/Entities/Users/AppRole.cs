using Microsoft.AspNetCore.Identity;


namespace CatenaccioStore.Domain.Entities.Users
{
    public class AppRole : IdentityRole<string>
    {
        public ICollection<AppUserRole> AppUserRoles { get; set; }
    }
}
