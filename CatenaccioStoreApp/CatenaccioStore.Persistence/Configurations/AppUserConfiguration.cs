using CatenaccioStore.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CatenaccioStore.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasMany(i => i.AppUserRoles).WithOne(i => i.AppUser).HasForeignKey(i => i.UserId);
        }
    }
}
