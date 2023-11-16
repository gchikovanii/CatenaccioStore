﻿using CatenaccioStore.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CatenaccioStore.Persistence.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string, IdentityUserClaim<string>,AppUserRole,IdentityUserLogin<string>,IdentityRoleClaim<string>,IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().HasMany(i => i.AppUserRoles).WithOne(i => i.AppUser).HasForeignKey(i => i.UserId);
            builder.Entity<AppRole>().HasMany(i => i.AppUserRoles).WithOne(i => i.AppRole).HasForeignKey(i => i.RoleId);



        }

    }
}
