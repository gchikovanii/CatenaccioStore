using Microsoft.AspNetCore.Identity;


namespace CatenaccioStore.Domain.Entities.Users
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> AppUserRoles { get; set; }
    }
}
