using CatenaccioStore.Domain.Entities.Orders;
using CatenaccioStore.Domain.Entities.Users.Addresses;
using Microsoft.AspNetCore.Identity;


namespace CatenaccioStore.Domain.Entities.Users
{
    public class AppUser : IdentityUser<int>
    {
        public ICollection<AppUserRole> AppUserRoles { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Address Address { get; set; }
        public DateTimeOffset DOB { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
