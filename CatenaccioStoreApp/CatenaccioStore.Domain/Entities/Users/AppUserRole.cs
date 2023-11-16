using Microsoft.AspNetCore.Identity;

namespace CatenaccioStore.Domain.Entities.Users
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public AppUser AppUser { get; set; }
        public AppRole AppRole { get; set; }
    }
}
